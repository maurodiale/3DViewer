using UnityEngine;

public class GroupImplementations : MonoBehaviour
{
    [SerializeField] private InputReaderV2 _inputReader = default;

    [SerializeField] private SelectedRuntimeSet Set;

    [SerializeField] private Camera cam;

    [SerializeField] private ResetTransformEventChannel OnResetRequest;

    [SerializeField] private DespieceEventChannel OnDespieceRequest;

    private bool _onClick = false;

    // Rotate variables
    [SerializeField] private float rotationSpeed;
    private Vector2 _mouseDelta;
    private Vector3 _middlePoint;

    // Translate variables
    private Vector2 _mousePos;
    private Vector3 _offset;
    private Vector3 _screenPoint;

    // Despiece variables
    [SerializeField] private float FactorDespiece = 1f;
    [SerializeField] private float timeToDespiece = 1f;

    private void Awake()
    {
        _inputReader.mousePosEvent += OnMousePosition;
        _inputReader.mouseDeltaEvent += OnMouseDelta;
        _inputReader.groupsLClickStartedEvent += OnLClickStarted;
        _inputReader.groupsLClickCanceledEvent += OnLClickCanceled;

        Set.StateChangeRequest += OnStateChange;
    }

    private void OnDisable()
    {
        _inputReader.mousePosEvent -= OnMousePosition;
        _inputReader.mouseDeltaEvent -= OnMouseDelta;
        _inputReader.groupsLClickStartedEvent -= OnLClickStarted;
        _inputReader.groupsLClickCanceledEvent -= OnLClickCanceled;

        Set.StateChangeRequest -= OnStateChange;
    }

    public void Reset()
    {
        UnHide2();
        OnResetRequest.RaiseEvent();
    }

    public void Despiece()
    {
        OnDespieceRequest.RaiseEvent(FactorDespiece, timeToDespiece);
    }

    private void OnMousePosition(Vector2 mousePos)
    {
        _mousePos = mousePos;
        
        if(!_onClick) return;

        switch (Set.State)
        {
            case SelectedRuntimeSet.Implementation.translate:
                Translate();
                break;
            case SelectedRuntimeSet.Implementation.rotate:
                Rotate();
                break;
            case SelectedRuntimeSet.Implementation.hide:
                break;
            default:
                break;
        }
    }

    private void OnMouseDelta(Vector2 mouseDelta) => _mouseDelta = mouseDelta;

    private void OnLClickStarted()
    {
        _onClick = true;
        _screenPoint = cam.WorldToScreenPoint(transform.position);
        _offset = transform.position - cam.ScreenToWorldPoint(new Vector3(_mousePos.x, _mousePos.y, _screenPoint.z));
        _middlePoint = Set.MiddlePoint();
    }

    private void OnLClickCanceled() => _onClick = false;

    private void OnStateChange(SelectedRuntimeSet.Implementation state)
    {
        switch (state)
        {
            case SelectedRuntimeSet.Implementation.hide:
                Hide();
                break;
            default:
                break;
        }
    }

    private void Hide()
    {
        for (int i = Set.Items.Count-1; i >= 0; i--)
        {
            Set.Items[i].gameObject.SetActive(false);
            //Set.Remove(Set.Items[i]);
        }
    }

    private void UnHide()
    {
        for (int i = Set.Items.Count-1; i >= 0; i--)
        {
            Set.Items[i].gameObject.SetActive(true);
        }
    }

    private void UnHide2()
    {
        Transform[] objs = GetComponentsInChildren<Transform>(true);

        for (int i = 0; i < objs.Length; i++)
        {
            objs[i].gameObject.SetActive(true);
        }
        
    }   

    private void Rotate()
    {   
        float rotX = _mouseDelta.x * rotationSpeed;
        float rotY = _mouseDelta.y * rotationSpeed;
        transform.RotateAround(_middlePoint, Vector3.up, -rotX);
        transform.RotateAround(_middlePoint, Vector3.right, rotY);
    }

    private void Translate()
    {
        transform.position = _offset + cam.ScreenToWorldPoint(new Vector3(_mousePos.x, _mousePos.y, _screenPoint.z));
    }
}
