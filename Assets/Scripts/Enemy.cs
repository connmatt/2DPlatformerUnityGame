using UnityEngine;
using System.Collections;

public class Enemy : Character {

	
	//private IEnemyState currentState;
	
	private float throwTimer;
	private float throwCoolDown = 3;
	private bool canThrow;
	
	// Use this for initialization
	public override void Start () {
		base.Start();
		
	}
	
	// Update is called once per frame
	void Update () {
		//currentState.Execute ();
		
		
	}
	
	public void Move()
	{
		//myAnimator.SetFloat ("speed", 0);
		
		transform.Translate (GetDirection() * (movementSpeed * Time.deltaTime));
	}
	
	public Vector2 GetDirection()
	{
		return facingRight  ? Vector2.right : Vector2.left;
	}
	
	public virtual void ThrowAcid(int value)
	{
		
		throwTimer += Time.deltaTime;
		
		if(facingRight)
			{
				GameObject tmp = (GameObject)Instantiate (acidPrefab, acidPos.position, Quaternion.Euler (new Vector3(0,0,-180)));
				tmp.GetComponent<Acid>().Initialize(Vector2.right);
			}
		else
			{
				GameObject tmp = (GameObject)Instantiate (acidPrefab, acidPos.position, Quaternion.Euler (new Vector3(0,0, 180)));
				tmp.GetComponent<Acid>().Initialize(Vector2.left);
				
			}
		if(throwTimer >= throwCoolDown)
		{
			canThrow = true;
			throwTimer = 0;
		}
		if(canThrow)
		{
			canThrow = false;
			myAnimator.SetTrigger("Throw");
		}
	}
	
}
