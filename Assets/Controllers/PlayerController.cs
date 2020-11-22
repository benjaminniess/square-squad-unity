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
                    ""name"": ""DASH"",
                    ""type"": ""Button"",
                    ""id"": ""cd77f3a8-80a6-4ef0-b08b-8cd4037f933c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""BONUS"",
                    ""type"": ""Button"",
                    ""id"": ""b442680c-921a-49c4-9b57-198a0b4eb279"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""UP"",
                    ""type"": ""Button"",
                    ""id"": ""ee75d37e-f265-494a-8c0e-0cdeb8305bb8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DOWN"",
                    ""type"": ""Button"",
                    ""id"": ""f869f9b5-0889-44db-a8ba-87b8b3845d83"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LEFT"",
                    ""type"": ""Button"",
                    ""id"": ""5d99a95b-bb94-4d58-a38c-4d5b90bf8f37"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RIGHT"",
                    ""type"": ""Button"",
                    ""id"": ""5b6fa8fd-d5a5-4c8f-9dd6-e6c5f6c3f377"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""START"",
                    ""type"": ""Button"",
                    ""id"": ""51ef5993-8eda-4527-a3c5-4a5e58959092"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""NORTH"",
                    ""type"": ""Button"",
                    ""id"": ""dbf5b879-8881-414a-a139-ad2c6403e0b4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SOUTH"",
                    ""type"": ""Button"",
                    ""id"": ""e3f323e7-0615-43f6-84b6-b64341198660"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""STICK"",
                    ""type"": ""Value"",
                    ""id"": ""f57a727d-2800-4b7c-b3af-9ab25ab8a231"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CLICK"",
                    ""type"": ""Button"",
                    ""id"": ""db6a721d-6758-42de-bd1e-73f6b29b37df"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""POINT"",
                    ""type"": ""Value"",
                    ""id"": ""4c4c06d9-2c54-4921-942a-9df41f672718"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b0f62639-abee-45cb-9564-1b37e725470e"",
                    ""path"": ""<HID::Unknown Joy-Con (L)>/button2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DASH"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""69162d4c-54b9-4c4d-a4c7-e8109d62ece7"",
                    ""path"": ""<HID::Unknown Joy-Con (R)>/button2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DASH"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f0fcc12a-2e3b-4ebc-b3b6-f4ab825eb74a"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DASH"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""51d33ffc-0aa0-405d-9611-b060f689e9bc"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DASH"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e35bc8c3-d724-47b9-bb02-58417b7a2e78"",
                    ""path"": ""<Keyboard>/numpadEnter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DASH"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4be2708d-51de-4fe8-b8e2-8a6bd22a3c2a"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DASH"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""937b3bd1-46a7-4750-a684-4785559e2830"",
                    ""path"": ""<HID::Unknown Joy-Con (L)>/button3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BONUS"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b752c74a-e869-4860-a7c1-81d32e399d58"",
                    ""path"": ""<HID::Unknown Joy-Con (R)>/button3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BONUS"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""951a3471-2c1e-4072-a2c6-fe1cd20661b8"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BONUS"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9969f433-1ebc-4aaf-8fd7-b1fc1815d140"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BONUS"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""665b35ca-822d-4638-98b3-0ea371c74487"",
                    ""path"": ""<HID::Unknown Joy-Con (L)>/hat/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UP"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ebac6101-a122-40f4-93d3-f8a6079be99a"",
                    ""path"": ""<HID::Unknown Joy-Con (L)>/stick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UP"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bc380e89-35bd-4989-8b4f-8586c89bd83a"",
                    ""path"": ""<HID::Unknown Joy-Con (R)>/stick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UP"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8c4c8b50-60ea-45f8-8773-861cba6db516"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UP"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""937e5fa0-c9e4-4ee9-9490-d63cd8e437d4"",
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
                    ""id"": ""42e1e5b6-5ed2-4f10-9a24-286571de2c3b"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UP"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""10157d20-9a85-4eb3-a75a-7c8fd4c94f0f"",
                    ""path"": ""<HID::Unknown Joy-Con (L)>/hat/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DOWN"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e0b70024-9109-41ae-b883-9b8497534d27"",
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
                    ""id"": ""da319b02-ced0-4ebd-b010-a7d7361f10c6"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DOWN"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5b4f05b4-66ae-4b1d-8e44-9c87a45134bd"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DOWN"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""80d8dd7e-de83-4909-8c47-8fb1dce0dbf4"",
                    ""path"": ""<HID::Unknown Joy-Con (L)>/hat/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LEFT"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b7289007-c166-452f-ac92-ba581ad793c6"",
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
                    ""id"": ""5ee1b921-3084-4f64-926a-d8a241ccaa4e"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LEFT"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9c67c3ce-3773-4f60-ad2c-39c3ed6e5622"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LEFT"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""33ead043-ebb0-4841-a4f0-5242a4aec922"",
                    ""path"": ""<HID::Unknown Joy-Con (L)>/hat/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RIGHT"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""114fddf4-ecbd-4d46-b37b-3a726b812d05"",
                    ""path"": ""<HID::Unknown Joy-Con (R)>/hat/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RIGHT"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6d7fe1ca-970a-47d0-8d4a-cc1e621c5e94"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RIGHT"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""25404093-d758-4cc4-bc13-7d3406e41b5e"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RIGHT"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bbb8bece-b0e8-4244-9219-6ffbc7b649b7"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""START"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8d87f268-783b-4743-aaa0-33eeaf84db06"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NORTH"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""301e3e06-d6e4-469d-83a5-d5830a0bf8bb"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NORTH"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""358de730-3198-45b3-8379-39550979612b"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SOUTH"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""70bce616-0952-4f9d-b459-56679d4cfcb0"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SOUTH"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""969e73da-c7e7-4a7d-9859-030dc95228eb"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SOUTH"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2d874682-ecab-4ed3-bb40-880bb056850f"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""STICK"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d64079c2-f182-47d5-81cb-69f4d0740504"",
                    ""path"": ""<Mouse>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CLICK"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7160b4f0-6c86-4024-93c9-f122c26678ce"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""POINT"",
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
        m_Gameplay_DASH = m_Gameplay.FindAction("DASH", throwIfNotFound: true);
        m_Gameplay_BONUS = m_Gameplay.FindAction("BONUS", throwIfNotFound: true);
        m_Gameplay_UP = m_Gameplay.FindAction("UP", throwIfNotFound: true);
        m_Gameplay_DOWN = m_Gameplay.FindAction("DOWN", throwIfNotFound: true);
        m_Gameplay_LEFT = m_Gameplay.FindAction("LEFT", throwIfNotFound: true);
        m_Gameplay_RIGHT = m_Gameplay.FindAction("RIGHT", throwIfNotFound: true);
        m_Gameplay_START = m_Gameplay.FindAction("START", throwIfNotFound: true);
        m_Gameplay_NORTH = m_Gameplay.FindAction("NORTH", throwIfNotFound: true);
        m_Gameplay_SOUTH = m_Gameplay.FindAction("SOUTH", throwIfNotFound: true);
        m_Gameplay_STICK = m_Gameplay.FindAction("STICK", throwIfNotFound: true);
        m_Gameplay_CLICK = m_Gameplay.FindAction("CLICK", throwIfNotFound: true);
        m_Gameplay_POINT = m_Gameplay.FindAction("POINT", throwIfNotFound: true);
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
    private readonly InputAction m_Gameplay_DASH;
    private readonly InputAction m_Gameplay_BONUS;
    private readonly InputAction m_Gameplay_UP;
    private readonly InputAction m_Gameplay_DOWN;
    private readonly InputAction m_Gameplay_LEFT;
    private readonly InputAction m_Gameplay_RIGHT;
    private readonly InputAction m_Gameplay_START;
    private readonly InputAction m_Gameplay_NORTH;
    private readonly InputAction m_Gameplay_SOUTH;
    private readonly InputAction m_Gameplay_STICK;
    private readonly InputAction m_Gameplay_CLICK;
    private readonly InputAction m_Gameplay_POINT;
    public struct GameplayActions
    {
        private @PlayerController m_Wrapper;
        public GameplayActions(@PlayerController wrapper) { m_Wrapper = wrapper; }
        public InputAction @DASH => m_Wrapper.m_Gameplay_DASH;
        public InputAction @BONUS => m_Wrapper.m_Gameplay_BONUS;
        public InputAction @UP => m_Wrapper.m_Gameplay_UP;
        public InputAction @DOWN => m_Wrapper.m_Gameplay_DOWN;
        public InputAction @LEFT => m_Wrapper.m_Gameplay_LEFT;
        public InputAction @RIGHT => m_Wrapper.m_Gameplay_RIGHT;
        public InputAction @START => m_Wrapper.m_Gameplay_START;
        public InputAction @NORTH => m_Wrapper.m_Gameplay_NORTH;
        public InputAction @SOUTH => m_Wrapper.m_Gameplay_SOUTH;
        public InputAction @STICK => m_Wrapper.m_Gameplay_STICK;
        public InputAction @CLICK => m_Wrapper.m_Gameplay_CLICK;
        public InputAction @POINT => m_Wrapper.m_Gameplay_POINT;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @DASH.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDASH;
                @DASH.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDASH;
                @DASH.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDASH;
                @BONUS.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBONUS;
                @BONUS.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBONUS;
                @BONUS.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBONUS;
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
                @START.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSTART;
                @START.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSTART;
                @START.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSTART;
                @NORTH.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnNORTH;
                @NORTH.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnNORTH;
                @NORTH.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnNORTH;
                @SOUTH.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSOUTH;
                @SOUTH.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSOUTH;
                @SOUTH.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSOUTH;
                @STICK.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSTICK;
                @STICK.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSTICK;
                @STICK.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSTICK;
                @CLICK.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCLICK;
                @CLICK.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCLICK;
                @CLICK.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCLICK;
                @POINT.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPOINT;
                @POINT.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPOINT;
                @POINT.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPOINT;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @DASH.started += instance.OnDASH;
                @DASH.performed += instance.OnDASH;
                @DASH.canceled += instance.OnDASH;
                @BONUS.started += instance.OnBONUS;
                @BONUS.performed += instance.OnBONUS;
                @BONUS.canceled += instance.OnBONUS;
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
                @START.started += instance.OnSTART;
                @START.performed += instance.OnSTART;
                @START.canceled += instance.OnSTART;
                @NORTH.started += instance.OnNORTH;
                @NORTH.performed += instance.OnNORTH;
                @NORTH.canceled += instance.OnNORTH;
                @SOUTH.started += instance.OnSOUTH;
                @SOUTH.performed += instance.OnSOUTH;
                @SOUTH.canceled += instance.OnSOUTH;
                @STICK.started += instance.OnSTICK;
                @STICK.performed += instance.OnSTICK;
                @STICK.canceled += instance.OnSTICK;
                @CLICK.started += instance.OnCLICK;
                @CLICK.performed += instance.OnCLICK;
                @CLICK.canceled += instance.OnCLICK;
                @POINT.started += instance.OnPOINT;
                @POINT.performed += instance.OnPOINT;
                @POINT.canceled += instance.OnPOINT;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnDASH(InputAction.CallbackContext context);
        void OnBONUS(InputAction.CallbackContext context);
        void OnUP(InputAction.CallbackContext context);
        void OnDOWN(InputAction.CallbackContext context);
        void OnLEFT(InputAction.CallbackContext context);
        void OnRIGHT(InputAction.CallbackContext context);
        void OnSTART(InputAction.CallbackContext context);
        void OnNORTH(InputAction.CallbackContext context);
        void OnSOUTH(InputAction.CallbackContext context);
        void OnSTICK(InputAction.CallbackContext context);
        void OnCLICK(InputAction.CallbackContext context);
        void OnPOINT(InputAction.CallbackContext context);
    }
}
