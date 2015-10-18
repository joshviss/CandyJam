using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine ("Wait");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown) {
			Application.LoadLevel ("_Scene_Title");
		}
	}

	IEnumerator Wait(){
		yield return new WaitForSeconds (3);
	}
}
