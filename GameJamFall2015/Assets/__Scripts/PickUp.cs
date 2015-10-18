using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {

	public string item;
	public int amount;

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
}
