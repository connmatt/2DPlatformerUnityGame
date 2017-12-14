using UnityEngine;
using System.Collections;

public class Bat : Character {

	[SerializeField]
	private float speed;
	
	private float health;
	
	private Rigidbody2D myRigidbody;
	
	private Vector2 direction;
	
	private bool dirRight = true;
	
	
	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D>();
		health = 5;
	}
	
	void FixedUpdate()
	{
		myRigidbody.velocity = direction * speed;
	}
	// Update is called once per frame
	void Update () {
	
		if(dirRight)
			transform.Translate (Vector2.right*speed*Time.deltaTime);
		else {
			transform.Translate (-Vector2.right*speed*Time.deltaTime);
		}
		
		if(transform.position.x >= 29f){
			dirRight= false;
			ChangeDirection();
			
			
		}
		if(transform.position.x <= -5)
		{
			dirRight=true;
			ChangeDirection();
		}
	}
	
	public void Initialize(Vector2 direction)
	{
		this.direction = direction;
		
	}
	
	public void RecieveDamage(float amount)
	{
		health -= amount;
		if(health <=0)
		{
			Destroy (gameObject);
		}
	}
	
	/*private void Flip(float horizontal)
	{
		if(horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
		{
			ChangeDirection ();
		}
	}*/
	
}