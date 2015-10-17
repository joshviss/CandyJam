using UnityEngine;
using System.Collections;

public class LockedDoor : MonoBehaviour {

	void OnCollisionEnter(Collision other){
		GameObject collidedWith = other.gameObject;

		if (collidedWith.tag == "Character") {
			if (Character.S.keyCount != 0){
				Character.S.keyCount--;
				Destroy(gameObject);
			}
		}


	}

}
