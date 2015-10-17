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
	bool grounded;
	int groundPhysicsLayerMask;
<<<<<<< HEAD
	int health = 30;
	int damage = 1;
	public int keyCount = 0;
	public Canvas gameOver;
=======

	int health = 20;

	int keyCount = 0;
	bool onLadder = false;
>>>>>>> origin/master

	// Use this for initialization
	void Start () {
		S = this;
		rigid = GetComponent<Rigidbody> ();
		groundPhysicsLayerMask = LayerMask.GetMask ("Ground");
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

		// Left and Right Movement
		if (Input.GetKey (KeyCode.LeftArrow) && !Input.GetKey (KeyCode.RightArrow)) {
			vel.x = -speedX;
		} else if (Input.GetKey (KeyCode.RightArrow) && !Input.GetKey (KeyCode.LeftArrow)) {
			vel.x = speedX;
		} else {
			vel.x = 0;
		}

		// Jumping
		if (Input.GetKeyDown (KeyCode.Space) && grounded) {
			vel.y = speedJump;
		}

		rigid.velocity = vel;
	}

	void OnCollisionEnter(Collision other){
		GameObject collidedWith = other.gameObject;
		
<<<<<<< HEAD
		if (collidedWith.tag == "Ground" || collidedWith.tag == "Boxes" || collidedWith.tag == "Table") {
			grounded = true;
		} 
	}

	void OnCollisionExit(Collision other){
		GameObject collidedWith = other.gameObject;

		if (collidedWith.tag == "Ground" || collidedWith.tag == "Boxes" || collidedWith.tag == "Table") {
			grounded = false;
=======
		if (collidedWith.tag == "Ground") {
			jumping = false;
		} else if (collidedWith.tag == "Key") {
			++keyCount;
			Destroy (collidedWith);
		} else if (collidedWith.tag == "Ladder") {
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
			if (Input.GetKeyDown(KeyCode.UpArrow))
			{
				onLadder = true;
				rigid.useGravity = false;
				Vector3 vel = rigid.velocity;
				vel.y = speedLadder;
				rigid.velocity = vel;
			}
>>>>>>> origin/master
		}
	}

}

