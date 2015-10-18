using UnityEngine;
using System.Collections;

public class WaterDroplet : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		GameObject collidedWith = other.gameObject;

		if (collidedWith.tag == "Torch") {
			collidedWith.GetComponent<Candle>().isLit = false;
		}
	}
}
