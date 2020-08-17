using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
	public float moveSpeed;
	public float bouceForce;
	public bool isGrounded;
	public Transform groundCheckLeft;
	public Transform groundCheckRight;
	public Rigidbody2D rb;
	private Vector3 velocity = Vector3.zero;

	//public Animator animator;
	//public SpriteRenderer spriteRenderer;

    void FixedUpdate()
    {
    	isGrounded = Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position);
        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        MovePlayer(horizontalMovement);

        Flip(rb.velocity.x);

        //animator.SetBool("IsUp", !isGrounded);
    }

	void MovePlayer(float _horizontalMovement) {
		Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
		rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

		if ( isGrounded == true ) {
			rb.AddForce(new Vector2(0f, bouceForce));
		}
	}

	void Flip(float _velocity) {
		if ( _velocity > 0.1f ) {
			//spriteRenderer.flipX = false;
		} else if ( _velocity < -0.1f ) {
			//spriteRenderer.flipX = true;
		}
	}
}
