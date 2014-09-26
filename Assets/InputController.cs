using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {

	public string key = "a";
	public int impulse_force = 10;

	private Vector3 myCorner;

	private bool onGround=false;

	private GameObject[] myPals;

	// Use this for initialization
	void Start () {

		myPals = gameObject.GetComponentsInParent(typeof(Kitty));

				Transform tetra = transform.parent;
				Mesh mesh = tetra.GetComponent<MeshFilter> ().mesh;

				Vector3[] vertices = mesh.vertices;
			
				myCorner = vertices [0];
				for (var i = 1; i < vertices.Length; i++) {

						float dist1 = (myCorner - transform.position).magnitude;
						float dist2 = (vertices [i] - transform.position).magnitude;
						if (dist2 > dist1) {
								myCorner = vertices [i];
						}
		
				}
//				Debug.Log ("myCorner" + myCorner.x + myCorner.y + myCorner.z);
		}
	// Update is called once per frame
	void Update () {
<<<<<<< HEAD

				if (Input.GetKeyDown (key)) {
						if (onGround) {
								
								rigidbody.AddForce (Vector3.up * impulse_force, ForceMode.Impulse);
						}
				}
		}
=======
		if (Input.GetButtonDown("Jump " + key) || Input.GetKeyDown (key.ToLower())) {
			if (onGround) {
				SetHighlight(Color.green);
				rigidbody.AddForce (Vector3.up * impulse_force, ForceMode.Impulse);
			} else {
				SetHighlight(Color.red);
			}
		}

		if(Input.GetButtonUp ("Jump " + key) || Input.GetKeyUp (key.ToLower ())) {
			SetHighlight(Color.white);
		}
	}

	void SetHighlight(Color highlightColor) {
		Color newColor = highlightColor;
		MeshRenderer gameObjectRenderer = GetComponent<MeshRenderer>();
		Material newMaterial = new Material(gameObjectRenderer.material);
		newMaterial.color = newColor;
		gameObjectRenderer.material = newMaterial ;
	}
>>>>>>> FETCH_HEAD

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
}

