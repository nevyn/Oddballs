using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {

	public string key = "a";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(key)) {
			rigidbody.AddForce(Vector3.up * 50, ForceMode.Force);

		}
	}
}
