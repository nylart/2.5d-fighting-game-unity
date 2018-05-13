using UnityEngine;
using System.Collections;

public class SelfDestruct : MonoBehaviour {

	[Tooltip("How long the GameObject will exist (in seconds) before it destroys itself")]
	public float lifetime = 1.0f;
	
	// Use this for initialization
	void Start () {
		Destroy( gameObject, lifetime );
	}
}
