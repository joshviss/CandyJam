using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour {

	AudioSource song;

	void Awake(){
		song = GetComponent<AudioSource> ();
	}

	// Use this for initialization
	void Start () {
		song.Play ();
	}

}
