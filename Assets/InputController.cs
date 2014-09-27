using UnityEngine;
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
								rigidbody.AddForce(Vector3.up * impulse_force, ForceMode.Impulse);
								
								GetComponent<AudioSource>().Play();
								rigidbody.AddForce (Vector3.up * impulse_force, ForceMode.Impulse);
						} else {
								SetHighlight (Color.red);
						}
				}

				if (Input.GetButtonUp ("Jump " + key) || Input.GetKeyUp (key.ToLower ()) || Input.GetKeyUp (rollkey.ToLower ())) {
						SetHighlight (onGround ? Color.yellow : Color.white);
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
			SetHighlight (Color.yellow);
				}
		}
	void OnCollisionExit(Collision col){
				if (col.gameObject.tag == "Ground") {
						onGround = false;
						SetHighlight (Color.white);
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
	
}