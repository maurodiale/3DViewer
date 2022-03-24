using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClippingMove : MonoBehaviour
{
    [SerializeField] private InputReaderV2 _inputReader = default;
    [SerializeField] private Camera cam;

    private bool _onClick = false;

    // translate variables
    private Vector2 _mousePos;
    private Vector3 _offset;
    private Vector3 _screenPoint;


    private void Awake()
    {
        
    }

    private void OnEnable()
    {
        _inputReader.shiftStartedEvent += OnShiftStart;
        _inputReader.shiftCanceledEvent += OnShiftCancel;
        _inputReader.mousePosEvent += OnMousePos;
        _inputReader.cortesLClickStartedEvent += OnLClickStarted;
        _inputReader.cortesLClickCanceledEvent += OnLClickCanceled;
    }

    private void OnDisable()
    {
        _inputReader.shiftStartedEvent -= OnShiftStart;
        _inputReader.shiftCanceledEvent -= OnShiftCancel;
        _inputReader.mousePosEvent -= OnMousePos;
        _inputReader.cortesLClickStartedEvent -= OnLClickStarted;
        _inputReader.cortesLClickCanceledEvent -= OnLClickCanceled;
    }

    private void OnShiftStart()
    {
        Debug.Log("shift start");
        _inputReader.EnableCortesInput();
    }

    private void OnShiftCancel()
    {
        Debug.Log("shift cancel");
        _inputReader.EnableCameraInput();
    }

    private void OnMousePos(Vector2 mousePos)
    {
        _mousePos = mousePos;

        if(!_onClick) return;

        Translate();
    }

    private void OnLClickStarted()
    {
        Debug.Log("click");
        if(!GUIController.isCortes) return;
        Ray ray = cam.ScreenPointToRay(_mousePos);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            Debug.Log("entro raycasting");
            if(GameObject.ReferenceEquals(gameObject, hit.transform.gameObject))
            {
                Debug.Log("son iguales");
                _onClick = true;
                _screenPoint = cam.WorldToScreenPoint(transform.position);
                _offset = transform.position - cam.ScreenToWorldPoint(new Vector3(_mousePos.x, _mousePos.y, _screenPoint.z));
            }
        }
    }

    private void OnLClickCanceled()
    {
        _onClick = false;
    }

    private void Rotate()
    {   
        //float rotX = _mouseDelta.x * rotationSpeed;
        //float rotY = _mouseDelta.y * rotationSpeed;
        //transform.RotateAround(transform.position, Vector3.up, -rotX);
        //transform.RotateAround(transform.position, Vector3.right, rotY);
    }

    private void Translate()
    {
        transform.position = _offset + cam.ScreenToWorldPoint(new Vector3(_mousePos.x, _mousePos.y, _screenPoint.z));
        Debug.Log("trasladando");
    }
}
