using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour {

	public Vector3 destination;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider other) {
		GameObject collidedWith = other.gameObject;
		
		if (collidedWith.tag == "Character") {
			if (Input.GetKeyDown(KeyCode.UpArrow)) {
				Character.S.transform.position = destination;
			}
		}
	}
}
