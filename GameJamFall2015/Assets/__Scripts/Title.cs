using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Title : MonoBehaviour {

	static public int lastScene;

	public void NewGame(){
		Application.LoadLevel ("_Scene_Main_JV");
	}

	public void Continue(){
		if (lastScene == 0) {
			Application.LoadLevel ("_Scene_Main_JV");
		} else if (lastScene == 1) {
			Application.LoadLevel ("_Scene_Level0");
		} else if (lastScene == 2) {
			Application.LoadLevel ("_Scene_Level1");
		} else if (lastScene == 3) {
			Application.LoadLevel ("_Scene_Level2");
		}
	}
}
