// GENERATED AUTOMATICALLY FROM 'Assets/Input/ToggleInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @ToggleInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @ToggleInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""ToggleInput"",
    ""maps"": [
        {
            ""name"": ""Switch"",
            ""id"": ""1f0b9003-f043-46f0-aa25-4569a3ad8a23"",
            ""actions"": [
                {
                    ""name"": ""ControlToggle"",
                    ""type"": ""Button"",
                    ""id"": ""e4c5c3dc-85b1-4a65-bbff-e1bf1cace25c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""35eda5a5-7bec-419d-ada7-619855391984"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keyboard & mouse"",
                    ""action"": ""ControlToggle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""keyboard & mouse"",
            ""bindingGroup"": ""keyboard & mouse"",
            ""devices"": []
        }
    ]
}");
        // Switch
        m_Switch = asset.FindActionMap("Switch", throwIfNotFound: true);
        m_Switch_ControlToggle = m_Switch.FindAction("ControlToggle", throwIfNotFound: true);
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
    private readonly InputAction m_Switch_ControlToggle;
    public struct SwitchActions
    {
        private @ToggleInput m_Wrapper;
        public SwitchActions(@ToggleInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @ControlToggle => m_Wrapper.m_Switch_ControlToggle;
        public InputActionMap Get() { return m_Wrapper.m_Switch; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SwitchActions set) { return set.Get(); }
        public void SetCallbacks(ISwitchActions instance)
        {
            if (m_Wrapper.m_SwitchActionsCallbackInterface != null)
            {
                @ControlToggle.started -= m_Wrapper.m_SwitchActionsCallbackInterface.OnControlToggle;
                @ControlToggle.performed -= m_Wrapper.m_SwitchActionsCallbackInterface.OnControlToggle;
                @ControlToggle.canceled -= m_Wrapper.m_SwitchActionsCallbackInterface.OnControlToggle;
            }
            m_Wrapper.m_SwitchActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ControlToggle.started += instance.OnControlToggle;
                @ControlToggle.performed += instance.OnControlToggle;
                @ControlToggle.canceled += instance.OnControlToggle;
            }
        }
    }
    public SwitchActions @Switch => new SwitchActions(this);
    private int m_keyboardmouseSchemeIndex = -1;
    public InputControlScheme keyboardmouseScheme
    {
        get
        {
            if (m_keyboardmouseSchemeIndex == -1) m_keyboardmouseSchemeIndex = asset.FindControlSchemeIndex("keyboard & mouse");
            return asset.controlSchemes[m_keyboardmouseSchemeIndex];
        }
    }
    public interface ISwitchActions
    {
        void OnControlToggle(InputAction.CallbackContext context);
    }
}
