﻿using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {

	public string key = "a";
	public string rollkey = "q";

	public int impulse_force = 10;

	public int springDamper = 20;
	public int springForce = 500;

	private bool onGround=false;

	private Vector3 myCorner;
	private int[][] mySides;

	private SpringJoint[] myJoints;
	private Vector3[] allCorners = new Vector3[4];
	private	GameObject[] allKitties = new GameObject[4];

	// Use this for initialization
	void Start () {

		myJoints = GetComponents<SpringJoint>();
		foreach (SpringJoint j in myJoints) {
						j.spring = springForce;
						j.damper = springDamper;
				}

		Transform tetra = transform.parent;
		Mesh mesh = tetra.GetComponent<MeshFilter> ().mesh;

		/*		SortedList mySides = new SortedList ();
		mySides.Add( 1, {{Kitty4,Kitty2}, {Kitty3,Kitty4}, {Kitty2,Kitty3}});
		mySides.Add( 2, {{Kitty1,Kitty4}, {Kitty3,Kitty1}, {Kitty4,Kitty3}});
		mySides.Add( 3, {{Kitty4,Kitty1}, {Kitty1,Kitty2}, {Kitty2,Kitty4}});
		mySides.Add( 4, {{Kitty2,Kitty1}, {Kitty1,Kitty3}, {Kitty3,Kitty2}});
*/
		Vector3[] vertices = mesh.vertices;

		allKitties = GameObject.FindGameObjectsWithTag("Kitty"); 

		for (int i =0; i< allKitties.Length; i++) {
			Debug.Log (i);
			allCorners[i] = getClosestCorner(allKitties[i].transform.position, vertices);
		}

		myCorner = getClosestCorner(transform.position, vertices);
	
	
		for(int i=0; i<allKitties.Length; i++) {
			Debug.Log ("Pals:" + i +  allKitties[i].transform.position.x + " " +  allKitties[i].transform.position.y + " " +  allKitties[i].transform.position.z) ;
		}	           
//				Debug.Log ("myCorner" + myCorner.x + myCorner.y + myCorner.z);
		}


	// Update is called once per frame
	void Update () {
	
				if (Input.GetButtonDown ("Jump " + key) || Input.GetKeyDown (key.ToLower ())) {
						if (onGround) {
								SetHighlight (Color.green);
								Vector3 push = (Vector3.up + transform.parent.localPosition.normalized);
				Debug.DrawRay (transform.parent.position, push, Color.red);
				Debug.Log (transform.parent.position);

							//+ transform.parent.position;
							rigidbody.AddForce(push * impulse_force, ForceMode.Impulse);
								
						} else {
								SetHighlight (Color.red);
						}
				}



				if (Input.GetButtonUp ("Jump " + key) || Input.GetKeyUp (key.ToLower ()) || Input.GetKeyUp (rollkey.ToLower ())) {
						SetHighlight (Color.white);
				}

		}

	void SetHighlight(Color highlightColor) {
		Color newColor = highlightColor;
		MeshRenderer gameObjectRenderer = GetComponent<MeshRenderer>();
		Material newMaterial = new Material(gameObjectRenderer.material);
		newMaterial.color = newColor;
		gameObjectRenderer.material = newMaterial ;
	}

	void OnCollisionStay(Collision col){
		Debug.Log (col.gameObject.tag);

				if (col.gameObject.tag == "Ground") {
						onGround = true;
			Debug.Log (onGround);
				}
		}
	void OnCollisionExit(Collision col){
				if (col.gameObject.tag == "Ground") {
						onGround = false;
			Debug.Log (onGround);
				}
					
		}    
	
	Vector3 getClosestCorner(Vector3 mypoint, Vector3[] vertices) {
		Vector3 myCorner=vertices[0];

		for (var i = 1; i < vertices.Length; i++) {
	
			float dist1 = (myCorner - mypoint).magnitude;
			float dist2 = (vertices [i] - mypoint).magnitude;
			if (dist2 > dist1) {
				myCorner = vertices [i];
			}
		}
		return myCorner;
	}

/*	Vector3 calcTorqueVector(Vector3 mypoint, Vector3[] vertices) {
		float[] ypos = new float[4];
		for (int i=0; i<vertices.Length; i++) {
						ypos [i] = vertices.y + Transform.y;
				}

		for (int i =0; i< allKitties.Length; i++) {
			base[i] = getBase(allKitties[i].transform.position, vertices);
		}

			Vector3[] groundcorners = new Vector3[2];
			int index = 0;
			for (int i=0; i<vertices.Length; i++) {
				if ((!vertices[i].y-mypoint.y <= 0,01)) {
					Debug.Log("y: " + groundcorners.y);
				}
			}
			return mypoint;
		}*/
}