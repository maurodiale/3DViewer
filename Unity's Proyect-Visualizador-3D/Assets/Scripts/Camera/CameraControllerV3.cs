using UnityEngine;
using UnityEngine.InputSystem;
// Implementacion basada en el blog gamedev-resources:
// https://gamedev-resources.com/make-a-configurable-camera-with-the-new-unity-input-system/
// How to implement scrolling with the new Input system
// https://stackoverflow.com/questions/66543338/detect-mouse-wheel-scrolling-input-with-unitys-new-input-system
// Interface implementation
// https://stackoverflow.com/questions/55992598/unity3d-new-input-system2-8-cant-reference-input-action-in-the-editor


public class CameraControllerV3 : MonoBehaviour
{
   	[SerializeField] private InputReader _inputReader = default;

    [Header("Camera Configurable Properties")]
    [Tooltip("The default amount the player is zoomed into the game world.")]
    public float defaultZoom = 0f;
    [Tooltip("The most a player can zoom in to the game world.")]
    public float zoomMax = -5f;
    [Tooltip("The furthest point a player can zoom back from the game world.")]
    public float zoomMin = 5f;
    [Tooltip("How fast the camera rotates")]
    public float rotationSpeed = 20f;
    [Tooltip("How fast the camera zooms")]
	public float zoomSpeed = 4f;
    [Tooltip("How fast the camera make the pan")]
    public float panSpeed = 0.05f;
    
    //Rotation & Pan variables
    private bool leftMouseDown = false;
    private bool middleMouseDown = false;
    private const float internalRotationSpeed = 4f;
    private Quaternion rotationTarget;
    private Vector2 mouseRotationDelta;
    private Vector2 mousePanDelta;

    //Movement variables
    private const float internalMoveTargetSpeed = 8f;
    private const float internalMoveSpeed = 4f;
    private Vector3 moveTarget;
    private Vector3 moveZoom;

    //Zoom variables
    private float internalZoomSpeed = 4;

    private float currentZoomAmount; // field
    public float currentZoom // property
    {
        get => currentZoomAmount; // accesor
        private set // mutator
        {
            //currentZoomAmount = value;
            currentZoomAmount = Mathf.Clamp(value, zoomMin, zoomMax);
            UpdateCameraTarget();
        }
    }

	private void OnEnable()
	{
		_inputReader.cameraZoomEvent += OnZoom;
		_inputReader.cameraPanEvent += OnPan;
		_inputReader.cameraRotateEvent += OnRotate;
		_inputReader.mouseDeltaEvent += OnMouseDelta;
	}

	private void OnDisable()
	{
		_inputReader.cameraZoomEvent -= OnZoom;
		_inputReader.cameraPanEvent -= OnPan;
		_inputReader.cameraRotateEvent -= OnRotate;
		_inputReader.mouseDeltaEvent -= OnMouseDelta;
	}

    private void UpdateCameraTarget()
    {
        //cameraPositionTarget = (Vector3.up * lookOffset) + (Quaternion.AngleAxis(cameraAngle, Vector3.right) * Vector3.back) * currentZoomAmount;
        //transform.position += transform.forward * currentZoom * zoomSpeed;
        //transform.Translate(transform.forward * currentZoom * zoomSpeed);
        moveZoom = transform.forward * currentZoomAmount;
    }

    void Start()
    {
        //Set the initial rotation value
        rotationTarget = transform.rotation;
        //Set the position of the camera based on the look offset, angle and default zoom properties. This will make sure we're focusing on the right focal point.
        currentZoom = defaultZoom;
        //transform.position = cameraPositionTarget;
    }

    void LateUpdate()
    {
        //Debug.Log(currentZoomAmount);
        //pan (from moveTarget) & 
        transform.position = Vector3.Lerp(transform.position, moveTarget+moveZoom, Time.deltaTime * internalZoomSpeed * (middleMouseDown ?  internalMoveSpeed : 1f));
        rotationTarget *= Quaternion.AngleAxis(mouseRotationDelta.x * Time.deltaTime * rotationSpeed, Vector3.up);
        rotationTarget *= Quaternion.AngleAxis(mouseRotationDelta.y * Time.deltaTime * rotationSpeed, Vector3.left);

        //Slerp the camera rig's rotation based on the new target
        transform.rotation = Quaternion.Slerp(transform.rotation, rotationTarget, Time.deltaTime * internalRotationSpeed);
    }

    private void FixedUpdate()
    {
        //Sets the move target position based on the move direction. Must be done here as there's no logic for the input system to calculate holding down an input
        moveTarget += (transform.up * mousePanDelta.y + transform.right * mousePanDelta.x) * Time.fixedDeltaTime * internalMoveTargetSpeed;
    }

/*************************************************************************************************** */

    public void OnZoom(float value)
    {
        //currentZoom = Mathf.Clamp(currentZoomAmount - (-1f*value)*zoomSpeed, zoomMax, zoomMin);
        //currentZoom = Mathf.Clamp(currentZoom - (value), zoomMax, zoomMin);
        //transform.Translate(transform.forward * value * zoomSpeed);
        //moveTarget += transform.forward * value * zoomSpeed; // este funciona
        currentZoom += value * zoomSpeed;
    }
    public void OnPan(float state)
    {
        middleMouseDown = state == 1;
    }
    public void OnRotate(float state){
        leftMouseDown = state == 1;

    }
    public void OnMouseDelta(Vector2 position){
        mouseRotationDelta = leftMouseDown ? position : Vector2.zero;
        mousePanDelta = middleMouseDown ? position : Vector2.zero;
    }
}

