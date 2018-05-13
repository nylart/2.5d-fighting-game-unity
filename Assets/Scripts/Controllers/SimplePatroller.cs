using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]

public class SimplePatroller : MonoBehaviour {

	[Tooltip("Locations this GameObject should move from and to")]
	public Transform[] wayPoints;

	[Tooltip("WayPoint to start at")]
	public int wayPointIndex;

	[Tooltip("Prevents this GameObject from rotating while moving")]
	public bool lockRotation;

	[Tooltip("Speed at which this GameObject should move")]
	public float movementSpeed = 0.1f;

	private bool activelyPatrolling = true;
	public bool ActivelyPatrolling 
	{
		get { return activelyPatrolling; }
		set { activelyPatrolling = value; }
	}

	private float distanceToWayPoint = 2.0f;
	private bool smooth = true;
	private float damping = 6.0f;

	void start() {
		if ( wayPoints.Length == 0 ) { 
			this.gameObject.SetActive ( false ); 
			Error.DisabledGameObject( this.gameObject.name, "Unable to find any waypoints" );
		}
		else {
			if( wayPointIndex >= wayPoints.Length ) {
				wayPointIndex = wayPoints.Length - 1;
			}
			transform.position = wayPoints[wayPointIndex].position;

		}

		if( movementSpeed <= 0 ) {
			movementSpeed = 0.1f;
		}
		rigidbody.freezeRotation = lockRotation;
		activelyPatrolling = true;

	}

	void Update( ) {
		if( activelyPatrolling ) {
			patrol ();
		}
	}

	private void patrol( ) 
	{
		if( distanceToWayPoint > Vector3.Distance( wayPoints[wayPointIndex].position, transform.position ) )
		{
			wayPointIndex++;
			if( wayPointIndex > wayPoints.Length-1 ) wayPointIndex = 0;
		}
		else {
			if( smooth ) {
				Quaternion rotation = Quaternion.LookRotation( wayPoints[wayPointIndex].position - transform.position);
				transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
			} else {
				transform.LookAt ( wayPoints[wayPointIndex] );
			}
			
			rigidbody.AddRelativeForce( new Vector3(0,0,movementSpeed) );
		}
	} 
}
