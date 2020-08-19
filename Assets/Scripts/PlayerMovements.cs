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

    private Vector3 velocity = Vector3.zero;

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position);

        currentVector = topCenterPoint.transform.position - bottomCenterPoint.transform.position;
        if ( IsPushingLeft() ) {
            leftReactor.AddForce(currentVector * reactorForce * Time.deltaTime);
        }
        if ( IsPushingRight() ) {
            rightReactor.AddForce(currentVector * reactorForce * Time.deltaTime);
        }
    

        Flip(rb.velocity.x);

        float characterVelocity = Mathf.Abs(rb.velocity.x);
	
        animator.SetFloat("Speed", characterVelocity);
    }

    static bool IsPushingRight() {
        return Input.GetKey("right");
    }

    static bool IsPushingLeft() {
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
