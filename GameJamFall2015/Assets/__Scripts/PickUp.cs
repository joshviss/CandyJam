using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {

	public string item;

	void OnCollisionEnter(Collision other){
		GameObject collidedWith = other.gameObject;

		if (collidedWith.tag == "Character") {
			if (item == "Key")
			{
				Character.S.keyCount++;
			}
			else if (item == "Stick")
			{
				Character.S.hasStick = true;
			}
			Destroy (gameObject);
		}
	}
}
