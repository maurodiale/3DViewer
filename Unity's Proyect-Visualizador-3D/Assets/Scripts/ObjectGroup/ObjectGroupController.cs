using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectGroupController : MonoBehaviour
{
    [SerializeField] private InputReaderV2 _inputReader = default; // inputs

    [SerializeField] private SelectEventChannel OnSelectRequest; // Events channel when an object is selected

    [SerializeField] private UnSelectEventChannel OnUnSelectRequest; // Events channel when an object is unselected

    [SerializeField] private UnSelectAllEventChannel OnUnSelectAllRequest; // Events channel when all objects are unselected

    // List of selected Objects
    [SerializeField] private SelectedRuntimeSet Set;

    // Selection fields
    [SerializeField] private Camera _cam; // For the raycasting
    private Vector2 _mousePos;

    private void Awake()
    {
        _inputReader.groupsLClickPerformedEvent += OnLClick;
        _inputReader.mousePosEvent += OnMousePosition;
        _inputReader.controlStartedEvent += OnGroupsMode;
        _inputReader.controlCanceledEvent += OnCameraMode;
    }

    private void OnDisable()
    {
        _inputReader.mousePosEvent -= OnMousePosition;
        _inputReader.groupsLClickPerformedEvent -= OnLClick;
        _inputReader.controlStartedEvent -= OnGroupsMode;
        _inputReader.controlCanceledEvent -= OnCameraMode;
    }

    void OnGroupsMode()
    {
        _inputReader.EnableGroupsInput();
    }

    void OnCameraMode()
    {
        _inputReader.EnableCameraInput();
    }

    void OnLClick()
    {
        // En teoria esto sirve para ver si estamos cliqueando sobre la UI, pero parece que solo sirve para Canvas
        //if(EventSystem.current.IsPointerOverGameObject() == true) return;
        // hice algo a mano, no encontre algo similar para UITK (UI ToolKit)
        if(GUIController.overUI) return; // if we are over UI, do nothing
        Ray ray = _cam.ScreenPointToRay(_mousePos);
        RaycastHit[] hits = Physics.RaycastAll(ray);
        if(hits.Length == 0) // if clicked nothing
        {
            /*
            OnUnSelectAllRequest.RaiseEvent(); // Clear selection
            Set.Clear();
            Set.MenuGroupsDisplayNoneEvent(); // Close Menu Groups UI
            */
            return;
        }
        Set.MenuGroupsDisplayFlexEvent(); // Open Menu Groups UI
        for(int i=0; i<hits.Length; i++)
        {
            GameObject hitObject = hits[i].transform.gameObject;
            if(Set.Items.Contains(hitObject))
            {
                Set.Remove(hitObject);
                OnUnSelectRequest.RaiseEvent(hitObject);
                if(Set.Items.Count == 0) 
                {
                    Set.MenuGroupsDisplayNoneEvent();
                    Set.StateChangeEvent(SelectedRuntimeSet.Implementation.none);
                }
            }
            else
            {
                Set.Add(hitObject);
                OnSelectRequest.RaiseEvent(hitObject, transform);
            }
        }
    }

    void OnMousePosition(Vector2 mousePos) => _mousePos = mousePos;
}