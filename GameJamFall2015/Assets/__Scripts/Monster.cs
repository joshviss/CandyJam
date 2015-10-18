using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour {

	SpriteRenderer spRend;
	bool awake = false;
	float speed = 1.5f;
	public Sprite spR, spL;

	// Use this for initialization
	void Start () {
		spRend = GetComponent<SpriteRenderer> ();
	}

	// Update is called once per frame
	void Update(){
		if (awake) {
			Vector3 charPos = Character.S.transform.position;
			Vector3 newPos = new Vector3(charPos.x, transform.position.y, 0);
			float step = speed * Time.deltaTime;

			if (charPos.x - transform.position.x >= 0){
				spRend.sprite = spR;
			} else{
				spRend.sprite = spL;
			}

			transform.position = Vector3.MoveTowards(transform.position, newPos, step);
		}
	}

	void OnTriggerEnter(Collider other){
		GameObject collidedWith = other.gameObject;

		if (collidedWith.tag == "Character") {
			awake = true;
		}
	}
}
