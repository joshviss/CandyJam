using UnityEngine;
using System.Collections;

public class DestroyMonster : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		GameObject collidedWith = other.gameObject;

		if (collidedWith.tag == "Ghost") {
			Monster.S.scream.Stop ();
			Destroy(collidedWith);
		}
	}
}
