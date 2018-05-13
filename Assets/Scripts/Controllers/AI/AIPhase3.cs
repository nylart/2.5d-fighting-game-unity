using UnityEngine;
using System.Collections;

public class AIPhase3 : AIBehavior 
{
	public Health health;
	public Health playerHealth;

	private ZoneAttacks kAtks;

	private float elapsedTime = 0.0f;
	private float timeBetweenAttacks = 5.0f;
	private int count = 0;
	
	void Start()
	{
		kAtks = GetComponent<ZoneAttacks> ();
	}
	
	void Update()
	{
		elapsedTime += Time.deltaTime;
	}

	public override AIState doTransition( ) 
	{
		if( health && playerHealth ) 
		{
			if( health.CurrentHealth <= 0.0f ) { return AIState.death; }
			if( playerHealth.CurrentHealth <= 0.0f ) { return AIState.win; }
				
			return AIState.phase3;
		}
		else 
		{
			health = this.gameObject.GetComponent<Health>();
			GameObject obj = GameObject.FindGameObjectWithTag("Player");
			if( obj ) { playerHealth = obj.GetComponent<Health>(); }
			return AIState.phase3; // return to self
		}
	}

	public override void doActions()
	{
		
		if (elapsedTime >= timeBetweenAttacks) 
		{
			int RNG = Random.Range (0, 2);
			if (RNG == 0) {
				while(kAtks.Thrash ()){}
			} else {
				kAtks.EnemyProj (0);
			}
			elapsedTime = 0.0f;
		}
	}
}
