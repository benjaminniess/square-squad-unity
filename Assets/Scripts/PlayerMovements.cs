using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMovements : MonoBehaviour
{
    public float reactorForce;
    public float maxSpeed;
    public float forceLimit;
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
        float speedAttenuation = 1 - ( speed / maxSpeed );
        
        if ( speedAttenuation < 0 ) {
            //Debug.Log(speedAttenuation);
            speedAttenuation = 0;
        }

        if ( speed < maxSpeed ) {
            
        }

        float speedPercentage = speed * 100 / maxSpeed;
        
        if ( rightReactorLevel > 0 ) {
            torqueLevel += rightReactorLevel;

            float totalForceRight = reactorForce * Time.deltaTime * rightReactorLevel;
            
            
            if ( totalForceRight > forceLimit ) {
                totalForceRight = forceLimit;
            }

            
            totalForceRight = totalForceRight / speedPercentage;
            
            bottomCenterPoint.AddForce(currentVector * totalForceRight);
            
        } else if ( rightReactorLevel < 0 ) {
            rb.AddTorque(Time.deltaTime * rightReactorLevel * 600);
        }

        if ( leftReactorLevel > 0 ) {
            torqueLevel -= leftReactorLevel;
            float totalForceLeft = reactorForce * Time.deltaTime * leftReactorLevel;
            
            if ( totalForceLeft > forceLimit ) {
                totalForceLeft = forceLimit;
            }
            totalForceLeft = totalForceLeft / speedPercentage;
            bottomCenterPoint.AddForce(currentVector * totalForceLeft);
        } else if ( leftReactorLevel < 0 ) {
            rb.AddTorque(Time.deltaTime * -leftReactorLevel * 600);
        }

        
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
