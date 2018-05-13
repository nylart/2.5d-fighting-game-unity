using UnityEngine;
using System.Collections;

public class SpawnOnTriggerCollision : MonoBehaviour
{

	[Tooltip("The Prefab to instantiate after the OnTriggerEnter event")]
	public GameObject
		prefabToSpawn;
	public GameObject miss;
	public bool showMiss;
	public GameObject critical;
	public bool showCritical;
	[Tooltip("Tags objects that collide with this one must have in order to trigger.  If empty, all tags will trigger")]
	public string[]
		tags;
	[Tooltip("If true, use OnTriggerEnter.  If false, use OnCollisionEnter")]
	public bool
		useTrigger = true;
	[Tooltip("If true, use the Colliding GameObject's transform instead of this gameObject's transform")]
	public bool
		useCollidingTransform = false;

	public bool points = false;

	void Start( )
	{
		if ( this.gameObject.collider == null ) {
			Error.MissingComponent( this.gameObject.name, "Collider" );
		} else {
			if ( this.gameObject.collider.isTrigger != useTrigger ) {
				Error.Inquiry( this.gameObject.name, "UseTrigger but not set isTrigger on the collider" ); // comment this out if behavior is intended
			}
		}
	}

	void drop( Collider other )
	{
		if ( useCollidingTransform ) {
			if (points)
			{
				Vector3 spot = new Vector3(other.transform.position.x-2.0f,other.transform.position.y, -4.0f);
				if(showMiss)
				{
					Instantiate( miss, spot, Quaternion.Euler (0.0f,180.0f,0.0f));
					showMiss = false;
					return;
				}
				if(showCritical)
				{
					Instantiate( critical, spot, Quaternion.Euler (0.0f,180.0f,0.0f));
					showCritical = false;
					return;
				}
				Instantiate( prefabToSpawn, spot, Quaternion.Euler (0.0f,180.0f,0.0f));
				return;
			}
			Instantiate( prefabToSpawn, other.transform.position, other.transform.rotation );
		} else {
			Instantiate( prefabToSpawn, transform.position, transform.rotation );
		}
	}

	void drop( Collision collision )
	{
		if ( useCollidingTransform ) {
			if (points)
			{
				Vector3 spot = new Vector3(collision.transform.position.x-2.0f,collision.transform.position.y, -6.0f);
				Instantiate( prefabToSpawn, spot, Quaternion.Euler (90.0f,0.0f,180.0f));
				return;
			}
			Instantiate( prefabToSpawn, collision.transform.position, collision.transform.rotation );
		} else {
			Instantiate( prefabToSpawn, transform.position, transform.rotation );
		}
	}

	void OnTriggerEnter( Collider other )
	{
		if ( useTrigger ) {

			if ( tags.Length == 0 ) {
				drop( other );
			} else {
				foreach ( string tag in tags ) {
					if ( tag == other.tag ) {
						drop( other );
					}
				}
			}
		}
	}

	void OnCollisionEnter( Collision collision )
	{
		if ( !useTrigger ) {
			if ( tags.Length == 0 ) {
				drop( collision );
			} else {
				foreach ( string tag in tags ) {
					if ( tag == collision.gameObject.tag ) {
						drop( collision );
					}
				}
			}
		}
	}

	public void missHit()
	{
		showMiss = true;
	}
	public void criticalHit()
	{
		showCritical = true;
	}
}
