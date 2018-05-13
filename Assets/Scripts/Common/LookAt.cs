using UnityEngine;
using System.Collections;

public class LookAt : MonoBehaviour {

	[Tooltip("What you want this GameObject to look at (if you have a Vector3)")]
	public Vector3 target;
	[Tooltip("What you want this GameObject to look at (if you have a Transform)")]
	public Transform targetTransform;
	
	// Use this for initialization
	void Start () {
		if( targetTransform ) {
			transform.LookAt ( targetTransform );
		}
		else 
		{
			transform.LookAt ( target );
		}
	}
}
