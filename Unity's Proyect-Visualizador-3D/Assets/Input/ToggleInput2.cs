// GENERATED AUTOMATICALLY FROM 'Assets/Input/ToggleInput2.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @ToggleInput2 : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @ToggleInput2()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""ToggleInput2"",
    ""maps"": [
        {
            ""name"": ""Switch"",
            ""id"": ""575d658f-db4a-4741-97f8-f898dc3a50c2"",
            ""actions"": [
                {
                    ""name"": ""ShiftToggle"",
                    ""type"": ""Button"",
                    ""id"": ""13f01da6-262d-4958-a677-a9b6ea9e4378"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""847e4e5f-54ad-4a38-89f0-7bd4758580d4"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShiftToggle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Switch
        m_Switch = asset.FindActionMap("Switch", throwIfNotFound: true);
        m_Switch_ShiftToggle = m_Switch.FindAction("ShiftToggle", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Switch
    private readonly InputActionMap m_Switch;
    private ISwitchActions m_SwitchActionsCallbackInterface;
    private readonly InputAction m_Switch_ShiftToggle;
    public struct SwitchActions
    {
        private @ToggleInput2 m_Wrapper;
        public SwitchActions(@ToggleInput2 wrapper) { m_Wrapper = wrapper; }
        public InputAction @ShiftToggle => m_Wrapper.m_Switch_ShiftToggle;
        public InputActionMap Get() { return m_Wrapper.m_Switch; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SwitchActions set) { return set.Get(); }
        public void SetCallbacks(ISwitchActions instance)
        {
            if (m_Wrapper.m_SwitchActionsCallbackInterface != null)
            {
                @ShiftToggle.started -= m_Wrapper.m_SwitchActionsCallbackInterface.OnShiftToggle;
                @ShiftToggle.performed -= m_Wrapper.m_SwitchActionsCallbackInterface.OnShiftToggle;
                @ShiftToggle.canceled -= m_Wrapper.m_SwitchActionsCallbackInterface.OnShiftToggle;
            }
            m_Wrapper.m_SwitchActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ShiftToggle.started += instance.OnShiftToggle;
                @ShiftToggle.performed += instance.OnShiftToggle;
                @ShiftToggle.canceled += instance.OnShiftToggle;
            }
        }
    }
    public SwitchActions @Switch => new SwitchActions(this);
    public interface ISwitchActions
    {
        void OnShiftToggle(InputAction.CallbackContext context);
    }
}
