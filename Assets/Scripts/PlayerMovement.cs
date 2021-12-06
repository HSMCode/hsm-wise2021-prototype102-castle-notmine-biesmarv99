using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

	[SerializeField] float jumpForce = 10f;
	public float forwardForce = 1.5f;

	Rigidbody2D myBody;
	bool canJump;
	private float xPosition;


	// Use this for initialization
	void Start()
	{
		myBody = GetComponent<Rigidbody2D>();
		xPosition = transform.position.x;
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space)) {
			Jump();
		}
	}

	public void Jump()
	{
		// make sure player can only jump when touching ground
		// if player is behind x-axis starting point, let them catch up
		if (canJump)
		{
			canJump = false;
			if (transform.position.x <= xPosition) {
				myBody.velocity = new Vector2(forwardForce, jumpForce);
			} else {
				myBody.velocity = new Vector2(0, jumpForce);
			}
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		canJump = true;
	}
}