using UnityEngine;
using System.Collections;

public class DestroyMonster : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		GameObject collidedWith = other.gameObject;

		if (collidedWith.tag == "Ghost") {
			print("what");
			Monster.S.scream.Stop ();
			Destroy(collidedWith);
		}
	}

	void OnCollisionEnter(Collision other) {
		GameObject collidedWith = other.gameObject;

		if (collidedWith.tag == "Ghost") {
			print("why");
			Monster.S.scream.Stop();
			Destroy(collidedWith);
		}
	}
}
