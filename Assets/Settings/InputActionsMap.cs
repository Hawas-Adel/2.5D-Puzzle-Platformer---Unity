// GENERATED AUTOMATICALLY FROM 'Assets/Settings/InputActionsMap.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputActionsMap : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputActionsMap()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActionsMap"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""e2b6e65e-c8d7-45c8-8178-a822d8163a83"",
            ""actions"": [
                {
                    ""name"": ""Movment"",
                    ""type"": ""Value"",
                    ""id"": ""d0590724-5ab6-4122-acde-0e302184b0ec"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""d6943b5e-fb56-452d-aeeb-943d4380e526"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis (A/D Keys)"",
                    ""id"": ""9055ddc8-bc0d-4a3a-bc69-08089e27e77f"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movment"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""b8651256-39a7-439a-a8d8-7bead04c992f"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movment"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""82163976-0660-478f-88a0-8909aed2d75d"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movment"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis (Arrows)"",
                    ""id"": ""f998a136-43f9-4304-b875-2cdac4e8d696"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movment"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""1ee27d81-7507-4f09-9fac-b0ad366141b4"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movment"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""a0f48018-4a21-477a-94e5-64598d40ce85"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movment"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""f4dec732-c0c0-4db6-990b-15caf8726524"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Pointer"",
            ""id"": ""aba3c7a0-8f1e-4929-9b6e-35dba4c5544d"",
            ""actions"": [
                {
                    ""name"": ""Position"",
                    ""type"": ""Value"",
                    ""id"": ""f4a0c827-715c-4860-bd8b-e87d90228db9"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Click"",
                    ""type"": ""Button"",
                    ""id"": ""e9b58671-2114-45d8-822d-678d2c9ad6a9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d9d6b51b-e86e-401d-bced-1364261d9be2"",
                    ""path"": ""<Pointer>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Position"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ff91bd5d-959e-4575-b918-e119bf6e8bbc"",
                    ""path"": ""<Pointer>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Movment = m_Player.FindAction("Movment", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        // Pointer
        m_Pointer = asset.FindActionMap("Pointer", throwIfNotFound: true);
        m_Pointer_Position = m_Pointer.FindAction("Position", throwIfNotFound: true);
        m_Pointer_Click = m_Pointer.FindAction("Click", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Movment;
    private readonly InputAction m_Player_Jump;
    public struct PlayerActions
    {
        private @InputActionsMap m_Wrapper;
        public PlayerActions(@InputActionsMap wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movment => m_Wrapper.m_Player_Movment;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Movment.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovment;
                @Movment.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovment;
                @Movment.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovment;
                @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movment.started += instance.OnMovment;
                @Movment.performed += instance.OnMovment;
                @Movment.canceled += instance.OnMovment;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // Pointer
    private readonly InputActionMap m_Pointer;
    private IPointerActions m_PointerActionsCallbackInterface;
    private readonly InputAction m_Pointer_Position;
    private readonly InputAction m_Pointer_Click;
    public struct PointerActions
    {
        private @InputActionsMap m_Wrapper;
        public PointerActions(@InputActionsMap wrapper) { m_Wrapper = wrapper; }
        public InputAction @Position => m_Wrapper.m_Pointer_Position;
        public InputAction @Click => m_Wrapper.m_Pointer_Click;
        public InputActionMap Get() { return m_Wrapper.m_Pointer; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PointerActions set) { return set.Get(); }
        public void SetCallbacks(IPointerActions instance)
        {
            if (m_Wrapper.m_PointerActionsCallbackInterface != null)
            {
                @Position.started -= m_Wrapper.m_PointerActionsCallbackInterface.OnPosition;
                @Position.performed -= m_Wrapper.m_PointerActionsCallbackInterface.OnPosition;
                @Position.canceled -= m_Wrapper.m_PointerActionsCallbackInterface.OnPosition;
                @Click.started -= m_Wrapper.m_PointerActionsCallbackInterface.OnClick;
                @Click.performed -= m_Wrapper.m_PointerActionsCallbackInterface.OnClick;
                @Click.canceled -= m_Wrapper.m_PointerActionsCallbackInterface.OnClick;
            }
            m_Wrapper.m_PointerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Position.started += instance.OnPosition;
                @Position.performed += instance.OnPosition;
                @Position.canceled += instance.OnPosition;
                @Click.started += instance.OnClick;
                @Click.performed += instance.OnClick;
                @Click.canceled += instance.OnClick;
            }
        }
    }
    public PointerActions @Pointer => new PointerActions(this);
    public interface IPlayerActions
    {
        void OnMovment(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
    }
    public interface IPointerActions
    {
        void OnPosition(InputAction.CallbackContext context);
        void OnClick(InputAction.CallbackContext context);
    }
}
