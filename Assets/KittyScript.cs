using UnityEngine;
using System.Collections;

public class KittyScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		Debug.Log (other.gameObject.tag);
		if(other.gameObject.tag.Equals("Collectible")) {
			GetComponent<AudioSource>().Play();

			GameObject cam = GameObject.Find("Main Camera");

			GUIScript gui = cam.GetComponent<GUIScript>();
			gui.increment();
		}
		
		Destroy(other.gameObject);
	}


}
