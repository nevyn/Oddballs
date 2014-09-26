using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {

	public string key = "a";
	public int impulse_force = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(key)) {
			rigidbody.AddForce(Vector3.up * impulse_force, ForceMode.Impulse);
			
		}
	}
}
