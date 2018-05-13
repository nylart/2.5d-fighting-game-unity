using UnityEngine;
using System.Collections;

public class MeleeController : MonoBehaviour {

	[Tooltip("Minimum distance to target & be able to melee.  Any closer and melee is disabled.")]
	public float 
		meleeDistanceMin = 0.01f;
	[Tooltip("Maximum distance to target & be able to melee.  Any farther and melee is disabled.")]
	public float 
		meleeDistanceMax = 1.0f;

	[Tooltip("Melee Attack Speed")]
	public float
		speed = 1.0f;
	[Tooltip("minimum Damage dealt")]
	public float
		minDamageDealt = 1.0f;
	[Tooltip("maximum Damage dealt")]
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
	private bool attacking;
	public bool Attacking {
		get { return attacking; }
		set { attacking = value; }
	}
	
	private Transform target;
	private Health targetHealth;
	private float cooldownTimer;

	void Start() 
	{
		if ( hitChance > 1.0f ) {
			hitChance = hitChance / 100.0f;
			Error.Inquiry( this.gameObject.name, "hitChance is greater than 100%! Assuming wrong value entered." );
		}
		if ( criticalHitChance > 1.0f ) {
			criticalHitChance = criticalHitChance / 100.0f;
			Error.Inquiry( this.gameObject.name, "criticalHitChance is greater than 100%! Assuming wrong value entered." );
		}

		getTargetHealth();
		cooldownTimer = 0.0f;
	}

	void FixedUpdate() 
	{
		cooldownTimer -= Time.fixedDeltaTime;

		if( attacking && canMelee() ) 
		{
			if( cooldownTimer <= 0 ) 
			{
				cooldownTimer = speed; // reset cooldown timer

				if( targetHealth ) {
					targetHealth.Damage( calculateDamage( ) );
				} else {
					Error.MissingComponent( target.name, "Health", Error.ErrorType.Error );
				}
			} 
		}

	}


	public bool canMelee( ) 
	{
		// calculate within range

		if( Vector3.Distance( this.transform.position, target.position ) > meleeDistanceMax ||
		    Vector3.Distance( this.transform.position, target.position ) < meleeDistanceMin)
		{ // out of range
			return false;
		} else {
			return true;
		}
	}

	public void assignTarget( Transform t ) 
	{
		target = t;
	}

	float calculateDamage( )
	{
		if( !canMelee( ) ) { return 0.0f; }

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


	private void getTargetHealth() 
	{

		if( target ) {
			targetHealth = target.gameObject.GetComponent<Health>();

			if( targetHealth == null ) {
				Error.MissingComponent( target.name, "Health", Error.ErrorType.Error );
			}
		}
		else {
			Error.Inquiry( this.gameObject.name, "This gameObject has no target.  Please give it one." );
		}
	}


}
