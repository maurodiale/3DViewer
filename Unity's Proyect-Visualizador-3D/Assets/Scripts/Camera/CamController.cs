// https://forum.unity.com/threads/cinemachine-how-to-add-zoom-control-to-freelook-camera.505541/
// Scrip para el manejo de la camara. Tiene que estar en el padre de las camaras
// virtuales de cinemachine. Tiene que haber una FreeLook y una VirtualCam. La
// FreeLook no necesita ninguna configuración en particular, solo poner los orbits
// radios y alturas como nos plazca. La VirtualCam tiene que tener en Follow al 
// Transform de la Freelook, en LookAt nada (None). En body elegimos 3rd Person 
// Follow y ponemos todo en 0 (cero) y en Aim elegimos Do Nothing.
// En el CinemachineBrain ponemos el Default Blend en Cut o en Easy In Out a 0.1s.

// TODO: Mejorar el blend cuando cambiamos de objeto en el doble click.
// Se podría solucionar haciendo que el target sea un emptyGO que este en la posicion
// del objeto que queremos hacer focus. Y cuando hacemos doble clic hacemos un
// SmoothDamp a la posicion del nuevo objeto y creo que quedaria bien la transición.

using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;

public class CamController : MonoBehaviour
{
    [SerializeField] private InputReaderV2 _inputReader = default;

    public float mouseSensivityX = 1;
    public float mouseSensivityY = 1;
    
    // Double click variables
    private Vector2 _mousePosition;
    [SerializeField] private Camera _cam;
    private CinemachineBrain _brain;
    //private RaycastHit hit;
    //private bool _isDoubleClicked = false;
    
    // zoom variables
    public float zoomMin = 0.3f;
    public float zoomMax = 2f;
    [SerializeField] private float scale = 0.1f; // equivalente a un zoomspeed
    private float _zoomPercent = 1;

    // Cinemachine
    private CinemachineFreeLook cinemachineFreeLook; // this cam gets priority when Lclick is pressed
    private CinemachineFreeLook.Orbit[] originalOrbits; // variable that we change with zoom
    private CinemachineVirtualCamera cinemachineLock; // this cam get priority when nothing is happening
    
    private bool Lock = true; //this would be used to switch to a virtual camera for a lockon system

    private void Awake()
    {
        _brain = _cam.gameObject.GetComponent<CinemachineBrain>();
        cinemachineFreeLook = GetComponentInChildren<CinemachineFreeLook>();
        cinemachineLock = GetComponentInChildren<CinemachineVirtualCamera>();
        
        _inputReader.mouseDeltaEvent += CameraDelta;
        _inputReader.cameraLClickStartedEvent += LockOff;
        _inputReader.cameraLClickCanceledEvent += LockOn;
        _inputReader.cameraZoomEvent += OnZoom;
        _inputReader.cameraDobleLClickEvent += OnDobleClick;
        _inputReader.mousePosEvent += OnMousePosition;

        SetOriginalOrbits();
    }

    // We use the Orbits original values as default 
    void SetOriginalOrbits()
    {
        originalOrbits = new CinemachineFreeLook.Orbit[cinemachineFreeLook.m_Orbits.Length];
        for (int i = 0; i < cinemachineFreeLook.m_Orbits.Length; i++)
        {
            originalOrbits[i].m_Height = cinemachineFreeLook.m_Orbits[i].m_Height;
            originalOrbits[i].m_Radius = cinemachineFreeLook.m_Orbits[i].m_Radius;
        }
    }

    private void OnDisable()
    {
        _inputReader.mouseDeltaEvent -= CameraDelta;
        _inputReader.cameraLClickStartedEvent -= LockOff;
        _inputReader.cameraLClickCanceledEvent -= LockOn;
        _inputReader.cameraZoomEvent -= OnZoom;
        _inputReader.cameraDobleLClickEvent -= OnDobleClick;
        _inputReader.mousePosEvent -= OnMousePosition;
        _inputReader.DisableAllInput();
    }

    void LockOff() => Lock = false;

    void LockOn() => Lock = true;

    void CameraDelta(Vector2 lookDelta)
    {
        //cinemachineFreeLook.m_XAxis.Value -= lookDelta.x * mouseSensivityX;
        cinemachineFreeLook.m_XAxis.m_InputAxisValue -= lookDelta.x * mouseSensivityX;

        float lookDeltaY = lookDelta.y / 100f;
        //cinemachineFreeLook.m_YAxis.Value += lookDeltaY * mouseSensivityY;
        cinemachineFreeLook.m_YAxis.m_InputAxisValue += lookDeltaY * mouseSensivityY;
    }

    void OnDobleClick()
    {
        Ray ray = _cam.ScreenPointToRay(_mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            //_isDoubleClicked = true;
            //_brain.m_DefaultBlend.m_Time = 1; podria usarse para mejorar el blend
            cinemachineFreeLook.m_Follow = hit.transform;
            cinemachineFreeLook.m_LookAt = hit.transform;          
        }
    }

    void OnMousePosition(Vector2 mousePos)
    {
        _mousePosition = mousePos;
    }

    void OnZoom(float scrollInput)
    {
        _zoomPercent += scrollInput * scale;
        _zoomPercent = Mathf.Clamp(_zoomPercent, zoomMin, zoomMax);
    }

    void UpdateOrbit()
    {
        for (int i = 0; i < cinemachineFreeLook.m_Orbits.Length; i++)
        {
            cinemachineFreeLook.m_Orbits[i].m_Height = originalOrbits[i].m_Height * _zoomPercent;
            cinemachineFreeLook.m_Orbits[i].m_Radius = originalOrbits[i].m_Radius * _zoomPercent;
        }
    }

    void Update()
    {
        // LockOn system, change de camera priority to change between cams
        if( Lock == false )
        {
            //cinemachineFreeLook.gameObject.SetActive(true);
            cinemachineFreeLook.m_Priority = 11;
            cinemachineLock.m_Priority = 9;
        }
        else
        {
            cinemachineFreeLook.m_Priority = 9;
            cinemachineLock.m_Priority = 11;
            //cinemachineFreeLook.gameObject.SetActive(false);
        }
        UpdateOrbit();
        /*  PODRIA USARSE PARA MEJORAR EL BLEND
        if(_brain.ActiveBlend == null && _isDoubleClicked)
        {
            _brain.m_DefaultBlend.m_Time = 0.1f;
            //cinemachineFreeLook.m_Follow = hit.transform;
            //cinemachineFreeLook.m_LookAt = hit.transform;
            _isDoubleClicked = false;
        }
        */
    }

    // test
    public void BlendTest(CinemachineBrain br) => Debug.Log("Cambio Cámara");
}
