using UnityEngine;
using System.Collections;

public class Level0Gate : MonoBehaviour {

	public Sprite openImage;

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
				Application.LoadLevel("_Scene_Level1");
			}
		}
	}

	IEnumerator Example() {
		print(Time.time);
		yield return new WaitForSeconds(5);
		print(Time.time);
	}
}
