using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour {

	void OnCollisionEnter(Collision other){
		GameObject collidedWith = other.gameObject;

		if (collidedWith.tag == "Character") {
			Character.S.keyCount++;
			Destroy (gameObject);
		}
	}
}
