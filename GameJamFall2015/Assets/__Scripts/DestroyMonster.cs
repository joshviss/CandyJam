using UnityEngine;
using System.Collections;

public class DestroyMonster : MonoBehaviour {

	AudioSource song;

	void Start(){
		song = GetComponent<AudioSource> ();
	}

	void OnTriggerEnter(Collider other){
		GameObject collidedWith = other.gameObject;

		if (collidedWith.tag == "Ghost") {
			Destroy(collidedWith);
			song.Stop ();
		}
	}
}
