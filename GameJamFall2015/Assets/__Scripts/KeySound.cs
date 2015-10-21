using UnityEngine;
using System.Collections;

public class KeySound : MonoBehaviour {

	AudioSource chime;

	// Use this for initialization
	void Start () {
		chime = GetComponent<AudioSource> ();
		chime.playOnAwake = false;
	}
	
	void OnCollisionEnter(){
		chime.Play ();
	}
}
