using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	void OnCollisionEnter(Collision other){
		GameObject collidedWith = other.gameObject;

		if (collidedWith.tag == "Character") {
			Destroy(gameObject);
		}

	}

}
