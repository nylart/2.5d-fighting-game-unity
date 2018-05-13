using UnityEngine;
using System.Collections;

public class SceneSelect : MonoBehaviour {

	public bool first = false;
	public GameObject titlescreen;


	// Use this for initialization
	void Start () {
		//titlescreen.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Alpha1))
			Application.LoadLevel (1);
		if (Input.GetKey (KeyCode.Alpha2))
			Application.LoadLevel (2);
		if (Input.GetKey (KeyCode.Alpha3))
			Application.LoadLevel (3);
		if (Input.GetKey (KeyCode.Space)&&first)
			titlescreen.SetActive(false);

	}
}
