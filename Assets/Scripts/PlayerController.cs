// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/PlayerActionsControl.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerController : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerController()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerActionsControl"",
    ""maps"": [
        {
            ""name"": ""Land"",
            ""id"": ""a64729ca-7a9e-4caa-a4d7-eba3bd6be762"",
            ""actions"": [
                {
                    ""name"": ""Sideways"",
                    ""type"": ""PassThrough"",
                    ""id"": ""07d15d15-44b5-4f9e-9c20-c626ae1632fc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""PassThrough"",
                    ""id"": ""9344ba75-dc07-4329-b2f1-9e4f866aba7f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Egil"",
                    ""type"": ""PassThrough"",
                    ""id"": ""6427f762-2552-4afb-8694-7b6002417061"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""ad8fa50e-783f-4706-9cd5-96bc2a7e014b"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sideways"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""9f36b740-80f7-4dc7-8159-1d675d3dfe64"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sideways"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""a1b4c711-f800-4bfb-a50b-666db7e98776"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sideways"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""53200d3e-24f0-4e21-abc8-01cd9eb703df"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0549e828-599f-4a32-ad57-da6b2fa61ba7"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Egil"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Land
        m_Land = asset.FindActionMap("Land", throwIfNotFound: true);
        m_Land_Sideways = m_Land.FindAction("Sideways", throwIfNotFound: true);
        m_Land_Jump = m_Land.FindAction("Jump", throwIfNotFound: true);
        m_Land_Egil = m_Land.FindAction("Egil", throwIfNotFound: true);
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

    // Land
    private readonly InputActionMap m_Land;
    private ILandActions m_LandActionsCallbackInterface;
    private readonly InputAction m_Land_Sideways;
    private readonly InputAction m_Land_Jump;
    private readonly InputAction m_Land_Egil;
    public struct LandActions
    {
        private @PlayerController m_Wrapper;
        public LandActions(@PlayerController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Sideways => m_Wrapper.m_Land_Sideways;
        public InputAction @Jump => m_Wrapper.m_Land_Jump;
        public InputAction @Egil => m_Wrapper.m_Land_Egil;
        public InputActionMap Get() { return m_Wrapper.m_Land; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(LandActions set) { return set.Get(); }
        public void SetCallbacks(ILandActions instance)
        {
            if (m_Wrapper.m_LandActionsCallbackInterface != null)
            {
                @Sideways.started -= m_Wrapper.m_LandActionsCallbackInterface.OnSideways;
                @Sideways.performed -= m_Wrapper.m_LandActionsCallbackInterface.OnSideways;
                @Sideways.canceled -= m_Wrapper.m_LandActionsCallbackInterface.OnSideways;
                @Jump.started -= m_Wrapper.m_LandActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_LandActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_LandActionsCallbackInterface.OnJump;
                @Egil.started -= m_Wrapper.m_LandActionsCallbackInterface.OnEgil;
                @Egil.performed -= m_Wrapper.m_LandActionsCallbackInterface.OnEgil;
                @Egil.canceled -= m_Wrapper.m_LandActionsCallbackInterface.OnEgil;
            }
            m_Wrapper.m_LandActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Sideways.started += instance.OnSideways;
                @Sideways.performed += instance.OnSideways;
                @Sideways.canceled += instance.OnSideways;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Egil.started += instance.OnEgil;
                @Egil.performed += instance.OnEgil;
                @Egil.canceled += instance.OnEgil;
            }
        }
    }
    public LandActions @Land => new LandActions(this);
    public interface ILandActions
    {
        void OnSideways(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnEgil(InputAction.CallbackContext context);
    }
}
