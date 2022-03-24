using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "InputReader", menuName = "Input Reader")]
public class InputReaderV2 : ScriptableObject, PlayerInputs.ICameraActions, PlayerInputs.IGroupsActions, ToggleInput.ISwitchActions, PlayerInputs.ICortesActions, ToggleInput2.ISwitchActions
{
    // the Csharp code we generate from the action maps asset
    private PlayerInputs _controls;

    private ToggleInput _toggle; // We add other action map asset only to have the dessire behaviour with the control key
    // Having other action map asset allows us to have 2 action maps active at the same time
    // We have only 1 action(ControlToggle) in ToggleInput with the interaction Press and behaviour Release only.

    private ToggleInput2 _toggle2; // for Cortes, Shift

    // Toggle2 Events

    public event UnityAction shiftStartedEvent;
    public event UnityAction shiftCanceledEvent;

    // Camera and Groups Events in common
    public event UnityAction<Vector2> mousePosEvent;

    public event UnityAction controlStartedEvent;

    public event UnityAction controlCanceledEvent;

    public event UnityAction<Vector2> mouseDeltaEvent;

    // Camera Events
    public event UnityAction<float> cameraZoomEvent;

    public event UnityAction cameraLClickStartedEvent;

    public event UnityAction cameraLClickPerformedEvent;

    public event UnityAction cameraLClickCanceledEvent;

    public event UnityAction cameraDobleLClickEvent;

    public event UnityAction cameraMiddleClickStartedEvent;

    public event UnityAction cameraMiddleClickPerformedEvent;

    public event UnityAction cameraMiddleClickCanceledEvent;

    // Groups Events

    public event UnityAction groupsLClickPerformedEvent;

    public event UnityAction groupsLClickStartedEvent;

    public event UnityAction groupsLClickCanceledEvent;

    // Cortes Events
    public event UnityAction cortesLClickPerformedEvent;
    public event UnityAction cortesLClickStartedEvent;
    public event UnityAction cortesLClickCanceledEvent;

    private void OnEnable()
    {
        if(_controls == null)
        {
            _controls = new PlayerInputs();
            _controls.Camera.SetCallbacks(this);
            _controls.Groups.SetCallbacks(this);

            _toggle = new ToggleInput();
            _toggle.Switch.SetCallbacks(this);
            _toggle.Switch.Enable();

            _toggle2 = new ToggleInput2();
            _toggle2.Switch.SetCallbacks(this);
            _toggle2.Switch.Enable();
        }
        EnableCameraInput();
    }

    private void OnDisable() => DisableAllInput();

    // Toggle Events

    public void OnControlToggle(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed) // if control key is released
            controlCanceledEvent?.Invoke();
    }

    // Toggle2 Events

    public void OnShiftToggle(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed) // if shift key is released
        {
            shiftCanceledEvent?.Invoke();
        }
    }

    // Camera and Groups Events in common

    public void OnDelta(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed)
            mouseDeltaEvent?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnPosition(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed)
            mousePosEvent?.Invoke(context.ReadValue<Vector2>());
    }

    // Camera Events
    public void OnShiftCam(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started)
            shiftStartedEvent?.Invoke();
    }

    public void OnControlCam(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started)
            controlStartedEvent?.Invoke();
    }
    
    public void OnScrollWheel(InputAction.CallbackContext context)
    {
        /*
        if(cameraZoomEvent != null)
        {
            cameraZoomEvent.Invoke(context.ReadValue<float>());
        }
        */
        // La linea de abajo es equivalente a lo de arriba
        //cameraZoomEvent?.Invoke(context.ReadValue<float>());

        if(context.phase == InputActionPhase.Performed)
            cameraZoomEvent?.Invoke(context.ReadValue<float>());
    }

    public void OnDobleLClick(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed)
            cameraDobleLClickEvent?.Invoke();
    }

    public void OnLClickCam(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started)
            cameraLClickStartedEvent?.Invoke();

        if(context.phase == InputActionPhase.Performed)
            cameraLClickPerformedEvent?.Invoke();

        if(context.phase == InputActionPhase.Canceled)
            cameraLClickCanceledEvent?.Invoke();
    }

    public void OnMClick(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started)
            cameraMiddleClickStartedEvent?.Invoke();

        if(context.phase == InputActionPhase.Performed)
            cameraMiddleClickPerformedEvent?.Invoke();

        if(context.phase == InputActionPhase.Canceled)
            cameraMiddleClickCanceledEvent?.Invoke();
    }

    // Groups Events

    public void OnLClickGro(InputAction.CallbackContext context)
    {
        if(GUIController.isLabels || GUIController.isCortes || GUIController.isAnimacion)
            return;

        if(context.phase == InputActionPhase.Performed)
            groupsLClickPerformedEvent?.Invoke();

        if(context.phase == InputActionPhase.Started)
            groupsLClickStartedEvent?.Invoke();

        if(context.phase == InputActionPhase.Canceled)
            groupsLClickCanceledEvent?.Invoke();
    }

    // Cortes Events

    public void OnLClickCor(InputAction.CallbackContext context)
    {
        Debug.Log("Ireader click");
        if(context.phase == InputActionPhase.Performed)
            cortesLClickPerformedEvent?.Invoke();
        
        if(context.phase == InputActionPhase.Started)
            cortesLClickStartedEvent?.Invoke();

        if(context.phase == InputActionPhase.Canceled)
            cortesLClickCanceledEvent?.Invoke();
    }

    // Public methods
    public void EnableGroupsInput()
    {
        _controls.Groups.Enable();
        _controls.Camera.Disable();
        _controls.Cortes.Disable();
    }

    public void EnableCameraInput()
    {
        _controls.Camera.Enable();
        _controls.Groups.Disable();
        _controls.Cortes.Disable();
    }

    public void EnableCortesInput()
    {
        _controls.Cortes.Enable();
        _controls.Groups.Disable();
        _controls.Camera.Disable();
    }

    public void DisableAllInput()
    {
        _controls.Camera.Disable();
        _controls.Groups.Disable();
        _controls.Cortes.Disable();
        _toggle.Switch.Disable();
        _toggle2.Switch.Disable();
    }

    /* Podria ser útil
    // https://www.youtube.com/watch?v=T8fG0D2_V5M&t=192s

    public void ToggleActionMap(InputActionMap actionMap)
    {
        if(actionMap.enabled)
            return;
        
        _controls.Disable();
        actionMapChange?.Invoke(actionMap); // dispara un evento de cambio de controles
        actionMap.Enable();
    }
    */
}
