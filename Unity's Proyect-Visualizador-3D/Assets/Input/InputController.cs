// GENERATED AUTOMATICALLY FROM 'Assets/Settings/Input/InputController.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputController : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputController()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputController"",
    ""maps"": [
        {
            ""name"": ""CameraController"",
            ""id"": ""f3efd799-4c0e-4585-b59b-94adb57a4abc"",
            ""actions"": [
                {
                    ""name"": ""Zoom"",
                    ""type"": ""PassThrough"",
                    ""id"": ""57b5183e-ee98-4b26-9dd2-8ed7d61e0fef"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CrlPressed"",
                    ""type"": ""Button"",
                    ""id"": ""5658c61a-bb20-42fa-b9c6-56cdd8435c5e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pan"",
                    ""type"": ""Button"",
                    ""id"": ""88521e48-272d-4d48-9f2b-e2e6491d4d69"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Button"",
                    ""id"": ""497557c9-ec4b-4e8d-8970-b03cb0e76b50"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DeltaPos"",
                    ""type"": ""Value"",
                    ""id"": ""e02e14c7-8e9e-4161-b5af-4b35c2ccb163"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pos"",
                    ""type"": ""Value"",
                    ""id"": ""9d0fb0c0-a01e-4ba5-9f94-d608beb65955"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LClick"",
                    ""type"": ""Button"",
                    ""id"": ""c4b0cf7b-02b0-4aca-8384-d9324b21168b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Scroll"",
                    ""type"": ""Value"",
                    ""id"": ""39db0ca3-eeec-4ddf-b1b9-3d766fea1cfb"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""0d67091d-d853-4f74-92a3-cc08d3f1766d"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": ""Normalize(min=-1,max=1)"",
                    ""groups"": """",
                    ""action"": ""Zoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""48344a7d-446e-4ee9-8876-7f751223cf6c"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pan"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3699c10f-b279-4f06-b591-4ff87e4c831d"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""df445125-e6c8-4eee-bcc5-79b2d3cb3291"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DeltaPos"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a622b2e8-5355-4db8-a88c-cae7e89ecd2c"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard&Mouse"",
                    ""action"": ""CrlPressed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""81a2a355-df9f-4292-90e1-091579d62e1f"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard&Mouse"",
                    ""action"": ""Pos"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""793f0ddc-1a4d-4840-9ecb-2fbc39059587"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""70be37bb-92b9-430c-8dd5-a16d82a81dcc"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Scroll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""ObjectGroup"",
            ""id"": ""a3e9804c-ba85-4fed-a1d1-578fe82bb87e"",
            ""actions"": [
                {
                    ""name"": ""CrlPressed"",
                    ""type"": ""Value"",
                    ""id"": ""aa4ab0fd-a926-45b6-af3f-f8a018c411d4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pos"",
                    ""type"": ""Value"",
                    ""id"": ""ac7c8b37-098f-44ba-9013-f1e1835a0cb2"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DeltaPos"",
                    ""type"": ""Value"",
                    ""id"": ""692dcaf4-0a1b-4333-890a-878ca856fabe"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LClick"",
                    ""type"": ""Button"",
                    ""id"": ""434a6b86-c3c0-49ff-bb37-43957d13ca7d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MClick"",
                    ""type"": ""Button"",
                    ""id"": ""29d3a435-fd3f-49a4-a34c-40a5041e230f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""18a188c9-c5d5-41dd-ba6e-1b1b3ec92df1"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard&Mouse"",
                    ""action"": ""CrlPressed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""374a8cff-90f7-4236-8ba3-c7f2aa93eef1"",
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
                    ""id"": ""8081f7be-5619-4db1-abae-3a84c77510df"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""25abd274-a8d8-41ec-909f-5a0129b04459"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DeltaPos"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ad441153-eb84-4f1b-bdb1-cea3c6464529"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard&Mouse"",
                    ""action"": ""Pos"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""KeyBoard&Mouse"",
            ""bindingGroup"": ""KeyBoard&Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // CameraController
        m_CameraController = asset.FindActionMap("CameraController", throwIfNotFound: true);
        m_CameraController_Zoom = m_CameraController.FindAction("Zoom", throwIfNotFound: true);
        m_CameraController_CrlPressed = m_CameraController.FindAction("CrlPressed", throwIfNotFound: true);
        m_CameraController_Pan = m_CameraController.FindAction("Pan", throwIfNotFound: true);
        m_CameraController_Rotate = m_CameraController.FindAction("Rotate", throwIfNotFound: true);
        m_CameraController_DeltaPos = m_CameraController.FindAction("DeltaPos", throwIfNotFound: true);
        m_CameraController_Pos = m_CameraController.FindAction("Pos", throwIfNotFound: true);
        m_CameraController_LClick = m_CameraController.FindAction("LClick", throwIfNotFound: true);
        m_CameraController_Scroll = m_CameraController.FindAction("Scroll", throwIfNotFound: true);
        // ObjectGroup
        m_ObjectGroup = asset.FindActionMap("ObjectGroup", throwIfNotFound: true);
        m_ObjectGroup_CrlPressed = m_ObjectGroup.FindAction("CrlPressed", throwIfNotFound: true);
        m_ObjectGroup_Pos = m_ObjectGroup.FindAction("Pos", throwIfNotFound: true);
        m_ObjectGroup_DeltaPos = m_ObjectGroup.FindAction("DeltaPos", throwIfNotFound: true);
        m_ObjectGroup_LClick = m_ObjectGroup.FindAction("LClick", throwIfNotFound: true);
        m_ObjectGroup_MClick = m_ObjectGroup.FindAction("MClick", throwIfNotFound: true);
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

    // CameraController
    private readonly InputActionMap m_CameraController;
    private ICameraControllerActions m_CameraControllerActionsCallbackInterface;
    private readonly InputAction m_CameraController_Zoom;
    private readonly InputAction m_CameraController_CrlPressed;
    private readonly InputAction m_CameraController_Pan;
    private readonly InputAction m_CameraController_Rotate;
    private readonly InputAction m_CameraController_DeltaPos;
    private readonly InputAction m_CameraController_Pos;
    private readonly InputAction m_CameraController_LClick;
    private readonly InputAction m_CameraController_Scroll;
    public struct CameraControllerActions
    {
        private @InputController m_Wrapper;
        public CameraControllerActions(@InputController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Zoom => m_Wrapper.m_CameraController_Zoom;
        public InputAction @CrlPressed => m_Wrapper.m_CameraController_CrlPressed;
        public InputAction @Pan => m_Wrapper.m_CameraController_Pan;
        public InputAction @Rotate => m_Wrapper.m_CameraController_Rotate;
        public InputAction @DeltaPos => m_Wrapper.m_CameraController_DeltaPos;
        public InputAction @Pos => m_Wrapper.m_CameraController_Pos;
        public InputAction @LClick => m_Wrapper.m_CameraController_LClick;
        public InputAction @Scroll => m_Wrapper.m_CameraController_Scroll;
        public InputActionMap Get() { return m_Wrapper.m_CameraController; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CameraControllerActions set) { return set.Get(); }
        public void SetCallbacks(ICameraControllerActions instance)
        {
            if (m_Wrapper.m_CameraControllerActionsCallbackInterface != null)
            {
                @Zoom.started -= m_Wrapper.m_CameraControllerActionsCallbackInterface.OnZoom;
                @Zoom.performed -= m_Wrapper.m_CameraControllerActionsCallbackInterface.OnZoom;
                @Zoom.canceled -= m_Wrapper.m_CameraControllerActionsCallbackInterface.OnZoom;
                @CrlPressed.started -= m_Wrapper.m_CameraControllerActionsCallbackInterface.OnCrlPressed;
                @CrlPressed.performed -= m_Wrapper.m_CameraControllerActionsCallbackInterface.OnCrlPressed;
                @CrlPressed.canceled -= m_Wrapper.m_CameraControllerActionsCallbackInterface.OnCrlPressed;
                @Pan.started -= m_Wrapper.m_CameraControllerActionsCallbackInterface.OnPan;
                @Pan.performed -= m_Wrapper.m_CameraControllerActionsCallbackInterface.OnPan;
                @Pan.canceled -= m_Wrapper.m_CameraControllerActionsCallbackInterface.OnPan;
                @Rotate.started -= m_Wrapper.m_CameraControllerActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_CameraControllerActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_CameraControllerActionsCallbackInterface.OnRotate;
                @DeltaPos.started -= m_Wrapper.m_CameraControllerActionsCallbackInterface.OnDeltaPos;
                @DeltaPos.performed -= m_Wrapper.m_CameraControllerActionsCallbackInterface.OnDeltaPos;
                @DeltaPos.canceled -= m_Wrapper.m_CameraControllerActionsCallbackInterface.OnDeltaPos;
                @Pos.started -= m_Wrapper.m_CameraControllerActionsCallbackInterface.OnPos;
                @Pos.performed -= m_Wrapper.m_CameraControllerActionsCallbackInterface.OnPos;
                @Pos.canceled -= m_Wrapper.m_CameraControllerActionsCallbackInterface.OnPos;
                @LClick.started -= m_Wrapper.m_CameraControllerActionsCallbackInterface.OnLClick;
                @LClick.performed -= m_Wrapper.m_CameraControllerActionsCallbackInterface.OnLClick;
                @LClick.canceled -= m_Wrapper.m_CameraControllerActionsCallbackInterface.OnLClick;
                @Scroll.started -= m_Wrapper.m_CameraControllerActionsCallbackInterface.OnScroll;
                @Scroll.performed -= m_Wrapper.m_CameraControllerActionsCallbackInterface.OnScroll;
                @Scroll.canceled -= m_Wrapper.m_CameraControllerActionsCallbackInterface.OnScroll;
            }
            m_Wrapper.m_CameraControllerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Zoom.started += instance.OnZoom;
                @Zoom.performed += instance.OnZoom;
                @Zoom.canceled += instance.OnZoom;
                @CrlPressed.started += instance.OnCrlPressed;
                @CrlPressed.performed += instance.OnCrlPressed;
                @CrlPressed.canceled += instance.OnCrlPressed;
                @Pan.started += instance.OnPan;
                @Pan.performed += instance.OnPan;
                @Pan.canceled += instance.OnPan;
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
                @DeltaPos.started += instance.OnDeltaPos;
                @DeltaPos.performed += instance.OnDeltaPos;
                @DeltaPos.canceled += instance.OnDeltaPos;
                @Pos.started += instance.OnPos;
                @Pos.performed += instance.OnPos;
                @Pos.canceled += instance.OnPos;
                @LClick.started += instance.OnLClick;
                @LClick.performed += instance.OnLClick;
                @LClick.canceled += instance.OnLClick;
                @Scroll.started += instance.OnScroll;
                @Scroll.performed += instance.OnScroll;
                @Scroll.canceled += instance.OnScroll;
            }
        }
    }
    public CameraControllerActions @CameraController => new CameraControllerActions(this);

    // ObjectGroup
    private readonly InputActionMap m_ObjectGroup;
    private IObjectGroupActions m_ObjectGroupActionsCallbackInterface;
    private readonly InputAction m_ObjectGroup_CrlPressed;
    private readonly InputAction m_ObjectGroup_Pos;
    private readonly InputAction m_ObjectGroup_DeltaPos;
    private readonly InputAction m_ObjectGroup_LClick;
    private readonly InputAction m_ObjectGroup_MClick;
    public struct ObjectGroupActions
    {
        private @InputController m_Wrapper;
        public ObjectGroupActions(@InputController wrapper) { m_Wrapper = wrapper; }
        public InputAction @CrlPressed => m_Wrapper.m_ObjectGroup_CrlPressed;
        public InputAction @Pos => m_Wrapper.m_ObjectGroup_Pos;
        public InputAction @DeltaPos => m_Wrapper.m_ObjectGroup_DeltaPos;
        public InputAction @LClick => m_Wrapper.m_ObjectGroup_LClick;
        public InputAction @MClick => m_Wrapper.m_ObjectGroup_MClick;
        public InputActionMap Get() { return m_Wrapper.m_ObjectGroup; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ObjectGroupActions set) { return set.Get(); }
        public void SetCallbacks(IObjectGroupActions instance)
        {
            if (m_Wrapper.m_ObjectGroupActionsCallbackInterface != null)
            {
                @CrlPressed.started -= m_Wrapper.m_ObjectGroupActionsCallbackInterface.OnCrlPressed;
                @CrlPressed.performed -= m_Wrapper.m_ObjectGroupActionsCallbackInterface.OnCrlPressed;
                @CrlPressed.canceled -= m_Wrapper.m_ObjectGroupActionsCallbackInterface.OnCrlPressed;
                @Pos.started -= m_Wrapper.m_ObjectGroupActionsCallbackInterface.OnPos;
                @Pos.performed -= m_Wrapper.m_ObjectGroupActionsCallbackInterface.OnPos;
                @Pos.canceled -= m_Wrapper.m_ObjectGroupActionsCallbackInterface.OnPos;
                @DeltaPos.started -= m_Wrapper.m_ObjectGroupActionsCallbackInterface.OnDeltaPos;
                @DeltaPos.performed -= m_Wrapper.m_ObjectGroupActionsCallbackInterface.OnDeltaPos;
                @DeltaPos.canceled -= m_Wrapper.m_ObjectGroupActionsCallbackInterface.OnDeltaPos;
                @LClick.started -= m_Wrapper.m_ObjectGroupActionsCallbackInterface.OnLClick;
                @LClick.performed -= m_Wrapper.m_ObjectGroupActionsCallbackInterface.OnLClick;
                @LClick.canceled -= m_Wrapper.m_ObjectGroupActionsCallbackInterface.OnLClick;
                @MClick.started -= m_Wrapper.m_ObjectGroupActionsCallbackInterface.OnMClick;
                @MClick.performed -= m_Wrapper.m_ObjectGroupActionsCallbackInterface.OnMClick;
                @MClick.canceled -= m_Wrapper.m_ObjectGroupActionsCallbackInterface.OnMClick;
            }
            m_Wrapper.m_ObjectGroupActionsCallbackInterface = instance;
            if (instance != null)
            {
                @CrlPressed.started += instance.OnCrlPressed;
                @CrlPressed.performed += instance.OnCrlPressed;
                @CrlPressed.canceled += instance.OnCrlPressed;
                @Pos.started += instance.OnPos;
                @Pos.performed += instance.OnPos;
                @Pos.canceled += instance.OnPos;
                @DeltaPos.started += instance.OnDeltaPos;
                @DeltaPos.performed += instance.OnDeltaPos;
                @DeltaPos.canceled += instance.OnDeltaPos;
                @LClick.started += instance.OnLClick;
                @LClick.performed += instance.OnLClick;
                @LClick.canceled += instance.OnLClick;
                @MClick.started += instance.OnMClick;
                @MClick.performed += instance.OnMClick;
                @MClick.canceled += instance.OnMClick;
            }
        }
    }
    public ObjectGroupActions @ObjectGroup => new ObjectGroupActions(this);
    private int m_KeyBoardMouseSchemeIndex = -1;
    public InputControlScheme KeyBoardMouseScheme
    {
        get
        {
            if (m_KeyBoardMouseSchemeIndex == -1) m_KeyBoardMouseSchemeIndex = asset.FindControlSchemeIndex("KeyBoard&Mouse");
            return asset.controlSchemes[m_KeyBoardMouseSchemeIndex];
        }
    }
    public interface ICameraControllerActions
    {
        void OnZoom(InputAction.CallbackContext context);
        void OnCrlPressed(InputAction.CallbackContext context);
        void OnPan(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
        void OnDeltaPos(InputAction.CallbackContext context);
        void OnPos(InputAction.CallbackContext context);
        void OnLClick(InputAction.CallbackContext context);
        void OnScroll(InputAction.CallbackContext context);
    }
    public interface IObjectGroupActions
    {
        void OnCrlPressed(InputAction.CallbackContext context);
        void OnPos(InputAction.CallbackContext context);
        void OnDeltaPos(InputAction.CallbackContext context);
        void OnLClick(InputAction.CallbackContext context);
        void OnMClick(InputAction.CallbackContext context);
    }
}
