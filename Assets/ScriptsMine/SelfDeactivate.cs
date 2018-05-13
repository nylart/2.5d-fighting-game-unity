using UnityEngine;
using System.Collections;

public class SelfDeactivate : MonoBehaviour {

	public float timer;
	private float elapsedTime = 0.0f;
	private bool fresh = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (fresh) 
		{
			elapsedTime = 0.0f;
			fresh = false;
		}
		elapsedTime += Time.deltaTime;
		if (elapsedTime > timer) {
			fresh = true;
			gameObject.SetActive(false);
		
		}
	}
}
