using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {

	public string item;
	public int amount;
	public Light keyLight;
	public AudioClip key, stick;
	
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
				AudioSource.PlayClipAtPoint(key, transform.position);
			}
			else if (item == "Stick")
			{
				Character.S.stickCount += amount;
				Character.S.hasStick = true;
				AudioSource.PlayClipAtPoint(stick, transform.position);
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
