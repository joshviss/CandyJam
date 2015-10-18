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
	int damage = 1;
	bool onLadder = false;
	bool collideWithLadder = false;
	bool ignitionEnabled = false;
	Facing face;
	public float stickRemainTime = 0.0f;
	public float stickBurnTimeCap = 5.0f;
	public int health = 15;
	public int healthCap = 15;
	public int keyCount = 0;
	public int stickCount = 0;
	public bool hasTorch = false;
	public bool hasStick = false;
	public Sprite spR, spL, spF, spRT, spLT, spFT, spRS, spLS, spFS;
	public Light stickTorch;

	// Use this for initialization
	void Start () {
		S = this;
		rigid = GetComponent<Rigidbody> ();
		spRend = GetComponent<SpriteRenderer> ();
		groundPhysicsLayerMask = LayerMask.GetMask ("Ground");
		ladderLayerMask = LayerMask.GetMask ("Ladder");
		body = GetComponent<BoxCollider> ();
		stickTorch = transform.Find("Torch").transform.Find("TorchPointLight").GetComponent<Light>();

		noRotZ = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ;
		noRotYZ = noRotZ | RigidbodyConstraints.FreezePositionY;

		spRend.sprite = spR;
		InvokeRepeating ("DecreaseHealth", 0f, 1f);
	}

	void DecreaseHealth(){
		health -= damage;
		Debug.Log(health);
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
		if (Input.GetKeyDown (KeyCode.A) && grounded && !onLadder) {
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
		if (onLadder && Input.GetKeyDown (KeyCode.A)) {
			onLadder = false;
			rigid.useGravity = true;
		}

		// Ignition of stick
		if (Input.GetKeyDown (KeyCode.E)) {
			/*if (hasTorch) { //allows you to turn off torch
				hasTorch = false;
				stickTorch.enabled = false;
			}
			else*/ if (ignitionEnabled && hasStick) {
				hasTorch = true;
				stickTorch.enabled = true;
				stickRemainTime = stickBurnTimeCap;
			}
		}

		if (stickRemainTime >= 0.0f) {
			if (hasTorch){
				stickRemainTime -= Time.deltaTime;
			}
		} else {
			hasTorch = false;
			hasStick = false;
			stickTorch.enabled = false;
		}

		// Damage = 0 if player has torch
		if (hasTorch) {
			damage = 0;
		} else {
			damage = 1;
		}

		// Set the velocity
		rigid.velocity = vel;

		// Set the sprite in the SpriteRenderer
		if (face == Facing.R) {
			if (hasTorch) {
				spRend.sprite = spRT;
			} else if (hasStick){
				spRend.sprite = spRS;
			}else {
				spRend.sprite = spR;
			}
		} else if (face == Facing.L) {
			if (hasTorch) {
				spRend.sprite = spLT;
			} else if (hasStick){
				spRend.sprite = spLS;
			}else {
				spRend.sprite = spL;
			}
		} else {
			if (hasTorch) {
				spRend.sprite = spFT;
			} else if (hasStick){
				spRend.sprite = spFS;
			}else {
				spRend.sprite = spF;
			}
		}
	}

	void OnCollisionEnter(Collision other){
		GameObject collidedWith = other.gameObject;

		if (collidedWith.tag == "Ghost") {
			Application.LoadLevel ("_Scene_GameOver");
		}
	}

	void OnTriggerEnter(Collider other){
		GameObject collidedWith = other.gameObject;

		if (collidedWith.tag == "Ladder") {
			collideWithLadder = true;
		} else if (collidedWith.tag == "Light") {
			//Debug.Log("Light Trigger Enter");
			damage = 0;
			health = 15;
			ignitionEnabled = true;
		}
	}

	void OnTriggerStay(Collider other) {
		GameObject collidedWith = other.gameObject;

		if (collidedWith.tag == "Light") {
			//Debug.Log("Light trigger stay");
			damage = 0;
			health = 15;
			ignitionEnabled = true;
		}
	}

	void OnTriggerExit(Collider other){
		GameObject collidedWith = other.gameObject;

		if (collidedWith.tag == "Ladder") {
			collideWithLadder = false;
			rigid.useGravity = true;
			onLadder = false;
		} else if (collidedWith.tag == "Light") {
			//Debug.Log("Light trigger exit");
			damage = 1;
			ignitionEnabled = false;
		}
	}
}

