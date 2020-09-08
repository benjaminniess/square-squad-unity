using UnityEngine;
using Mirror;
using UnityEngine.UI;
using TMPro;

public class PlayerMovements : NetworkBehaviour
{
    public float reactorForce;
    public float maxSpeed;
    
    public Rigidbody2D rb;
    public GameObject topCenterPoint;
    public Rigidbody2D bottomCenterPoint;

    private Vector2 currentVector;
    private Vector3 lastPosition = Vector3.zero;
    private float speed;
    private float rotationSpeed;
    private float rotationLast = 0;
    private float maxRotation = 30f;
    private float rotationDelta;
    private float timeCount = 0.0f;
    private float rightReactorLevel;
    private float leftReactorLevel;

    void Start() {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    [Client]
    void Update()
    {
        if ( ! hasAuthority ) {
            return;
        }


        float rightReactorLevel = getRightReactorLevel();
        float leftReactorLevel = getLeftReactorLevel();

        CmdMove(rightReactorLevel, leftReactorLevel);
    }

    [Command]
    private void CmdMove(float rightReactorLevel, float leftReactorLevel) {
       // Validation here

       RpcMove(rightReactorLevel, leftReactorLevel);
    }

    [ClientRpc]
    private void RpcMove(float rightReactorLevel, float leftReactorLevel) {
        // Speed calculation
        speed = 10 * (transform.position - lastPosition).magnitude;
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


        if ( rightReactorLevel == 0 && leftReactorLevel == 0 ) {
            rb.transform.rotation = Quaternion.Slerp(rb.transform.rotation, Quaternion.Euler(0, 0, 0), timeCount);
            timeCount = timeCount + Time.deltaTime / 100;

        }
        
        float torqueLevel = 0;
        
        // Limit vertical up speed
        if ( rb.velocity.y > maxSpeed ) {
            //rb.velocity = Vector3.Normalize(rb.velocity) * Mathf.Sqrt(50);
            //rb.velocity = new Vector2( rb.velocity.x, maxSpeed );
        }
        
        if ( rightReactorLevel > 0 ) {
            torqueLevel += rightReactorLevel;
            bottomCenterPoint.AddForce(currentVector * reactorForce * Time.deltaTime * rightReactorLevel);
        } 
        if ( leftReactorLevel > 0 ) {
            torqueLevel -= leftReactorLevel;
            bottomCenterPoint.AddForce(currentVector * reactorForce * Time.deltaTime * leftReactorLevel);
        }

        // MAX ROTATION LIMIT
        if ( currentRotation > maxRotation && leftReactorLevel >= 0 ) {
           //rb.transform.rotation = Quaternion.Euler(0f, 0f, maxRotation - 2);
        } else if ( currentRotation < -maxRotation && rightReactorLevel >= 0 ) {
           //rb.transform.rotation = Quaternion.Euler(0f, 0f, -maxRotation + 2);
        } 

        // INVERSE ROTATION WHEN JOYSTICK GOES DOWN
        if ( rightReactorLevel < 0 ) {
            //rb.AddTorque(Time.deltaTime * rightReactorLevel * 600);
        }
        if ( leftReactorLevel < 0 ) {
            //rb.AddTorque(Time.deltaTime * -leftReactorLevel * 600);
        }

        // Accentuation of retro rotation when angle is too high
        if ( rightReactorLevel > leftReactorLevel && currentRotation < -25 && Mathf.Abs(rb.velocity.x) > 20 ) {
            //torqueLevel *= ( Mathf.Abs(currentRotation) / 10 );
        }
        if ( rightReactorLevel < leftReactorLevel && currentRotation > 25 && Mathf.Abs(rb.velocity.x) > 20 ) {
            //torqueLevel *= ( Mathf.Abs(currentRotation) / 10 );
        }
        
        Quaternion q = Quaternion.AngleAxis(torqueLevel * 70 * Time.deltaTime, Vector3.forward);
        rb.transform.rotation *= q;
    }

    float getRightReactorLevel() {
        if ( Input.GetKey("right") == true ) {
            return 1f;
        }
        int touchCount = Input.touchCount;
        
        if ( touchCount <= 0) {
            return 0f;
        }

        for ( int i = 0; i < touchCount; i++) {
            Touch touch = Input.GetTouch(i);
            Vector2 pos = touch.position;
            if ( pos.x < ( Screen.width / 2 ) ) {
                continue;
            }

            return pos.y / Screen.height;
        }

        return 0f;
    }

    float getLeftReactorLevel() {  
        if ( Input.GetKey("left") == true ) {
            return 1f;
        }

        int touchCount = Input.touchCount;
        
        if ( touchCount <= 0) {
            return 0f;
        }

        for ( int i = 0; i < touchCount; i++) {
            Touch touch = Input.GetTouch(i);
            Vector2 pos = touch.position;

            if ( pos.x > ( Screen.width / 2 ) ) {
                continue;
            }

            return pos.y / Screen.height;
        }

        return 0f;
    }
}
