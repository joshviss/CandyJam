using UnityEngine;
using System.Collections;

public class CandlePuzzle : MonoBehaviour {

	public GameObject Key;
	public GameObject Candle1, Candle2, Candle3, Candle4;
	public Candle Candle1Script, Candle2Script, Candle3Script, Candle4Script;
	public int numCandlesLit= 0;
	public int first, second, third, fourth;
	public bool isLit1 = false, isLit2 = false, isLit3 = false, isLit4 = false;

	// Use this for initialization
	void Start () {
		Candle1Script = Candle1.GetComponent<Candle>();
		Candle2Script = Candle2.GetComponent<Candle>();
		Candle3Script = Candle3.GetComponent<Candle>();
		Candle4Script = Candle4.GetComponent<Candle>();
	}
	
	bool checkCandleLit(int candleNum) {
		if (candleNum == 1) {
			if (Candle1Script.isLit == true) {
				return true;
			}
			return false;
		} else if (candleNum == 2) {
			if (Candle2Script.isLit == true) {
				return true;
			}
			return false;
		} else if (candleNum == 3) {
			if (Candle3Script.isLit == true) {
				return true;
			}
			return false;
		} else if (candleNum == 4) {
			if (Candle4Script.isLit == true) {
				return true;
			}
			return false;
		}
		return false;
	}


	// Update is called once per frame
	void Update () {
		bool candleJustLit = false;

		if (numCandlesLit == 4) { //all candles lit

			if ((first == 3) && (second == 1) && (third == 2) && (fourth == 4)) {
				Key.SetActive(true);
			} else { //sets candles off
				numCandlesLit = 0;

				first = 0;
				second = 0;
				third = 0;
				fourth = 0;

				isLit1 = false;
				isLit2 = false;
				isLit3 = false;
				isLit4 = false;

				Candle1Script.disableCandle();
				Candle2Script.disableCandle();
				Candle3Script.disableCandle();
				Candle4Script.disableCandle();
			}
		}


		if (!isLit1 && !candleJustLit) {
			if (checkCandleLit(1)) {
				isLit1 = true;
				numCandlesLit++;
				if (numCandlesLit == 1) {
					first = 1;
				} else if (numCandlesLit == 2) {
					second = 1;
				} else if (numCandlesLit == 3) {
					third = 1;
				} else if (numCandlesLit == 4) {
					fourth = 1;
				}
				candleJustLit = true;
			}
		} 
		if (!isLit2 && !candleJustLit) {
			if (checkCandleLit(2)) {
				isLit2 = true;
				numCandlesLit++;
				if (numCandlesLit == 1) {
					first = 2;
				} else if (numCandlesLit == 2) {
					second = 2;
				} else if (numCandlesLit == 3) {
					third = 2;
				} else if (numCandlesLit == 4) {
					fourth = 2;
				}
				candleJustLit = true;
			}
		} 
		if (!isLit3 && !candleJustLit) {
			if (checkCandleLit(3)) {
				isLit3 = true;
				numCandlesLit++;
				if (numCandlesLit == 1) {
					first = 3;
				} else if (numCandlesLit == 2) {
					second = 3;
				} else if (numCandlesLit == 3) {
					third = 3;
				} else if (numCandlesLit == 4) {
					fourth = 3;
				}
				candleJustLit = true;
			}
		} 
		if (!isLit4 && !candleJustLit) {
			if (checkCandleLit(4)) {
				isLit4 = true;
				numCandlesLit++;
				if (numCandlesLit == 1) {
					first = 4;
				} else if (numCandlesLit == 2) {
					second = 4;
				} else if (numCandlesLit == 3) {
					third = 4;
				} else if (numCandlesLit == 4) {
					fourth = 4;
				}
				candleJustLit = true;
			}
		}
	}
}
