using UnityEngine;
using System.Collections;

public class StickSound : MonoBehaviour {

	AudioSource pickUp;

	// Use this for initialization
	void Start () {
		pickUp = GetComponent<AudioSource> ();
		pickUp.playOnAwake = false;
	}
	
	void OnCollisionEnter(){
		pickUp.Play ();
	}
}
