using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Insanity : MonoBehaviour {

	Image[] spatter;

	// Use this for initialization
	void Start () {
		spatter = GetComponentsInChildren<Image> ();

		for (int i = 0; i < 4; i++){
			spatter[i].enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		int hp = Character.S.health;
		int cap = Character.S.healthCap;

		if (hp < cap * 0.2f) {
			spatter [3].enabled = true;
		} else if (hp < cap * 0.4f) {
			spatter [2].enabled = true;
		} else if (hp < cap * 0.6f) {
			spatter [1].enabled = true;
		} else if (hp < cap * 0.8f) {
			spatter [0].enabled = true;
		} else {
			for (int i = 0; i < 4; i++) {
				spatter [i].enabled = false;
			}
		}
	}
}
