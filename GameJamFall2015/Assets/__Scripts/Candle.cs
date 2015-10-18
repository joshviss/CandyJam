using UnityEngine;
using System.Collections;

public class Candle : MonoBehaviour {
	public bool isLit = false;
	public float candleBurnTimeCap = 100.0f;
	public float candleBurnRemainTime = 0.0f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (isLit) {
			if (candleBurnRemainTime > 0.0f) {
				candleBurnRemainTime -= Time.deltaTime;
			} else {
				candleBurnRemainTime = 0.0f;
				isLit = false;
			}
		}
	}

	void OnTriggerStay(Collider other) {
		GameObject collidedWith = other.gameObject;
		
		if (collidedWith.tag == "Character") {
			if (Input.GetKeyDown(KeyCode.E) && Character.S.hasTorch) {
				isLit = true;
				candleBurnRemainTime = candleBurnTimeCap;
			}
		}
	}
}
