using UnityEngine;
using System.Collections;

public class LevelGate : MonoBehaviour {

	public Sprite openImage;
	public string nextLevel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider other){
		GameObject collidedWith = other.gameObject;
		
		if (collidedWith.tag == "Character") {
			if (Character.S.keyCount > 0 && Input.GetKeyDown(KeyCode.UpArrow))
			{
				--Character.S.keyCount;
				GetComponent<SpriteRenderer>().sprite = openImage;
				StartCoroutine(Example());
				Application.LoadLevel(nextLevel);
			}
		}
	}

	IEnumerator Example() {
		print(Time.time);
		yield return new WaitForSeconds(5);
		print(Time.time);
	}
}
