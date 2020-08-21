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

    public Animator animator;
    public SpriteRenderer spriteRenderer;

    private Vector2 resetPos;

    private Vector3 velocity = Vector3.zero;

    void Start() {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position);

        if (Input.touchCount > 2) {
            resetPos = new Vector2(-98.69f,3.63f );
            rb.transform.position = resetPos;
            rb.rotation = 0f;
        }

        currentVector = topCenterPoint.transform.position - bottomCenterPoint.transform.position;
        if ( IsPushingLeft() ) {
            leftReactor.AddForce(currentVector * reactorForce * Time.deltaTime);
        }
        if ( IsPushingRight() ) {
            rightReactor.AddForce(currentVector * reactorForce * Time.deltaTime);
        }

        if ( Input.GetKey("up") ) {
            Debug.Log("Reset");
            resetPos = new Vector2(-98.69f,3.63f );
            rb.transform.position = resetPos;
            rb.rotation = 0f;
        }
    

        Flip(rb.velocity.x);

        float characterVelocity = Mathf.Abs(rb.velocity.x);
	
        animator.SetFloat("Speed", characterVelocity);
    }

    static bool IsPushingRight() {
        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
            Vector2 pos = touch.position;
            if ( pos.x > ( Screen.width / 2 ) ) {
                return true;
            } else {
                if (Input.touchCount > 1) {
                    Touch touch2 = Input.GetTouch(1);
                    Vector2 pos2 = touch2.position;
                    if ( pos2.x > ( Screen.width / 2 ) ) {
                        return true;
                    } else {
                        return false; 
                    }
                }
            }
        }
        return Input.GetKey("right");
    }

    static bool IsPushingLeft() {
        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
            Vector2 pos = touch.position;
            if ( pos.x < ( Screen.width / 2 ) ) {
                return true;
            } else {
            if (Input.touchCount > 1) {
                Touch touch3 = Input.GetTouch(1);
                Vector2 pos3 = touch3.position;
                if ( pos3.x < ( Screen.width / 2 ) ) {
                    return true;
                } else {
                    return false;
                }
            }
            }
        }
        return Input.GetKey("left");
    }

    void Flip(float _velocity)
    {
        if (_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
        }else if(_velocity < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }
}
