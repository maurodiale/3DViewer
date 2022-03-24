using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "ObjectGroupInputReader", menuName = "Game/Input Reader")]
public class InputReader : ScriptableObject, InputController.ICameraControllerActions, InputController.IObjectGroupActions
{
	public event UnityAction<float> cameraZoomEvent;
	public event UnityAction<float> cameraPanEvent;
	public event UnityAction<float> lClickEvent;
	public event UnityAction<float> mClickEvent;
	public event UnityAction<float> yScrollEvent;


	public event UnityAction<float> cameraRotateEvent;
	public event UnityAction<Vector2> mouseDeltaEvent;
	public event UnityAction<Vector2> mousePosEvent;
	public event UnityAction  groupModeEvent;
	public event UnityAction  cameraModeEvent;

	public event UnityAction<Vector2> moveEvent;


	private InputController _inputController;

	private void OnEnable()
	{
		if (_inputController == null)
		{
			_inputController = new InputController();
			_inputController.CameraController.SetCallbacks(this);
			_inputController.ObjectGroup.SetCallbacks(this);
		}

		EnableCameraInput();
	}

/*************************************************************************************************** */

    public void OnZoom(InputAction.CallbackContext context)
    {
		if (cameraZoomEvent != null)
		{
			cameraZoomEvent.Invoke(context.ReadValue<float>());
		}
    }

	public void OnScroll(InputAction.CallbackContext context)
    {
		if (yScrollEvent != null)
		{
			yScrollEvent.Invoke(context.ReadValue<float>());
		}
    }

	// camera and group implementations

	public void OnPan(InputAction.CallbackContext context)
    {
		if (cameraPanEvent != null)
		{
			cameraPanEvent.Invoke(context.ReadValue<float>());
		}
    }
	public void OnMClick(InputAction.CallbackContext context)
    {
		if (mClickEvent != null)
		{
			mClickEvent.Invoke(context.ReadValue<float>());
		}
    }

    // camera and group implementations
	public void OnRotate(InputAction.CallbackContext context)
    {
		if (cameraRotateEvent != null)
		{
			cameraRotateEvent.Invoke(context.ReadValue<float>());
		}

    }
	public void OnLClick(InputAction.CallbackContext context)
    {
		if (lClickEvent != null)
		{
			lClickEvent.Invoke(context.ReadValue<float>());
		}
    }
	// camera and group implementations
    public void OnDeltaPos(InputAction.CallbackContext context)
    {
		if (mouseDeltaEvent != null)
		{
			mouseDeltaEvent.Invoke(context.ReadValue<Vector2>());
		}
    }

	public void OnPos(InputAction.CallbackContext context)
    {
		if (mousePosEvent != null)
		{
			mousePosEvent.Invoke(context.ReadValue<Vector2>());
		}
    }
	
	public void OnCrlPressed(InputAction.CallbackContext context)
    {
		
        	if (groupModeEvent != null
			&& context.phase == InputActionPhase.Performed)
			groupModeEvent.Invoke();

		if (cameraModeEvent != null
			&& context.phase == InputActionPhase.Canceled)
			cameraModeEvent.Invoke();
		
    }

/*************************************************************************************************** */

	private void OnDisable()
	{
		DisableAllInput();
	}

	private bool IsDeviceMouse(InputAction.CallbackContext context) => context.control.device.name == "Mouse";

	public void EnableObjectGroupInput()
	{
		_inputController.ObjectGroup.Enable();
		_inputController.CameraController.Disable();
	}

	public void EnableCameraInput()
	{
		_inputController.CameraController.Enable();
		_inputController.ObjectGroup.Disable();
	}

	public void DisableAllInput()
	{
		_inputController.CameraController.Disable();
		_inputController.ObjectGroup.Disable();
	}
}
