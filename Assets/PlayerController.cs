// GENERATED AUTOMATICALLY FROM 'Assets/PlayerController.inputactions'

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
                    ""name"": ""Button2"",
                    ""type"": ""Button"",
                    ""id"": ""555265ce-c9c6-4019-9f37-baca7bbda882"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""JoystickRight"",
                    ""type"": ""Button"",
                    ""id"": ""e18422d9-974d-4d57-bf8a-fbe029a300ed"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""JoystickLeft"",
                    ""type"": ""Button"",
                    ""id"": ""0fc4bc6b-462e-4883-b321-7e7dcbecfb63"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""caeeb7be-7133-4536-8e9c-7c7ee7c1be67"",
                    ""path"": ""<HID::Unknown Joy-Con (L)>/button2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Button2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""79246ec1-2b85-4094-8f58-ac7d4b4fba26"",
                    ""path"": ""<HID::Unknown Joy-Con (L)>/hat/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JoystickRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e42055ad-ec93-44cc-bcef-08b07f16496e"",
                    ""path"": ""<HID::Unknown Joy-Con (L)>/hat/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JoystickLeft"",
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
        m_Gameplay_Button2 = m_Gameplay.FindAction("Button2", throwIfNotFound: true);
        m_Gameplay_JoystickRight = m_Gameplay.FindAction("JoystickRight", throwIfNotFound: true);
        m_Gameplay_JoystickLeft = m_Gameplay.FindAction("JoystickLeft", throwIfNotFound: true);
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
    private readonly InputAction m_Gameplay_Button2;
    private readonly InputAction m_Gameplay_JoystickRight;
    private readonly InputAction m_Gameplay_JoystickLeft;
    public struct GameplayActions
    {
        private @PlayerController m_Wrapper;
        public GameplayActions(@PlayerController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Button2 => m_Wrapper.m_Gameplay_Button2;
        public InputAction @JoystickRight => m_Wrapper.m_Gameplay_JoystickRight;
        public InputAction @JoystickLeft => m_Wrapper.m_Gameplay_JoystickLeft;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Button2.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnButton2;
                @Button2.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnButton2;
                @Button2.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnButton2;
                @JoystickRight.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJoystickRight;
                @JoystickRight.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJoystickRight;
                @JoystickRight.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJoystickRight;
                @JoystickLeft.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJoystickLeft;
                @JoystickLeft.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJoystickLeft;
                @JoystickLeft.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJoystickLeft;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Button2.started += instance.OnButton2;
                @Button2.performed += instance.OnButton2;
                @Button2.canceled += instance.OnButton2;
                @JoystickRight.started += instance.OnJoystickRight;
                @JoystickRight.performed += instance.OnJoystickRight;
                @JoystickRight.canceled += instance.OnJoystickRight;
                @JoystickLeft.started += instance.OnJoystickLeft;
                @JoystickLeft.performed += instance.OnJoystickLeft;
                @JoystickLeft.canceled += instance.OnJoystickLeft;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnButton2(InputAction.CallbackContext context);
        void OnJoystickRight(InputAction.CallbackContext context);
        void OnJoystickLeft(InputAction.CallbackContext context);
    }
}
