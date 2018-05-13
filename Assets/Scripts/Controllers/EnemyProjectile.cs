using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(SelfDestruct))]
public class EnemyProjectile : MonoBehaviour
{

	[Tooltip("Speed of this projectile")]
	public float
		speed = 1.0f;
	[Tooltip("minimum Damage dealt by this projectile")]
	public float
		minDamageDealt = 1.0f;
	[Tooltip("maximum Damage dealt by this projectile")]
	public float
		maxDamageDealt = 1.0f;
	[Tooltip("Chance of critical hit: 0% to 100%")]
	public float
		criticalHitChance = 0.0f;
	[Tooltip("critical hit damage modifier")]
	public float
		criticalHitModifer = 2.0f;
	[Tooltip("Chance of Hit: 0% to 100%")]
	public float
		hitChance = 1.0f;
	[Tooltip("How often this projectile can be fired (in seconds)")]
	private float fireRate = 1.0f;
	public float FireRate 
	{
		get { return fireRate; }
	}

	private string creatorTag;
	
	[Tooltip("if true, destroys the projectile on any OnTriggerEnter.")]
	public bool destroyOnAnyCollision = false;
	// note: will not collide with Colliders that are not triggers, because the collider is configured as a trigger.

	// Use this for initialization
	void Start( )
	{
		Collider[] colliders = gameObject.GetComponents<Collider>( );
		if ( colliders.Length > 1 ) {
			Error.Inquiry( this.gameObject.name, "You have two or more colliders on this Projectile.  USE ONLY CapsuleCollider!" );
			return;
		} 

		if ( colliders[0].isTrigger == false ) {
			colliders[0].isTrigger = true;
			// note: will not collide with Colliders that are not triggers, because the collider is configured as a trigger.
		}

		if ( hitChance > 1.0f ) {
			hitChance = hitChance / 100.0f;
			Error.Inquiry( this.gameObject.name, "hitChance is greater than 100%! Assuming wrong value entered." );
		}
		if ( criticalHitChance > 1.0f ) {
			criticalHitChance = criticalHitChance / 100.0f;
			Error.Inquiry( this.gameObject.name, "criticalHitChance is greater than 100%! Assuming wrong value entered." );
		}
	}
	

	void FixedUpdate( )
	{
		// foward motion
		//rigidbody.AddRelativeForce( new Vector3( 0, 0, speed ));
		transform.position = new Vector3(transform.position.x - 0.2f,
		                                 transform.position.y,
		                                 transform.position.z);
	}

	void OnTriggerEnter( Collider other )
	{
		// did we register an event by hitting our creator?
		//if ( other.tag == creatorTag ) {
		//	return;
		//}

		// Looks for health script on hit object.  If no health script, will continue flying.
		Health h = other.gameObject.GetComponent<Health>( );
		if ( h && other.tag == "Player") {
			// apply damage
			h.Damage( calculateDamage( ) );
			Destroy ( this.gameObject );
		}

		// if true, we destroy ourself on colliding with any trigger.
		if( destroyOnAnyCollision ) { Destroy (this.gameObject ); }
	}


	float calculateDamage( )
	{
		float dmg = 0;

		if ( hitChance == 1.0f && criticalHitChance == 0.0f && (minDamageDealt == maxDamageDealt) ) {
			dmg = minDamageDealt;
		} else {
			if ( Random.Range( 0.0f, 1.0f ) <= hitChance ) { // hit!
				dmg = Random.Range( minDamageDealt, maxDamageDealt );

				if ( Random.Range( 0.0f, 1.0f ) <= criticalHitChance ) { // crit!
					dmg = dmg * criticalHitModifer;
				}
			}
		}
		return dmg;
	}

	public void SetCreator( string tag )
	{
		creatorTag = tag;
	}

}
