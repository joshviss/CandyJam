using UnityEngine;
using System.Collections;

public class Level2Gate : MonoBehaviour {

	Candle candle1;
	Candle candle2;
	Candle candle3;
	Candle candle4;

	int state;

	// Use this for initialization
	void Start () {
		candle1 = GameObject.Find ("Candle1").GetComponent<Candle> ();
		candle2 = GameObject.Find ("Candle2").GetComponent<Candle> ();
		candle3 = GameObject.Find ("Candle3").GetComponent<Candle> ();
		candle4 = GameObject.Find ("Candle4").GetComponent<Candle> ();

		state = 0;
	}
	
	// Update is called once per frame
	void Update () {
		switch (state) {
		case 0:
			if (candle3.isLit) {
				state = 1;
			}
			break;
		case 1:
			if (candle1.isLit) {
				state = 2;
			}
			break;
		case 2:
			if (candle2.isLit) {
				state = 3;
			}
			break;
		case 3:
			if (candle4.isLit) {
				Destroy(gameObject);
			}
			break;
		default:
			break;
		}

		if (candle1.isLit && candle2.isLit && candle3.isLit && candle4.isLit) {
			clearLights();
		}
	}

	void clearLights() {
		candle1.isLit = false;
		candle2.isLit = false;
		candle3.isLit = false;
		candle4.isLit = false;
	}
}
