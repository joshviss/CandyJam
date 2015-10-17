using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum Facing{
	R,	// Right
	L,	// Left
	F	// Front
};

public class Character : MonoBehaviour {

	static public Character S; //Singleton
	float speedX = 2.0f;
	float speedJump = 6f;
	float speedLadder = 1.0f;
	Rigidbody rigid;
	RigidbodyConstraints noRotZ, noRotYZ;
	SpriteRenderer spRend;
	BoxCollider body;
	bool grounded;
	int groundPhysicsLayerMask;
	int ladderLayerMask;
	int health = 15;
	int damage = 1;
	bool onLadder = false;
	bool collideWithLadder = false;
	bool hasTorch = false;
	bool hasStick = false;
	Facing face;
	public int keyCount = 0;
	public Sprite spR, spL, spF, spRT, spLT, spFT, spRS, spLS, spFS;

	// Use this for initialization
	void Start () {
		S = this;
		rigid = GetComponent<Rigidbody> ();
		spRend = GetComponent<SpriteRenderer> ();
		groundPhysicsLayerMask = LayerMask.GetMask ("Ground");
		ladderLayerMask = LayerMask.GetMask ("Ladder");
		body = GetComponent<BoxCollider> ();

		noRotZ = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ;
		noRotYZ = noRotZ | RigidbodyConstraints.FreezePositionY;

		spRend.sprite = spR;
		InvokeRepeating ("DecreaseHealth", 0f, 1f);
	}

	void DecreaseHealth(){
		health -= damage;
		Debug.Log (health);
	}

	void Update(){
		if (health <= 0) {
			Application.LoadLevel ("_Scene_GameOver");
		}
	}

	// FixedUpdate is called once per physics update
	void FixedUpdate () {
		Vector3 vel = rigid.velocity;

		Vector3 loc = transform.position;
		Debug.DrawRay (loc, Vector3.down * 1.25f, Color.blue);
		grounded = (Physics.Raycast (loc, Vector3.down, 1.25f, groundPhysicsLayerMask));

		// Left and Right Movement
		if (Input.GetKey (KeyCode.LeftArrow) && !Input.GetKey (KeyCode.RightArrow)) {
			vel.x = -speedX;
			face = Facing.L;
		} else if (Input.GetKey (KeyCode.RightArrow) && !Input.GetKey (KeyCode.LeftArrow)) {
			vel.x = speedX;
			face = Facing.R;
		} else if (Input.GetKey (KeyCode.DownArrow) && !collideWithLadder) {
			vel.x = 0;
			face = Facing.F;
		} else {
			vel.x = 0;
		}

		// Jumping
		if (Input.GetKeyDown (KeyCode.Space) && grounded && !onLadder) {
			vel.y = speedJump;
		}

		// Grab onto ladder
		if (collideWithLadder) {
			if (Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.DownArrow)) {
				onLadder = true;
			}
		}

		// Movement while on ladder
		if (onLadder) {
			if (Input.GetKey (KeyCode.UpArrow) && !Input.GetKey (KeyCode.DownArrow)) {
				vel.y = speedLadder;
			} else if (Input.GetKey (KeyCode.DownArrow) && !Input.GetKey (KeyCode.UpArrow)) {
				vel.y = -speedLadder;
			} else {
				vel.y = 0;
			}
		}

		// Jumping down ladder
		if (onLadder && Input.GetKeyDown (KeyCode.Space)) {
			onLadder = false;
			rigid.useGravity = true;
		}

		// Set the velocity
		rigid.velocity = vel;

		// Set the sprite in the SpriteRenderer
		if (face == Facing.R) {
			if (hasTorch) {
				spRend.sprite = spRT;
			} else {
				spRend.sprite = spR;
			}
		} else if (face == Facing.L) {
			if (hasTorch) {
				spRend.sprite = spLT;
			} else {
				spRend.sprite = spL;
			}
		} else {
			if (hasTorch) {
				spRend.sprite = spFT;
			} else {
				spRend.sprite = spF;
			}
		}
	}

	void OnTriggerEnter(Collider other){
		GameObject collidedWith = other.gameObject;

		if (collidedWith.tag == "Ladder") {
			collideWithLadder = true;
		} else if (collidedWith.tag == "Light") {
			damage = 0;
		}
	}

	void OnTriggerExit(Collider other){
		GameObject collidedWith = other.gameObject;

		if (collidedWith.tag == "Ladder") {
			collideWithLadder = false;
			rigid.useGravity = true;
			onLadder = false;
		} else if (collidedWith.tag == "Light") {
			damage = 1;
		}
	}
}

