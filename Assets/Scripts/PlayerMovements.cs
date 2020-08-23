using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMovements : MonoBehaviour
{
    public float reactorForce;

    private bool isGrounded;

    public Transform groundCheckLeft;
    public Transform groundCheckRight;

    public Rigidbody2D rightReactor;
    public Rigidbody2D leftReactor;

    public Rigidbody2D rb;

    public GameObject topCenterPoint;
    public GameObject bottomCenterPoint;
    public Vector2 currentVectorLeft;
    public Vector2 currentVectorRight;

    

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

        isGrounded = Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position);        

        currentVectorRight = ( topCenterPoint.transform.position - groundCheckRight.transform.position ).normalized;
        currentVectorLeft = ( topCenterPoint.transform.position - groundCheckLeft.transform.position ).normalized;
        
        rightReactor.AddForce(currentVectorRight * reactorForce * Time.deltaTime * getRightReactorLevel());
        leftReactor.AddForce(currentVectorLeft * reactorForce * Time.deltaTime * getLeftReactorLevel());
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
