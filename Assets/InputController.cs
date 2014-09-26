using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {

	public string key = "A";
	public int impulse_force = 10;

	private Transform myCorner;
	private bool onGround=false;

	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
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

