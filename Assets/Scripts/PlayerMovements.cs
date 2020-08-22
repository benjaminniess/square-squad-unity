using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    public float reactorForce;

    private bool isGrounded;

    public Transform groundCheckLeft;
    public Transform groundCheckRight;

    public Rigidbody2D rb;
    public Rigidbody2D rightReactor;
    public Rigidbody2D leftReactor;

    public GameObject topCenterPoint;
    public GameObject bottomCenterPoint;
    public Vector2 currentVector;

    private Vector2 resetPos;

    private Vector3 velocity = Vector3.zero;

    void Start() {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        Debug.developerConsoleVisible = true;
    }
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position);

        if (Input.touchCount > 2 || Input.GetKey("up")) {
            resetPos = new Vector2(-98.69f,3.63f );
            rb.transform.position = resetPos;
            rb.rotation = 0f;
        }

        currentVector = topCenterPoint.transform.position - bottomCenterPoint.transform.position;
        
        leftReactor.AddForce(currentVector * reactorForce * Time.deltaTime * getLeftReactorLevel());
        rightReactor.AddForce(currentVector * reactorForce * Time.deltaTime * getRightReactorLevel());
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
