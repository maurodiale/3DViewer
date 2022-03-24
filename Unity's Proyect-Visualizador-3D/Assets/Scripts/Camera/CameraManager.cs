// Se usa mucho _cam.transform, pero como el script es un componente de la camara
// con usar solo transform (sin el _cam) es suficiente, los dejamos por las dudas
// que el script se cambie a otro objeto como un camManager y sean necesarios esos
// _cam. Esta es la implementación que más me gusta. Creo que esta todo correcto.
//
// TODO: Estoy haciendo el deltaMouse a "mano", cambiar por el deltaMouse del InputReader
// https://forum.unity.com/threads/how-to-prevent-object-under-a-clicked-ui-element-catching-the-same-action.1151048/
// https://forum.unity.com/threads/feedback-wanted-new-input-system-support.963111/ (comentario 27)
// https://forum.unity.com/threads/how-to-detect-if-mouse-is-over-ui.1025533/

using UnityEngine;

public class CameraManager : MonoBehaviour
{
    // Input SO
    [SerializeField] private InputReaderV2 _inputReader = default;

    private Camera _cam;
    [Header("Camera configuration")]
    [Tooltip("Object the camera focus on")]
    [SerializeField] private Transform _target; // Object the camera focus on
    [Tooltip("Distance between camera and target")]
    [SerializeField] private float _distance; // distance between camera and target
    [Range(0.1f, 1f)] // range of the rotation speed
    [SerializeField] private float _RotationSpeed = 0.7f;
    private Vector3 _previousPosition;

    private bool Lock = true; // boolean we use to rotate de camera when Lclick is clicked

    // Zoom fields

    public float zoomMin = 0.2f;
    public float zoomMax = 1.5f;
    [SerializeField] private float _zoomSpeed = 0.1f;
    private float _zoomPercent = 1;
    private float _originalDistance;

    // Double click fields

    private bool isDoubleClicked = false; // boolean we use to do the logic of centering
    private Vector3 _camTarget; // position where the cam will move at doble click
    private Vector3 camSmoothDampVel; // necesary for SmoothDamp
    [SerializeField] private float timeToCenter = 0.2f; // the time it takes the cam to move to _camTarget
    private float timeChange; // We use this to change isDoubleClicked, to finish the centering
    private Vector2 _mousePos; // esto deberia ser Vector2?

    // Pan fields
    private bool _isPanning = false;
    private Vector3 _offset;
    [SerializeField] private float panSpeed = 0.5f;
    private Vector3 _screenPoint;

    private void Awake()
    {
        _cam = GetComponent<Camera>();

        _inputReader.mousePosEvent += OnMousePos;
        _inputReader.cameraLClickStartedEvent += LockOff;
        _inputReader.cameraLClickCanceledEvent += LockOn;
        _inputReader.cameraZoomEvent += OnZoom;
        _inputReader.cameraDobleLClickEvent += OnDobleClick;
        _inputReader.cameraMiddleClickStartedEvent += OnPanStart;
        _inputReader.cameraMiddleClickCanceledEvent += OnPanFinish;

        _originalDistance = _distance;
    }

    private void OnDisable()
    {
        _inputReader.mousePosEvent -= OnMousePos;
        _inputReader.cameraLClickStartedEvent -= LockOff;
        _inputReader.cameraLClickCanceledEvent -= LockOn;
        _inputReader.cameraZoomEvent -= OnZoom;
        _inputReader.cameraDobleLClickEvent -= OnDobleClick;
        _inputReader.cameraMiddleClickStartedEvent -= OnPanStart;
        _inputReader.cameraMiddleClickCanceledEvent -= OnPanFinish;
    }

    private void LockOff()
    {
        if (GUIController.overUI) return;
        Lock = false; // Permitimos que la camara rote
    }

    private void LockOn() => Lock = true;

    private void OnPanStart()
    {
        _isPanning = true;
        _screenPoint = _cam.WorldToScreenPoint(_target.position);
        _offset = _target.position - _cam.ScreenToWorldPoint(new Vector3(_mousePos.x, _mousePos.y, _screenPoint.z));
    }

    private void OnPanFinish()
    {
        _isPanning = false;
    }

    private void OnMousePos(Vector2 mousePos)
    {
        _mousePos = mousePos;

        if (!Lock && !isDoubleClicked && !_isPanning) // si no esta la camara travada y no esta ocurriendo un centrado
        {
            RotateCamera();
        }
        _previousPosition = _cam.ScreenToViewportPoint(new Vector3(_mousePos.x, _mousePos.y, 0f));

        if (_isPanning && !isDoubleClicked)
        {
            PanCamera();
        }
    }

    private void RotateCamera()
    {
        Vector3 direction = _previousPosition - _cam.ScreenToViewportPoint(new Vector3(_mousePos.x, _mousePos.y, 0f)); // estoy haciendo el deltaMouse a mano, cambiar
        _cam.transform.position = _target.position; // La camara se pone en la posicion del target
        _cam.transform.Rotate(new Vector3(1, 0, 0), direction.y * 180 * _RotationSpeed); // Rotacion alrededor del eje x
        _cam.transform.Rotate(new Vector3(0, 1, 0), -direction.x * 180 * _RotationSpeed, Space.World); // Rotacion alrededor del eje y
        _cam.transform.Translate(new Vector3(0, 0, -_distance)); // Nos alejamos del target una distancia.
    }

    private void PanCamera()
    {
        _target.position = (_offset + _cam.ScreenToWorldPoint(new Vector3(_mousePos.x, _mousePos.y, _screenPoint.z))) * panSpeed;
    }

    private void OnZoom(float scrollInput)
    {
        if (Lock || !isDoubleClicked) // no se puede hacer zoom mientras rotamos la camara o mientras ocurre un centrado
        {
            _zoomPercent += scrollInput * _zoomSpeed;
            _zoomPercent = Mathf.Clamp(_zoomPercent, zoomMin, zoomMax);
        }
    }

    public void MoveCamera(RaycastHit hit)
    {
        if(isDoubleClicked) return; // si ya esta ocurriendo un centrado, no hacemos nada
        isDoubleClicked = true;
        _camTarget = _cam.transform.position + hit.transform.position - _target.position; // Sale de hacer unas cuentas con vectores
        //_target = hit.transform; // Cambiamos esta linea por la de abajo, ya que esto generaba problema en la traslación de las geo
        _target.position = hit.transform.position;
        timeChange = timeToCenter + 0.5f;// le agregamos 0.5 s más para que tenga tiempo de sobra en hacerse el centrado

    }
    private void OnDobleClick()
    {
        if (GUIController.overUI || GUIController.isLabels) return;
        Ray ray = _cam.ScreenPointToRay(_mousePos);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            MoveCamera(hit);
        }

    }

    private void Update()
    {
        if (isDoubleClicked)
        {
            _cam.transform.position = Vector3.SmoothDamp(_cam.transform.position, _camTarget, ref camSmoothDampVel, timeToCenter);
            if (timeChange < 0)
                isDoubleClicked = false;
            else
                timeChange -= Time.deltaTime;
        }
        else if (Lock)
        {
            _distance = _originalDistance * _zoomPercent;
            _cam.transform.position = _target.position;
            _cam.transform.Translate(new Vector3(0, 0, -_distance));
        }
    }
}