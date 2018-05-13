using UnityEngine;
using System.Collections;


public class DestroyOnContact : MonoBehaviour 
{ 
	[Tooltip("If true, Destroy any Triggers that collide with this GameObject. If false, destroy any Colliders that collide with this GameObject.")]
	public bool destroyTriggers = true;

	void Start( ) {
		if( this.gameObject.collider == null ) {
			Error.MissingComponent( this.gameObject.name, "Collider", Error.ErrorType.Error );
			return;
		}
		else {
			if( destroyTriggers ) {
				this.gameObject.collider.isTrigger = true;
			}
		}
	}

	private void OnTriggerEnter( Collider other )
	{
		if( destroyTriggers ) {
			Destroy( other.gameObject );
		}
	}

	private void OnCollisionEnter( Collision collision ) 
	{
		if( !destroyTriggers ) {
			Destroy( collision.gameObject );
		
		}
	}
}
