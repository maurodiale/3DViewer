// GENERATED AUTOMATICALLY FROM 'Assets/Input/Player Inputs.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInputs : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player Inputs"",
    ""maps"": [
        {
            ""name"": ""Camera"",
            ""id"": ""346ce6f5-72f0-4807-90d3-0ffd8c3a0501"",
            ""actions"": [
                {
                    ""name"": ""ScrollWheel"",
                    ""type"": ""PassThrough"",
                    ""id"": ""f8ef4d9f-1ca6-482c-ab67-fc2e74939181"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LClickCam"",
                    ""type"": ""Button"",
                    ""id"": ""2b9912f2-68a6-4485-949f-f35391fa3c7d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DobleLClick"",
                    ""type"": ""Button"",
                    ""id"": ""75399221-68b0-4bb1-a289-44fb6537beed"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""MultiTap""
                },
                {
                    ""name"": ""Position"",
                    ""type"": ""Value"",
                    ""id"": ""f85b951d-194f-415f-b784-8646f5b7ab98"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Delta"",
                    ""type"": ""Value"",
                    ""id"": ""219b8f17-3458-4858-91b4-b32b0cd32328"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ControlCam"",
                    ""type"": ""Button"",
                    ""id"": ""23d75993-6838-4cb1-81f8-90dda1eb1e90"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MClick"",
                    ""type"": ""Button"",
                    ""id"": ""2ac2abfb-ab4c-4ffd-bca8-608b8ff0c135"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ShiftCam"",
                    ""type"": ""Button"",
                    ""id"": ""a18cb625-f7e1-4ebe-96e1-a1bc15b75715"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3d2558b2-3488-4159-97e5-e6390c5b41cc"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": ""Normalize(min=-1,max=1)"",
                    ""groups"": ""keyboard & mouse"",
                    ""action"": ""ScrollWheel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b534fcd6-0d3a-482b-aa2e-f1666ed889e9"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keyboard & mouse"",
                    ""action"": ""LClickCam"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c9158e0a-f6aa-4b42-94bd-10ff6b8205dd"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keyboard & mouse"",
                    ""action"": ""DobleLClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""977e3d67-0980-42a5-8fb7-e26f2af60aa8"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keyboard & mouse"",
                    ""action"": ""Position"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2644e2db-d2d8-4f8d-a709-0817c51f19cd"",
                    ""path"": ""<Pointer>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keyboard & mouse"",
                    ""action"": ""Delta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ae55aeaa-461c-4b4e-ad83-bf8612422afd"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5438eeb6-02d8-422f-a419-a871abf76805"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keyboard & mouse"",
                    ""action"": ""ControlCam"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f2478382-0e68-4475-b000-7ca5a50d7209"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keyboard & mouse"",
                    ""action"": ""ShiftCam"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Groups"",
            ""id"": ""2d295bee-ee91-4471-b182-fdf61611a736"",
            ""actions"": [
                {
                    ""name"": ""LClickGro"",
                    ""type"": ""Button"",
                    ""id"": ""a7a3fe8f-f278-487a-8ad9-9eff1121bb09"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Position"",
                    ""type"": ""Value"",
                    ""id"": ""ba6cd18d-1c4a-4391-a2eb-424eef2b016d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Delta"",
                    ""type"": ""Value"",
                    ""id"": ""b3269f2d-6975-4d9b-8b72-141f6ddc2fad"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ac19037c-4f33-4588-87ff-3a4af3bbcafd"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keyboard & mouse"",
                    ""action"": ""LClickGro"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""097aa84f-bdce-46d0-b0ac-de5f96f85f5c"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keyboard & mouse"",
                    ""action"": ""Position"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""127cd64a-d99e-4e86-8239-db0bf8c1a004"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keyboard & mouse"",
                    ""action"": ""Delta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Cortes"",
            ""id"": ""a99daecc-f30c-489e-9a41-bb8a96a3ecb0"",
            ""actions"": [
                {
                    ""name"": ""LClickCor"",
                    ""type"": ""Button"",
                    ""id"": ""b5df9e3a-89e6-4210-97c4-a8c11fc08d24"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Position"",
                    ""type"": ""Value"",
                    ""id"": ""bcbe6f5c-3453-4c1b-93c1-15f18d98b87f"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Delta"",
                    ""type"": ""Value"",
                    ""id"": ""3db94a64-468f-4646-9afa-d5291f5d0ee8"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""80b2a6d4-b911-4235-9129-20ea1e52f152"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keyboard & mouse"",
                    ""action"": ""LClickCor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f7b195bf-e246-459f-a676-ac996a8a4ee4"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keyboard & mouse"",
                    ""action"": ""Position"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9d4d34cd-4926-4ace-96d6-dac2e281bf74"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Delta"",
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
        // Camera
        m_Camera = asset.FindActionMap("Camera", throwIfNotFound: true);
        m_Camera_ScrollWheel = m_Camera.FindAction("ScrollWheel", throwIfNotFound: true);
        m_Camera_LClickCam = m_Camera.FindAction("LClickCam", throwIfNotFound: true);
        m_Camera_DobleLClick = m_Camera.FindAction("DobleLClick", throwIfNotFound: true);
        m_Camera_Position = m_Camera.FindAction("Position", throwIfNotFound: true);
        m_Camera_Delta = m_Camera.FindAction("Delta", throwIfNotFound: true);
        m_Camera_ControlCam = m_Camera.FindAction("ControlCam", throwIfNotFound: true);
        m_Camera_MClick = m_Camera.FindAction("MClick", throwIfNotFound: true);
        m_Camera_ShiftCam = m_Camera.FindAction("ShiftCam", throwIfNotFound: true);
        // Groups
        m_Groups = asset.FindActionMap("Groups", throwIfNotFound: true);
        m_Groups_LClickGro = m_Groups.FindAction("LClickGro", throwIfNotFound: true);
        m_Groups_Position = m_Groups.FindAction("Position", throwIfNotFound: true);
        m_Groups_Delta = m_Groups.FindAction("Delta", throwIfNotFound: true);
        // Cortes
        m_Cortes = asset.FindActionMap("Cortes", throwIfNotFound: true);
        m_Cortes_LClickCor = m_Cortes.FindAction("LClickCor", throwIfNotFound: true);
        m_Cortes_Position = m_Cortes.FindAction("Position", throwIfNotFound: true);
        m_Cortes_Delta = m_Cortes.FindAction("Delta", throwIfNotFound: true);
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

    // Camera
    private readonly InputActionMap m_Camera;
    private ICameraActions m_CameraActionsCallbackInterface;
    private readonly InputAction m_Camera_ScrollWheel;
    private readonly InputAction m_Camera_LClickCam;
    private readonly InputAction m_Camera_DobleLClick;
    private readonly InputAction m_Camera_Position;
    private readonly InputAction m_Camera_Delta;
    private readonly InputAction m_Camera_ControlCam;
    private readonly InputAction m_Camera_MClick;
    private readonly InputAction m_Camera_ShiftCam;
    public struct CameraActions
    {
        private @PlayerInputs m_Wrapper;
        public CameraActions(@PlayerInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @ScrollWheel => m_Wrapper.m_Camera_ScrollWheel;
        public InputAction @LClickCam => m_Wrapper.m_Camera_LClickCam;
        public InputAction @DobleLClick => m_Wrapper.m_Camera_DobleLClick;
        public InputAction @Position => m_Wrapper.m_Camera_Position;
        public InputAction @Delta => m_Wrapper.m_Camera_Delta;
        public InputAction @ControlCam => m_Wrapper.m_Camera_ControlCam;
        public InputAction @MClick => m_Wrapper.m_Camera_MClick;
        public InputAction @ShiftCam => m_Wrapper.m_Camera_ShiftCam;
        public InputActionMap Get() { return m_Wrapper.m_Camera; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CameraActions set) { return set.Get(); }
        public void SetCallbacks(ICameraActions instance)
        {
            if (m_Wrapper.m_CameraActionsCallbackInterface != null)
            {
                @ScrollWheel.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnScrollWheel;
                @ScrollWheel.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnScrollWheel;
                @ScrollWheel.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnScrollWheel;
                @LClickCam.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnLClickCam;
                @LClickCam.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnLClickCam;
                @LClickCam.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnLClickCam;
                @DobleLClick.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnDobleLClick;
                @DobleLClick.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnDobleLClick;
                @DobleLClick.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnDobleLClick;
                @Position.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnPosition;
                @Position.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnPosition;
                @Position.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnPosition;
                @Delta.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnDelta;
                @Delta.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnDelta;
                @Delta.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnDelta;
                @ControlCam.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnControlCam;
                @ControlCam.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnControlCam;
                @ControlCam.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnControlCam;
                @MClick.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnMClick;
                @MClick.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnMClick;
                @MClick.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnMClick;
                @ShiftCam.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnShiftCam;
                @ShiftCam.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnShiftCam;
                @ShiftCam.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnShiftCam;
            }
            m_Wrapper.m_CameraActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ScrollWheel.started += instance.OnScrollWheel;
                @ScrollWheel.performed += instance.OnScrollWheel;
                @ScrollWheel.canceled += instance.OnScrollWheel;
                @LClickCam.started += instance.OnLClickCam;
                @LClickCam.performed += instance.OnLClickCam;
                @LClickCam.canceled += instance.OnLClickCam;
                @DobleLClick.started += instance.OnDobleLClick;
                @DobleLClick.performed += instance.OnDobleLClick;
                @DobleLClick.canceled += instance.OnDobleLClick;
                @Position.started += instance.OnPosition;
                @Position.performed += instance.OnPosition;
                @Position.canceled += instance.OnPosition;
                @Delta.started += instance.OnDelta;
                @Delta.performed += instance.OnDelta;
                @Delta.canceled += instance.OnDelta;
                @ControlCam.started += instance.OnControlCam;
                @ControlCam.performed += instance.OnControlCam;
                @ControlCam.canceled += instance.OnControlCam;
                @MClick.started += instance.OnMClick;
                @MClick.performed += instance.OnMClick;
                @MClick.canceled += instance.OnMClick;
                @ShiftCam.started += instance.OnShiftCam;
                @ShiftCam.performed += instance.OnShiftCam;
                @ShiftCam.canceled += instance.OnShiftCam;
            }
        }
    }
    public CameraActions @Camera => new CameraActions(this);

    // Groups
    private readonly InputActionMap m_Groups;
    private IGroupsActions m_GroupsActionsCallbackInterface;
    private readonly InputAction m_Groups_LClickGro;
    private readonly InputAction m_Groups_Position;
    private readonly InputAction m_Groups_Delta;
    public struct GroupsActions
    {
        private @PlayerInputs m_Wrapper;
        public GroupsActions(@PlayerInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @LClickGro => m_Wrapper.m_Groups_LClickGro;
        public InputAction @Position => m_Wrapper.m_Groups_Position;
        public InputAction @Delta => m_Wrapper.m_Groups_Delta;
        public InputActionMap Get() { return m_Wrapper.m_Groups; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GroupsActions set) { return set.Get(); }
        public void SetCallbacks(IGroupsActions instance)
        {
            if (m_Wrapper.m_GroupsActionsCallbackInterface != null)
            {
                @LClickGro.started -= m_Wrapper.m_GroupsActionsCallbackInterface.OnLClickGro;
                @LClickGro.performed -= m_Wrapper.m_GroupsActionsCallbackInterface.OnLClickGro;
                @LClickGro.canceled -= m_Wrapper.m_GroupsActionsCallbackInterface.OnLClickGro;
                @Position.started -= m_Wrapper.m_GroupsActionsCallbackInterface.OnPosition;
                @Position.performed -= m_Wrapper.m_GroupsActionsCallbackInterface.OnPosition;
                @Position.canceled -= m_Wrapper.m_GroupsActionsCallbackInterface.OnPosition;
                @Delta.started -= m_Wrapper.m_GroupsActionsCallbackInterface.OnDelta;
                @Delta.performed -= m_Wrapper.m_GroupsActionsCallbackInterface.OnDelta;
                @Delta.canceled -= m_Wrapper.m_GroupsActionsCallbackInterface.OnDelta;
            }
            m_Wrapper.m_GroupsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @LClickGro.started += instance.OnLClickGro;
                @LClickGro.performed += instance.OnLClickGro;
                @LClickGro.canceled += instance.OnLClickGro;
                @Position.started += instance.OnPosition;
                @Position.performed += instance.OnPosition;
                @Position.canceled += instance.OnPosition;
                @Delta.started += instance.OnDelta;
                @Delta.performed += instance.OnDelta;
                @Delta.canceled += instance.OnDelta;
            }
        }
    }
    public GroupsActions @Groups => new GroupsActions(this);

    // Cortes
    private readonly InputActionMap m_Cortes;
    private ICortesActions m_CortesActionsCallbackInterface;
    private readonly InputAction m_Cortes_LClickCor;
    private readonly InputAction m_Cortes_Position;
    private readonly InputAction m_Cortes_Delta;
    public struct CortesActions
    {
        private @PlayerInputs m_Wrapper;
        public CortesActions(@PlayerInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @LClickCor => m_Wrapper.m_Cortes_LClickCor;
        public InputAction @Position => m_Wrapper.m_Cortes_Position;
        public InputAction @Delta => m_Wrapper.m_Cortes_Delta;
        public InputActionMap Get() { return m_Wrapper.m_Cortes; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CortesActions set) { return set.Get(); }
        public void SetCallbacks(ICortesActions instance)
        {
            if (m_Wrapper.m_CortesActionsCallbackInterface != null)
            {
                @LClickCor.started -= m_Wrapper.m_CortesActionsCallbackInterface.OnLClickCor;
                @LClickCor.performed -= m_Wrapper.m_CortesActionsCallbackInterface.OnLClickCor;
                @LClickCor.canceled -= m_Wrapper.m_CortesActionsCallbackInterface.OnLClickCor;
                @Position.started -= m_Wrapper.m_CortesActionsCallbackInterface.OnPosition;
                @Position.performed -= m_Wrapper.m_CortesActionsCallbackInterface.OnPosition;
                @Position.canceled -= m_Wrapper.m_CortesActionsCallbackInterface.OnPosition;
                @Delta.started -= m_Wrapper.m_CortesActionsCallbackInterface.OnDelta;
                @Delta.performed -= m_Wrapper.m_CortesActionsCallbackInterface.OnDelta;
                @Delta.canceled -= m_Wrapper.m_CortesActionsCallbackInterface.OnDelta;
            }
            m_Wrapper.m_CortesActionsCallbackInterface = instance;
            if (instance != null)
            {
                @LClickCor.started += instance.OnLClickCor;
                @LClickCor.performed += instance.OnLClickCor;
                @LClickCor.canceled += instance.OnLClickCor;
                @Position.started += instance.OnPosition;
                @Position.performed += instance.OnPosition;
                @Position.canceled += instance.OnPosition;
                @Delta.started += instance.OnDelta;
                @Delta.performed += instance.OnDelta;
                @Delta.canceled += instance.OnDelta;
            }
        }
    }
    public CortesActions @Cortes => new CortesActions(this);
    private int m_keyboardmouseSchemeIndex = -1;
    public InputControlScheme keyboardmouseScheme
    {
        get
        {
            if (m_keyboardmouseSchemeIndex == -1) m_keyboardmouseSchemeIndex = asset.FindControlSchemeIndex("keyboard & mouse");
            return asset.controlSchemes[m_keyboardmouseSchemeIndex];
        }
    }
    public interface ICameraActions
    {
        void OnScrollWheel(InputAction.CallbackContext context);
        void OnLClickCam(InputAction.CallbackContext context);
        void OnDobleLClick(InputAction.CallbackContext context);
        void OnPosition(InputAction.CallbackContext context);
        void OnDelta(InputAction.CallbackContext context);
        void OnControlCam(InputAction.CallbackContext context);
        void OnMClick(InputAction.CallbackContext context);
        void OnShiftCam(InputAction.CallbackContext context);
    }
    public interface IGroupsActions
    {
        void OnLClickGro(InputAction.CallbackContext context);
        void OnPosition(InputAction.CallbackContext context);
        void OnDelta(InputAction.CallbackContext context);
    }
    public interface ICortesActions
    {
        void OnLClickCor(InputAction.CallbackContext context);
        void OnPosition(InputAction.CallbackContext context);
        void OnDelta(InputAction.CallbackContext context);
    }
}
