using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour 
{
	// VARIABLES

	[Header("Movement Variables")]
	public float movementSpeed = 12.0f;
	public float jumpForce = 12.0f;

	[Header("Jump Checks")]
	public LayerMask whatIsGround;
	public Transform groundCheck;

	public static int levelCount = 0;
	public Sprite[] playerSprites;

	private float fallMultiplier = 2.5f;
	private float horizontalInput;

	private bool jumpRequest;
	private bool isOnTheGround = true;
	private float groundCheckRadius = 0f;
	private float lowJumpMultiplier = 2f;

	private bool isLookingLeft = false;

	private Rigidbody2D rb;
	private Animator animator;

	// EXECUTION FUNCTIONS

	private void Awake() {
		rb = gameObject.GetComponent<Rigidbody2D> ();
		this.GetComponent<SpriteRenderer> ().sprite = playerSprites [levelCount];
	}

	private void Update () 
	{
		GetInput ();
		UpdateAnimations ();
	}

	private void FixedUpdate() {
		JumpHandler ();
		MovementHandler ();
	}

	// METHODS

	#region Movement Methods

	private void GetInput()
	{
		horizontalInput = Input.GetAxis ("Horizontal") * movementSpeed;

		// Jump Movement Request
		if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
			if(this.isOnTheGround == true)
				jumpRequest = true;
	}

	private void MovementHandler() 
	{
		rb.velocity = new Vector2 (horizontalInput, rb.velocity.y);

		if (jumpRequest == true)
		{
			rb.AddForce (Vector2.up * jumpForce * Time.fixedDeltaTime, ForceMode2D.Impulse);
			jumpRequest = false;
		}
	}

	private void JumpHandler()
	{
		// Check if groundCheck if touching the ground
		this.isOnTheGround = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);

		// If I am falling (Therefore, vertical speed is negative)
		if(rb.velocity.y < 0)
			// Make gravity value higher so that my falling speed is more realistic
			rb.gravityScale = fallMultiplier;

		// If I am going up (Therefore, vertical speed is positive) and I don't want to jump a lot
		else if (rb.velocity.y > 0 && !(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)))
			// Make gravity value slightly higher, so that I don't go very high
			rb.gravityScale = lowJumpMultiplier;

		// If I am going up, but I actually want to jump high
		else
			// Make gravity value normal, so that i jump normally
			rb.gravityScale = 1;
	}

	#endregion

	private void UpdateAnimations()
	{
		// Determine the direction that the Player is facing
		if (rb.velocity.x > 0.1f)
			this.isLookingLeft = false;
		else if (rb.velocity.x < -0.1f)
			this.isLookingLeft = true;

		// Rotate the Player depending on the direction
		// they're facing at the moment
		if (this.isLookingLeft)
			this.transform.rotation = Quaternion.LookRotation (Vector3.back);
		else
			this.transform.rotation = Quaternion.LookRotation (Vector3.forward);
	}
}
