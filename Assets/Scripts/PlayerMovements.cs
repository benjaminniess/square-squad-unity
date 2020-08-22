using UnityEngine;

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

    private Vector2 resetPos;

    private Vector3 lastPosition = Vector3.zero;
    private float speed;
    private float rotationSpeed;
    private float rotationLast = 0;
    private float rotationDelta;

    void Start() {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        Debug.developerConsoleVisible = true;
    }

    void FixedUpdate()
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

        //Debug.Log(speed);
        //rb.AddTorque(-currentRotation * Time.deltaTime * 600 );
        isGrounded = Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position);

        if (Input.touchCount > 2 || Input.GetKey("up")) {
            resetPos = new Vector2(-98.69f,3.63f );
            transform.position = resetPos;
            //rb.transform.rotation = 0f;
        }

        currentVectorLeft = ( topCenterPoint.transform.position - groundCheckLeft.transform.position ).normalized;
       // Debug.Log(currentVectorLeft);
        currentVectorRight = ( topCenterPoint.transform.position - groundCheckRight.transform.position ).normalized;
        
        leftReactor.AddForce(currentVectorLeft * reactorForce * Time.deltaTime * getLeftReactorLevel());
        rightReactor.AddForce(currentVectorRight * reactorForce * Time.deltaTime * getRightReactorLevel());

        //leftReactor.AddForce(currentVectorLeft * reactorForce * Time.deltaTime * getLeftReactorLevel());
        //leftReactor.AddForce(currentVectorRight * reactorForce * Time.deltaTime * getRightReactorLevel());

        if ( currentRotation > 25 ) {
            //rb.transform.rotation = Quaternion.Euler(new Vector3(0,0,18));
        }
        else if ( currentRotation < -25 ) {
            //rb.transform.rotation = Quaternion.Euler(new Vector3(0,0,-18));
        }
    }

    static float getRightReactorLevel() {
        if ( Input.GetKey("right") == true ) {
            return 1f;
        }


        int touchCount = Input.touchCount;
        if ( touchCount <= 0) {
            return 0f;
        }

        for ( int i = 0; i <= touchCount; i++) {
            Touch touch = Input.GetTouch(i);
            Vector2 pos = touch.position;
            if ( pos.x < ( Screen.width / 2 ) ) {
                continue;
            }

            return pos.y / Screen.height;
        }

        return 0f;
    }

    static float getLeftReactorLevel() {  
        if ( Input.GetKey("left") == true ) {
            return 1f;
        }

        int touchCount = Input.touchCount;
        if ( touchCount <= 0) {
            return 0f;
        }

        for ( int i = 0; i <= touchCount; i++) {
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
