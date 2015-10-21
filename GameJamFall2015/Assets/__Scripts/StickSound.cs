using UnityEngine;
using System.Collections;

public class StickSound : MonoBehaviour {

	AudioSource pickUp;

	// Use this for initialization
	void Awake () {
		pickUp = GetComponent<AudioSource> ();
	}
	
	void OnCollisionEnter(Collision other){
		GameObject collidedWith = other.gameObject;
	
		if (collidedWith.tag == "Character") {
			pickUp.Play ();
		}
	}
}
