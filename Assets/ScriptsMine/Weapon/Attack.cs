using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {
	
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
	public float timeBetweenAttacks;
	private float timer;
	private float elapsedTime = 0.0f;
	private float renderTime = 0.0f;
	private bool fast = false;

	public GameObject wpn;
	private SpawnOnTriggerCollision spawner;
	private WeaponAnim wpnAnim;
	private CharAnim anim;

	// Use this for initialization
	void Start () {

		collider.enabled = false;
		timer = timeBetweenAttacks;
		spawner = GetComponent<SpawnOnTriggerCollision> ();
		wpnAnim = wpn.GetComponent<WeaponAnim> ();
		GameObject model = GameObject.FindWithTag ("Animated");
		anim = model.GetComponent<CharAnim> ();
		//wpn.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {

		if (fast)
						timer = timeBetweenAttacks/2.0f;
		else {
			timer = timeBetweenAttacks;
				}

		elapsedTime += Time.deltaTime;
		renderTime += Time.deltaTime;


		if (Input.GetKey (KeyCode.Space)&&elapsedTime>timer) 
		{
			collider.enabled = true;
			wpnAnim.setAttacking();
			//wpn.SetActive (true);
			elapsedTime = 0.0f;
			anim.Attack ();
		} 
		else 
		{
			collider.enabled = false;
			if (elapsedTime > 0.5f)
			{
				renderTime = 0.0f;
				//wpn.SetActive (false);
			}
		}
	}

	void OnTriggerEnter( Collider other )
	{
		if ( other.tag == "Player" ) {
			return;
		}
		
		// Looks for health script on hit object.  If no health script, will continue flying.
		Health h = other.gameObject.GetComponent<Health>( );
		if ( h ) {
			// apply damage
			h.Damage( calculateDamage( ) );
		}
	}


	float calculateDamage( )
	{
		float dmg = 0;
		
		if ( hitChance == 1.0f && criticalHitChance == 0.0f && (minDamageDealt == maxDamageDealt) ) {
			dmg = minDamageDealt;
			return dmg;
		} else {
			if ( Random.Range( 0.0f, 1.0f ) <= hitChance ) { // hit!
				dmg = Random.Range( minDamageDealt, maxDamageDealt );
				
				if ( Random.Range( 0.0f, 1.0f ) <= criticalHitChance ) { // crit!
					spawner.criticalHit();
					dmg = dmg * criticalHitModifer;
				}
				return dmg;
			}
		}
		spawner.missHit ();
		return dmg;
	}
	public void setFast(bool status)
	{
		fast = status;
	}
}
