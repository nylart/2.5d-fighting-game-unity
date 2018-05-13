using UnityEngine;
using System.Collections;

public class Orbit : MonoBehaviour {

	public Transform target;
	
	public float theta; // angle of motion per frame;
	public float radius; // radius of the orbit
	
	public float speed;
	//public bool randomRotation;
	
	private float x;
	private float z;
	//private Quaternion rotation;
	
	void Start () {
		theta = 0.0f;
		/*
		if( randomRotation ) {
			rotation = Quaternion.Euler(Random.insideUnitSphere * Random.Range (1,10) );
		} else {
			rotation = transform.rotation;
		} */
	}
	
	void Update () 
	{
		theta += Time.deltaTime * speed;
		
		AdjustPosition ( );
	}
	
	void AdjustPosition( ) {
		x = radius * Mathf.Cos(theta) + target.position.x;
		z = radius * Mathf.Sin(theta) + target.position.z;
		
		transform.position = new Vector3( x, transform.position.y, z );
	}
}
