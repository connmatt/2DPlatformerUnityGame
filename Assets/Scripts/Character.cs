using UnityEngine;
using System.Collections;

public abstract class Character : MonoBehaviour {

	protected Animator myAnimator;
	
	[SerializeField]
	protected float movementSpeed;
	
	[SerializeField]
	protected Transform acidPos;
	
	[SerializeField]
	protected GameObject acidPrefab;
	
	protected bool facingRight;
	
	protected bool attack;
	// Use this for initialization
	public virtual void Start () {
		facingRight = true;
		
		myAnimator = GetComponent<Animator>();
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void ChangeDirection()
	{
		facingRight = !facingRight;
		transform.localScale = new Vector3(transform.localScale.x * -1,1,1);
	}
	
	
}
