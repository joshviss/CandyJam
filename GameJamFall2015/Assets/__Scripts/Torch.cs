using UnityEngine;
using System.Collections;

public class Torch : MonoBehaviour {

	public float timeLitToDestoryed = 10f;
	public bool characterCollided = false;
	public float minFlickerSpeedOn = 0.05f;
	public float maxFlickerSpeedOn = 0.1f;
	public float minFlickerSpeedOff = 0.2f;
	public float maxFlickerSpeedOff = 0.3f;
	public float minLightIntensity = 6f;
	public float maxLightIntensity = 8f;

	Rigidbody rigid;
	//SpriteRenderer spRend;
	//Color torchColor;
	Light pointLight;
	public GameObject characterObject;

	RigidbodyConstraints noRotZ, noRotYZ;
	Quaternion turnLeft = Quaternion.Euler(0, 180, 0);
	Quaternion rotate90 = Quaternion.Euler(0, 0, 90);

	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody>();
		//spRend = transform.Find("Sprite").GetComponent<SpriteRenderer>();
		pointLight = transform.Find("TorchPointLight").GetComponent<Light>();
		characterObject = GameObject.Find("Character");

		//torchColor = spRend.color;

		noRotZ = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ;
		noRotYZ = noRotZ | RigidbodyConstraints.FreezePositionY;
		StartCoroutine(LightFlicker());
		//StartCoroutine(LightColor());
		//StartCoroutine(CheckForCharacter());
	}

	IEnumerator LightFlicker() {
		while (true) {
			pointLight.intensity = Random.Range(minLightIntensity, maxLightIntensity);
			yield return new WaitForSeconds (Random.Range(minFlickerSpeedOff, maxFlickerSpeedOff));
			pointLight.intensity = Random.Range(minLightIntensity, minLightIntensity);
			yield return new WaitForSeconds(Random.Range(minFlickerSpeedOn, maxFlickerSpeedOn));
		}
	}

	/*
	IEnumerator LightColor() {
		
		while (true) {
			pointLight.color = new Color();
			yield return new WaitForSeconds(Random.Range(minFlickerSpeedOff, maxFlickerSpeedOff));
			pointLight.intensity = Random.Range(minLightIntensity, minLightIntensity);
			yield return new WaitForSeconds(Random.Range(minFlickerSpeedOn, maxFlickerSpeedOn));
		}
		
	}
	

	IEnumerator CheckForCharacter() {
		yield return null;
	}
	*/

	// Update is called once per frame
	void Update() {

	}

	// FixedUpdate is called once per physics engine update (50 fps)
	void FixedUpdate () {
	
	}
}
