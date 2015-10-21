using UnityEngine;
using System.Collections;

public class KeySound : MonoBehaviour {

	AudioSource chime;

	// Use this for initialization
	void Awake () {
		chime = GetComponent<AudioSource> ();
		chime.playOnAwake = false;
	}
	
	void OnCollisionEnter(Collision other){
		GameObject collidedWith = other.gameObject;

		if (collidedWith.tag == "Character") {
			chime.Play ();
		}
	}
}
