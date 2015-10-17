using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Title : MonoBehaviour {

	Text start;

	// Use this for initialization
	void Start () {
		start = GetComponentInChildren<Text> ();
		StartCoroutine ("Wait");
	}

	// Update is called once per frame
	void Update(){
		if (Input.anyKeyDown) {
			Application.LoadLevel ("_Scene_Main_NH");
		}
	}

	IEnumerator Wait(){
		start.enabled = false;
		yield return new WaitForSeconds (1);
		start.enabled = true;
	}
}
