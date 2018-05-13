using UnityEngine;
using System.Collections;

public class Base_NPCController : MonoBehaviour {

	public Transform[] wayPoints;
	public int currentWayPoint;

	public float movementSpeed = 0.1f;
	private float distanceToWayPoint = 2.0f;

	private bool smooth = true;
	private float damping = 6.0f;

	void Start( ) {
		if( movementSpeed <= 0 ) {
			movementSpeed = 0.1f;
		}

		if( rigidbody ) {
			rigidbody.freezeRotation = true;
		}

		if( wayPoints.Length == 0 ) {
			Debug.LogWarning( "NPC Controller on " +gameObject.name+" has no waypoints and has been deactivated! Please assign some waypoints!" );
			gameObject.SetActive ( false );
		}

	}

	void Update( ) 
	{
		patrol ();
	}

	void patrol( ) 
	{
		if( distanceToWayPoint > Vector3.Distance( wayPoints[currentWayPoint].position, transform.position ) )
		{
			currentWayPoint++;
			if( currentWayPoint > wayPoints.Length-1 ) currentWayPoint = 0;
		}
		else {
			if( smooth ) {
				Quaternion rotation = Quaternion.LookRotation( wayPoints[currentWayPoint].position - transform.position);
				transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
			} else {
				transform.LookAt ( wayPoints[currentWayPoint] );
			}

			rigidbody.AddRelativeForce( new Vector3(0,0,movementSpeed) );
		}
	}                
}
