using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabelsManager : MonoBehaviour
{
    [SerializeField] InputReaderV2 _inputReader = default;
    [SerializeField] private Camera cam; // for raycasting
    
    [SerializeField] private CameraManager cameraController;
    
    [SerializeField] private LabelsChangeEventChannel LabelsChangeRequest;

    //private Geometry _geometry;

    private Vector3 _mousePos;

    private void Awake()
    {
        _inputReader.mousePosEvent += OnMousePosition;
        _inputReader.cameraLClickPerformedEvent += OnLClick;
    }

    private void OnDisable()
    {
        _inputReader.mousePosEvent -= OnMousePosition;
        _inputReader.cameraLClickPerformedEvent -= OnLClick;
    }

    private void OnMousePosition(Vector2 mousePos)
    {
        _mousePos = mousePos;
    }

    private void OnLClick()
    {
        if(!GUIController.isLabels) return;

        Ray ray = cam.ScreenPointToRay(_mousePos);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            Geometry _geometry = DataManager.GetGeometryByName(hit.transform.name);
            //Geometry _geometry = DataManager.GetGeometryByID(hit.transform.gameObject.GetInstanceID());
            LabelsChangeRequest.RaiseEvent(_geometry.geoName, _geometry.geoDescription);
            cameraController.MoveCamera(hit); // center the camera in the obj
        }
    }
}
