using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {

	public string item;
	public int amount;
	public Light keyLight;

	// Use this for initialization
	void Start() {
		if (item == "Key") {
			keyLight = transform.Find("PointLight").GetComponent<Light>();
			keyLight.enabled = false;
		}
	}

	void OnCollisionEnter(Collision other){
		GameObject collidedWith = other.gameObject;

		if (collidedWith.tag == "Character") {
			if (item == "Key")
			{
				Character.S.keyCount += amount;
			}
			else if (item == "Stick")
			{
				Character.S.stickCount += amount;
				Character.S.hasStick = true;
			}
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter(Collider other) {
		GameObject collidedWith = other.gameObject;

		if (collidedWith.tag == "Light") {
			if (item == "Key") {
				keyLight.enabled = true;
			}
		}
	}
}
