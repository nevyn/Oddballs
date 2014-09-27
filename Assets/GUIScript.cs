using UnityEngine;
using System.Collections;

public class GUIScript : MonoBehaviour {
	public int score;

	void Start () {
		score = 0;
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnGUI() {
		GUILayout.BeginArea (new Rect (20, Screen.height-30, 200, 50));
		GUILayout.BeginHorizontal ();

		GUILayout.Label ("NOMZ: " + score);
		GUILayout.EndHorizontal ();
		GUILayout.EndArea ();

	}

	public void increment() {
		score ++;
	}
}
