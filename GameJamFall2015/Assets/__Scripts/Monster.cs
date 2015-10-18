using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour {

	static public Monster S; // Singleton
	SpriteRenderer spRend;
	float speed = 1.5f;
	Vector3 charPos;
	public Sprite spR, spL;
	public bool awake;
	public GameObject fire, torches;

	// Use this for initialization
	void Start () {
		S = this;
		spRend = GetComponent<SpriteRenderer> ();
		awake = false;
	}

	void Warp(){
		if (awake) {
			charPos = Character.S.transform.position;
		}
	}

	void Update(){
		if (awake) {
			Vector3 charPos = Character.S.transform.position;
			Vector3 newPos = new Vector3 (charPos.x, charPos.y + 1f, 0);
		
			if (charPos.x - transform.position.x >= 0) {
				spRend.sprite = spR;
			} else {
				spRend.sprite = spL;
			}
		
			transform.position = Vector3.MoveTowards (transform.position, newPos, speed * Time.deltaTime);
	
		}
	}

	void OnTriggerEnter(Collider other){
		GameObject collidedWith = other.gameObject;

		if (collidedWith.tag == "Character") {
			awake = true;
			
			Destroy(torches);
			fire.SetActive(true);
		}
	}
}
