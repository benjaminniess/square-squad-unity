using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMovements : MonoBehaviour
{
    public float reactorForce;
    public Joystick leftJoystick;
    public Joystick rightJoystick;
    public Rigidbody2D rb;
    public GameObject topCenterPoint;
    public Rigidbody2D bottomCenterPoint;

    private Vector2 currentVector;
    private Vector3 lastPosition = Vector3.zero;
    private float speed;
    private float rotationSpeed;
    private float rotationLast = 0;
    private float rotationDelta;

    void Start() {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    void Update()
    {
        // Speed calculation
        speed = (transform.position - lastPosition).magnitude;
        lastPosition = transform.position;

        // Rotation calculation
        float currentRotation = transform.rotation.eulerAngles.z;
        if ( currentRotation > 180 ) {
            currentRotation = - (360 - currentRotation );
        }

        // Rotation delta calculation
        rotationDelta = currentRotation - rotationLast;
        rotationLast = currentRotation;
        rotationDelta = rotationDelta < 0 ? -rotationDelta : rotationDelta;

        currentVector = ( topCenterPoint.transform.position - bottomCenterPoint.transform.position  ).normalized;

        float rightReactorLevel = getRightReactorLevel();
        float leftReactorLevel = getLeftReactorLevel();

        if ( rightReactorLevel == 0 && leftReactorLevel == 0 ) {
            // No joystick touched?
        }
        
        float torqueLevel = 0;
        if ( rightReactorLevel > 0 ) {
            torqueLevel += rightReactorLevel;
            bottomCenterPoint.AddForce(currentVector * reactorForce * Time.deltaTime * rightReactorLevel);
        } else if ( rightReactorLevel < 0 ) {
            rb.AddTorque(Time.deltaTime * rightReactorLevel * 600);
        }

        if ( leftReactorLevel > 0 ) {
            torqueLevel -= leftReactorLevel;
            bottomCenterPoint.AddForce(currentVector * reactorForce * Time.deltaTime * leftReactorLevel);
        } else if ( leftReactorLevel < 0 ) {
            rb.AddTorque(Time.deltaTime * -leftReactorLevel * 600);
        }

        Debug.Log(speed);
        rb.AddTorque(torqueLevel * Time.deltaTime * 300);
    }

    float getRightReactorLevel() {
        if ( Input.GetKey("right") == true ) {
            return 1f;
        }
        return rightJoystick.Vertical;
    }

    float getLeftReactorLevel() {  
        if ( Input.GetKey("left") == true ) {
            return 1f;
        }
        return leftJoystick.Vertical;
    }
}
