using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Character : MonoBehaviour {

	float speedX = 4.0f;
	float speedJump = 8.0f;
	float speedLadder = 4.0f;

	bool ________________________________;

	static public Character S; //Singleton
	Rigidbody rigid;
	RigidbodyConstraints noRotZ, noRotYZ;
	BoxCollider body;
	bool grounded;
	int groundPhysicsLayerMask;
	int health = 30;
	int damage = 1;
	public int keyCount = 0;
	public Canvas gameOver;
	
	bool onLadder = false;
	bool collideWithLadder = false;
	Vector3 ladderStartPosition;

	// Use this for initialization
	void Start () {
		S = this;
		rigid = GetComponent<Rigidbody> ();
		groundPhysicsLayerMask = LayerMask.GetMask ("Ground");
		body = GetComponent<BoxCollider> ();
		gameOver.enabled = false;

		noRotZ = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ;
		noRotYZ = noRotZ | RigidbodyConstraints.FreezePositionY;

		InvokeRepeating ("DecreaseHealth", 0f, 1f);
	}

	void DecreaseHealth(){
		health -= damage;
	}

	void Update(){
		if (health <= 0) {
			gameOver.enabled = true;
			if (Input.anyKeyDown){
				Application.LoadLevel ("_Scene_Main_NH");
			}
		}
	}

	// FixedUpdate is called once per physics update
	void FixedUpdate () {
		Vector3 vel = rigid.velocity;

		Vector3 loc = transform.position;
		Debug.DrawRay (loc, Vector3.down * 0.5f, Color.blue);
		grounded = (Physics.Raycast (loc, Vector3.down, 0.5f, groundPhysicsLayerMask));

		// Left and Right Movement
		if (Input.GetKey (KeyCode.LeftArrow) && !Input.GetKey (KeyCode.RightArrow)) {
			vel.x = -speedX;
		} else if (Input.GetKey (KeyCode.RightArrow) && !Input.GetKey (KeyCode.LeftArrow)) {
			vel.x = speedX;
		} else {
			vel.x = 0;
		}

		// Jumping
		if (Input.GetKeyDown (KeyCode.Space) && (grounded || onLadder)) {
			vel.y = speedJump;
		}

		// Climbing a ladder
		if (collideWithLadder) {
			if (Input.GetKey (KeyCode.UpArrow) && !Input.GetKey (KeyCode.DownArrow)) {
				vel.y = speedLadder;
				onLadder = true;
			} else if (Input.GetKey (KeyCode.DownArrow) && !Input.GetKey (KeyCode.UpArrow)) {
				vel.y = -speedLadder;
				onLadder = true; 
			} else {
				vel.y = 0;
			}
		}

		rigid.velocity = vel;
	}

	void OnCollisionExit(Collision other){
		GameObject collidedWith = other.gameObject;

		if (collidedWith.tag == "Ladder") {
			if (Input.GetKeyDown(KeyCode.UpArrow))
			{
				onLadder = true;
				rigid.useGravity = false;
				Vector3 vel = rigid.velocity;
				vel.y = speedLadder;
				rigid.velocity = vel;
			}
		}
	}

	void OnTriggerEnter(Collider other){
		GameObject collidedWith = other.gameObject;

		if (collidedWith.tag == "Ladder") {
			collideWithLadder = true;
			rigid.useGravity = false;
			ladderStartPosition = transform.position;
			ladderStartPosition.x = other.transform.position.x;
		}
	}

	void OnTriggerExit(Collider other){
		GameObject collidedWith = other.gameObject;

		if (collidedWith.tag == "Ladder") {
			collideWithLadder = false;
			rigid.useGravity = true;
			onLadder = false;
		}
	}
}

