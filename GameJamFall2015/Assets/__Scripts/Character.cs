using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	float speedX = 4.0f;
	float speedJump = 8.0f;
	float speedLadder = 4.0f;

	bool ________________________________;
	
	Rigidbody rigid;
	bool jumping;
	bool hitWall;
	int groundPhysicsLayerMask;
	int health = 20;

	int keyCount = 0;

	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody> ();
		groundPhysicsLayerMask = LayerMask.GetMask ("Ground");
	}
	
	// FixedUpdate is called once per physics update
	void FixedUpdate () {
		Vector3 vel = rigid.velocity;

		/*
		Vector3 bodyLoc = transform.position;
		Debug.DrawRay (bodyLoc, transform.right * 0.3f);
		hitWall = (Physics.Raycast (bodyLoc, transform.right, 0.3f, groundPhysicsLayerMask)
		           || Physics.Raycast (bodyLoc + Vector3.up * 0.3f, transform.right, 0.3f, groundPhysicsLayerMask)
		           || Physics.Raycast (bodyLoc + Vector3.down * 0.3f, transform.right, 0.3f, groundPhysicsLayerMask));
		*/

		// Left and Right Movement
		if (Input.GetKey (KeyCode.LeftArrow) && !Input.GetKey (KeyCode.RightArrow) && !hitWall) {
			vel.x = -speedX;
		} else if (Input.GetKey (KeyCode.RightArrow) && !Input.GetKey (KeyCode.LeftArrow) && !hitWall) {
			vel.x = speedX;
		} else {
			vel.x = 0;
		}

		// Jumping
		if (Input.GetKeyDown (KeyCode.Space) && !jumping) {
			vel.y = speedJump;
			jumping = true;
		}

		rigid.velocity = vel;
	}

	void OnCollisionEnter(Collision other){
		GameObject collidedWith = other.gameObject;
		
		if (collidedWith.tag == "Ground") {
			jumping = false;
		} else if (collidedWith.tag == "Key") {
			++keyCount;
			Destroy (collidedWith);
		}
	}

}

