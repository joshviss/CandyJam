using UnityEngine;
using System.Collections;

public class Candle : MonoBehaviour {
	public bool isLit = false;
	public float candleBurnTimeCap = 100.0f;
	public float candleBurnRemainTime = 0.0f;
	public GameObject candleFlame;

	// Use this for initialization
	void Start () {
		//candleFlame = GameObject.Find("CandleFlame").GetComponent<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
		/*Being able to set candles life time
		if (isLit) {
			if (candleBurnRemainTime > 0.0f) {
				candleBurnRemainTime -= Time.deltaTime;
			} else {
				candleBurnRemainTime = 0.0f;
				isLit = false;
			}
		}
		*/
	}

	public void disableCandle() {
		isLit = false;
		candleFlame.SetActive(false);
	}

	/*
	public bool flameEnabled() {
		if (isLit == true) {

		}
		return true;

		return false;
	}
	*/

	void OnTriggerStay(Collider other) {
		GameObject collidedWith = other.gameObject;
		
		if (collidedWith.tag == "Character") {
			if (Input.GetKeyDown(KeyCode.S) && Character.S.hasTorch) {
				isLit = true;
				candleFlame.SetActive(true);
				//candleBurnRemainTime = candleBurnTimeCap;
			}
		}
	}
}
