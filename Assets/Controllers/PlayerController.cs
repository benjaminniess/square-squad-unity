// GENERATED AUTOMATICALLY FROM 'Assets/Controllers/PlayerController.inputactions'

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
    ""name"": ""PlayerController"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""71df559b-fa6a-4f59-aee4-88301c0876f1"",
            ""actions"": [
                {
                    ""name"": ""UP"",
                    ""type"": ""Button"",
                    ""id"": ""cca69087-39ee-41c7-82b0-b27fd459ca2d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DOWN"",
                    ""type"": ""Button"",
                    ""id"": ""497bc5e9-1463-417f-8d4f-d9a1c6736ba1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LEFT"",
                    ""type"": ""Button"",
                    ""id"": ""886a3633-0949-4bc2-82d7-965ea161d029"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RIGHT"",
                    ""type"": ""Button"",
                    ""id"": ""e9039d69-f68e-45fd-aa19-7e9cf6b7e47a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d9044c2e-26f7-47ef-8086-896d63bb8afa"",
                    ""path"": ""<HID::Unknown Joy-Con (R)>/hat/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UP"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""064477c0-a4cd-4d0e-9c9c-f4b0ea26fafc"",
                    ""path"": ""<HID::Unknown Joy-Con (R)>/hat/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DOWN"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1b0902c0-f06a-431f-91ad-428377040158"",
                    ""path"": ""<HID::Unknown Joy-Con (R)>/hat/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LEFT"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2edf4840-b2ca-4464-a897-aeb98afea1f7"",
                    ""path"": ""<HID::Unknown Joy-Con (R)>/hat/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RIGHT"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_UP = m_Gameplay.FindAction("UP", throwIfNotFound: true);
        m_Gameplay_DOWN = m_Gameplay.FindAction("DOWN", throwIfNotFound: true);
        m_Gameplay_LEFT = m_Gameplay.FindAction("LEFT", throwIfNotFound: true);
        m_Gameplay_RIGHT = m_Gameplay.FindAction("RIGHT", throwIfNotFound: true);
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_UP;
    private readonly InputAction m_Gameplay_DOWN;
    private readonly InputAction m_Gameplay_LEFT;
    private readonly InputAction m_Gameplay_RIGHT;
    public struct GameplayActions
    {
        private @PlayerController m_Wrapper;
        public GameplayActions(@PlayerController wrapper) { m_Wrapper = wrapper; }
        public InputAction @UP => m_Wrapper.m_Gameplay_UP;
        public InputAction @DOWN => m_Wrapper.m_Gameplay_DOWN;
        public InputAction @LEFT => m_Wrapper.m_Gameplay_LEFT;
        public InputAction @RIGHT => m_Wrapper.m_Gameplay_RIGHT;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @UP.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnUP;
                @UP.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnUP;
                @UP.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnUP;
                @DOWN.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDOWN;
                @DOWN.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDOWN;
                @DOWN.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDOWN;
                @LEFT.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLEFT;
                @LEFT.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLEFT;
                @LEFT.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLEFT;
                @RIGHT.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRIGHT;
                @RIGHT.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRIGHT;
                @RIGHT.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRIGHT;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @UP.started += instance.OnUP;
                @UP.performed += instance.OnUP;
                @UP.canceled += instance.OnUP;
                @DOWN.started += instance.OnDOWN;
                @DOWN.performed += instance.OnDOWN;
                @DOWN.canceled += instance.OnDOWN;
                @LEFT.started += instance.OnLEFT;
                @LEFT.performed += instance.OnLEFT;
                @LEFT.canceled += instance.OnLEFT;
                @RIGHT.started += instance.OnRIGHT;
                @RIGHT.performed += instance.OnRIGHT;
                @RIGHT.canceled += instance.OnRIGHT;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnUP(InputAction.CallbackContext context);
        void OnDOWN(InputAction.CallbackContext context);
        void OnLEFT(InputAction.CallbackContext context);
        void OnRIGHT(InputAction.CallbackContext context);
    }
}
