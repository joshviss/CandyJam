using UnityEngine;
using System.Collections;

public class LevelJump : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Alpha0)) {
			Application.LoadLevel("_Scene_Main_JV");
		} else if (Input.GetKeyDown(KeyCode.Alpha1)) {
			Application.LoadLevel("_Scene_Level0");
		} else if (Input.GetKeyDown(KeyCode.Alpha2)) {
			Application.LoadLevel("_Scene_Level1");
		} else if (Input.GetKeyDown(KeyCode.Alpha3)) {
			Application.LoadLevel("_Scene_Level2");
		}
	
	}
}
