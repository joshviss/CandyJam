using UnityEngine;
using System.Collections;

public class EnablePlatform : MonoBehaviour {

	BoxCollider bc;
	SpriteRenderer spRend;

	// Use this for initialization
	void Start () {
		bc = GetComponent<BoxCollider> ();
		spRend = GetComponent<SpriteRenderer> ();

		bc.enabled = false;
		spRend.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Monster.S.awake) {
			bc.enabled = true;
			spRend.enabled = true;
		}
	}
}
