using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerMovements : MonoBehaviour
{
    private float speed = 19;
    private float acceleration = 750;
    float deceleration = 700;
    private Vector2 velocity;

    PlayerController controls;

    public string upTouch;
    public string leftTouch;
    public string rightTouch;
    public string downTouch;

    private bool upButton = false;
    private bool downButton = false;
    private bool leftButton = false;
    private bool rightButton = false;
    float ControllerMove;

    void Awake() {
        controls = new PlayerController();
        controls.Gameplay.Button2.performed += ctx => upButton = true;
        controls.Gameplay.Button2.canceled += ctx => upButton = false;
        controls.Gameplay.JoystickRight.performed += ctx => rightButton = true;
        controls.Gameplay.JoystickRight.canceled += ctx => rightButton = false;
        controls.Gameplay.JoystickLeft.performed += ctx => leftButton = true;
        controls.Gameplay.JoystickLeft.canceled += ctx => leftButton = false;
    }

    void OnEnable() {
        controls.Gameplay.Enable();
    }

    void OnDisable() {
        controls.Gameplay.Enable();
    }

    void Start() {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    void Update() {
        if ( getHorizontalAxe() != 0 ) {
            velocity.x = Mathf.MoveTowards(velocity.x, speed * getHorizontalAxe(), acceleration * Time.deltaTime);
        } else {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, deceleration * Time.deltaTime);
        }

        if ( getVerticalAxe() != 0 ) {
            velocity.y = Mathf.MoveTowards(velocity.y, speed * getVerticalAxe(), acceleration * Time.deltaTime);
        } else {
            velocity.y = Mathf.MoveTowards(velocity.y, 0, deceleration * Time.deltaTime);
        }

        transform.Translate(velocity * Time.deltaTime);
    }

    float getReactorstate() {
        if ( Input.GetKey(upTouch) == true ) {
            return 1f;
        }

        if ( upButton == true ) {
            return 1f;
        }

        return 0f;
    }

    float getHorizontalAxe() {
        if ( Input.GetKey(leftTouch) == true ) {
            return -1f;
        }

        if ( Input.GetKey(rightTouch) == true ) {
            return 1f;
        }

        return 0f;
    }

    float getVerticalAxe() {
        if ( Input.GetKey(upTouch) == true ) {
            return 1f;
        }

        if ( Input.GetKey(downTouch) == true ) {
            return -1f;
        }

        return 0f;
    }
}
