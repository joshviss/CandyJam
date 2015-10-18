using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour {

	AudioSource song;
	float volume = 0f;

	// Use this for initialization
	void Start () {
		song = GetComponent<AudioSource> ();
		FadeIn ();
		song.Play ();
	}

	void FadeIn(){
		while (volume < 1f) {
			volume += 0.1f * Time.deltaTime;
			song.volume = volume;
		}
	}
}
