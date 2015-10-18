using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Title : MonoBehaviour {

	Text start;
	AudioSource song;
	float volume = 1f;

	// Use this for initialization
	void Start () {
		start = GetComponentInChildren<Text> ();
		song = GetComponent<AudioSource> ();
		song.Play (0);
		StartCoroutine ("Wait");
	}

	// Update is called once per frame
	void Update(){
		if (Input.anyKeyDown) {
			FadeOut();
			Application.LoadLevel ("_Scene_Main");
		}
	}

	void FadeOut(){
		while (song.volume > 0f) {
			volume -= 0.1f * Time.deltaTime;
			song.volume = volume;
		}
	}

	IEnumerator Wait(){
		start.enabled = false;
		yield return new WaitForSeconds (2);
		start.enabled = true;
	}
}
