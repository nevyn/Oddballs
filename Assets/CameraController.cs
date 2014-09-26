using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		GameObject kittyBall = GameObject.Find("KittyBall");
		transform.LookAt(kittyBall.transform.position + new Vector3(0, 2, 0));
		Vector3 diff = kittyBall.transform.position - transform.position;
		if(diff.magnitude > 10)
			transform.position += diff.normalized * 0.05f;

		transform.position = new Vector3(transform.position.x, kittyBall.transform.position.y + 3, transform.position.z);
	}
}
