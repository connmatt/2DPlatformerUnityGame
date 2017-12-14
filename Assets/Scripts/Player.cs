using UnityEngine;
using System.Collections;

public class Player : Character {

	private static Player instance;
	
	private float health;

	
	public static Player Instance
	{
		get
		{
			if(instance == null)
			{
				instance = GameObject.FindObjectOfType<Player>();
			}
			return instance;
		}
	}
	private Rigidbody2D myRigidbody;

	[SerializeField]
	private Transform[] groundPoints;
	
	[SerializeField]
	private float groundRadius;
	
	[SerializeField]
	private LayerMask whatIsGround;
	
	private bool isGrounded;
	
	private bool jump;
	
	[SerializeField]
	private bool airControl;
	
	[SerializeField]
	private float jumpforce;
	
	private Vector2 startPos;
	
	public Rigidbody2D MyRigidbody { get; set;}
	
	// Use this for initialization
	public override void Start () 
	{
		base.Start ();
		startPos = transform.position;
		health = 3;
		myRigidbody = GetComponent<Rigidbody2D>();
		
	}
	
	void Update()
	{
		if (transform.position.y <= -14f)
		{
			MyRigidbody.velocity = Vector2.zero;
			transform.position = startPos;
		}
		
		HandleInput ();
		
	}
	// Update is called once per frame
	void FixedUpdate () 
	{
		float horizontal = Input.GetAxis("Horizontal");
		
		isGrounded = IsGrounded();
		
		HandleMovement(horizontal);
		
		Flip (horizontal);
		
		HandleAttack();
		
		HandleLayers();
		
		ResetValues();
		
		
		
	}
	
	private void HandleMovement(float horizontal)
	{
		if(myRigidbody.velocity.y < 0 )
		{
			myAnimator.SetBool ("land", true);
		}
		
		if(!this.myAnimator.GetCurrentAnimatorStateInfo(0).IsTag ("Attack") && (isGrounded || airControl))
		{
			myRigidbody.velocity = new Vector2(horizontal * movementSpeed,myRigidbody.velocity.y);
		}
		
		if(isGrounded && jump)
		{
			isGrounded = false;
			myRigidbody.AddForce (new Vector2(0, jumpforce));
			myAnimator.SetTrigger("jump");
			jump = true;
		}
		
		myAnimator.SetFloat("speed", Mathf.Abs(horizontal));
		
		
	}
	
	private void HandleAttack()
	{
		if(attack && !this.myAnimator.GetCurrentAnimatorStateInfo(0).IsTag ("Attack"))
		{
			myAnimator.SetTrigger("attack");
			myRigidbody.velocity = Vector2.zero;
		}
	}
	
	private void HandleInput()
	{
		if(Input.GetKeyDown (KeyCode.LeftShift))
		{
			attack = true;
		}
		
		if(Input.GetKeyDown (KeyCode.Space))
		{
			jump = true;
		}
	}
	
	private void Flip(float horizontal)
	{
		if(horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
		{
			ChangeDirection ();
		}
	}
	
	private void ResetValues()
	{
		attack = false;
		jump = false;
	}
	
	private bool IsGrounded()
	{
		if(myRigidbody.velocity.y <= 0)
		{
			foreach (Transform point in groundPoints)
			{
				Collider2D[] colliders = Physics2D.OverlapCircleAll (point.position,groundRadius, whatIsGround);
				
				for (int i=0; i < colliders.Length; i++)
				{
					if (colliders[i].gameObject != gameObject)
					{
						myAnimator.ResetTrigger("jump");
						myAnimator.SetBool("land", false);
						return true;
						
					}
				}
			}
		}
		return false;
	} 
	
	private void HandleLayers()
	{
		if(!isGrounded)
		{
			myAnimator.SetLayerWeight (1,1);
		}
		else
		{
			myAnimator.SetLayerWeight(1,0);
		}
	}
	
	void OnCollisionEnter2D(Collision2D coll)
	{
		if(coll.gameObject.tag == "Enemy")
		{
			health --;
			if (health < 0)
			{
				health = 0;
				Destroy(gameObject);
			}
			coll.gameObject.GetComponent<Bat>().RecieveDamage(1);
		}
	}
	
	
	/*public override void ThrowKnife(int value)
	{
		if(!isGrounded && value == 1 || isGrounded && value == 0)
		{
			
		}
	}*/
}
