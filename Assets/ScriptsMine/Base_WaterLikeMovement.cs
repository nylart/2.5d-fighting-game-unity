using UnityEngine;
using System.Collections;

public class Base_WaterLikeMovement : MonoBehaviour {
	
	private Transform myTransform; 
	public float rotationSpeed = 0.1f; 
	
	void Start () { myTransform = transform; }
	
	void Update () { 
		myTransform.Rotate(0, 
		                   Time.deltaTime * rotationSpeed * Mathf.Sin(Time.time), 
		                   0,
		                  Space.World); 
	}
}
