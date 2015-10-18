using UnityEngine;
using System.Collections;

public class FinalDoor : MonoBehaviour {

	bool atDoor = false;

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.UpArrow)) {
			if (Character.S.keyCount > 0 && atDoor){
				Application.LoadLevel ("_Scene_Title");
			}
		}
	}

	void OnTriggerEnter(Collider other){
		GameObject collidedWith = other.gameObject;

		if (collidedWith.tag == "Character") {
			atDoor = true;
		}
	}

	void OnTriggerExit(Collider other){
		GameObject collidedWith = other.gameObject;
		
		if (collidedWith.tag == "Character") {
			atDoor = false;
		}
	}
}
