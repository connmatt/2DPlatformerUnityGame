using UnityEngine;
using System.Collections;
[RequireComponent(typeof (Rigidbody2D))]
public class Acid : MonoBehaviour {
	
	[SerializeField]
	private float speed;
	
	private Rigidbody2D myRigidbody;
	
	private Vector2 direction;
	
	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D>();
		Instantiate (gameObject, transform.position, transform.rotation);
	}
	
	void FixedUpdate()
	{
		myRigidbody.velocity = direction * speed;
	}
	// Update is called once per frame
	void Update () {
		
	}
	
	public void Initialize(Vector2 direction)
	{
		this.direction = direction;
		
	}
	
	void OnBecameInvisible()
	{
		Destroy (gameObject);
	}
}
