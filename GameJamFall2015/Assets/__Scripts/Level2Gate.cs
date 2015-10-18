using UnityEngine;
using System.Collections;

public class Level2Gate : MonoBehaviour {

	Candle candle1;
	Candle candle2;
	Candle candle3;
	Candle candle4;

	// Use this for initialization
	void Start () {
		candle1 = GameObject.Find ("Candle1").GetComponent<Candle> ();
		candle2 = GameObject.Find ("Candle2").GetComponent<Candle> ();
		candle3 = GameObject.Find ("Candle3").GetComponent<Candle> ();
		candle4 = GameObject.Find ("Candle4").GetComponent<Candle> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (candle3.isLit) {
			if (candle1.isLit) {
				if(candle2.isLit) {
					if (candle4.isLit) {
						Destroy (gameObject);
					}
				}
			}
		}
	}
}
