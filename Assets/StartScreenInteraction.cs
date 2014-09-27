using UnityEngine;
using System.Collections;

public class StartScreenInteraction : MonoBehaviour {

	public string key = "a";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.anyKeyDown) {
			//Input.GetButtonDown ("Jump " + key) || 
			Debug.Log ("BUTTONPRESS");
			Application.LoadLevel ("First"); 
		}

	}
}
