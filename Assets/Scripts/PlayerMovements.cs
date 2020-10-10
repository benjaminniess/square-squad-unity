using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerMovements : MonoBehaviour
{
    public float reactorForce;
    
    public Rigidbody2D rb;
    public GameObject topCenterPoint;
    public Rigidbody2D bottomCenterPoint;

    private Vector2 currentVector;
    private Vector3 lastPosition = Vector3.zero;
    private float speed;
    private float timeCount = 0.0f;

    PlayerController controls;

    public string gazTouch;
    public string leftTouch;
    public string rightTouch;

    private bool gazButton = false;
    private bool leftButton = false;
    private bool rightButton = false;
    float ControllerMove;

    void Awake() {
        controls = new PlayerController();
        controls.Gameplay.Button2.performed += ctx => gazButton = true;
        controls.Gameplay.Button2.canceled += ctx => gazButton = false;
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

    void Update()
    {
        // Speed calculation
        speed = 10 * (transform.position - lastPosition).magnitude;
        lastPosition = transform.position;

        currentVector = ( topCenterPoint.transform.position - bottomCenterPoint.transform.position  ).normalized;

        if ( getRightState() == 0 && getLeftState() == 0 ) {
            rb.transform.rotation = Quaternion.Slerp(rb.transform.rotation, Quaternion.Euler(0, 0, 0), timeCount);
            timeCount = timeCount + Time.deltaTime / 100;
        }
        
        float torqueLevel = 0;

        if ( getLeftState() > 0 ) {
            torqueLevel -= 2;
        } 
        if ( getRightState() > 0 ) {
            torqueLevel += 2;
        }

        if ( getReactorstate() > 0 ) {
            bottomCenterPoint.AddForce(currentVector * reactorForce * Time.deltaTime);
        }

        Quaternion q = Quaternion.AngleAxis(torqueLevel * 40 * Time.deltaTime, Vector3.forward);
        rb.transform.rotation *= q;
    }

    float getReactorstate() {
        if ( Input.GetKey(gazTouch) == true ) {
            return 1f;
        }

        if ( gazButton == true ) {
            return 1f;
        }

        return 0f;
    }

    float getLeftState() {
        if ( Input.GetKey(leftTouch) == true ) {
            return 1f;
        }

        if (  leftButton == true ) {
            return 1f;
        }

        return 0f;
    }

    float getRightState() {
        if ( Input.GetKey(rightTouch) == true ) {
            return 1f;
        }

        if (  rightButton == true ) {
            return 1f;
        }

        return 0f;
    }
}
