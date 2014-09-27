using UnityEngine;
using System.Collections;

public class SpringAdjustment : MonoBehaviour {

	public int damp = 100;
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

			SpringJoint[] springs = FindObjectsOfType(typeof(SpringJoint)) as SpringJoint[];
			foreach (SpringJoint s in springs) {
				s.damper = damp;
				s.spring = springy;
		}
	
	}
}
