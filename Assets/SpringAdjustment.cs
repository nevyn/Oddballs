using UnityEngine;
using System.Collections;

public class SpringAdjustment : MonoBehaviour {

	public int damp = 1000;
	public int springy = 500;

	// Use this for initialization
	void Start () {

				SpringJoint[] springs = FindObjectsOfType (typeof(SpringJoint)) as SpringJoint[];
				foreach (SpringJoint s in springs) {
						s.damper = damp;
						s.spring = springy;
	
				}
		}
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.DownArrow)) {
						springy -= 10;
				}
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
						springy += 10;
				}
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
						damp -= 10;
				}
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			damp+=10;
				}


			SpringJoint[] springs = FindObjectsOfType(typeof(SpringJoint)) as SpringJoint[];
			foreach (SpringJoint s in springs) {
				s.damper = damp;
				s.spring = springy;
		}
	
	}
}
