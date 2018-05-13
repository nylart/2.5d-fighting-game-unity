using UnityEngine;
using System.Collections;

public class AIPhase2 : AIBehavior 
{
	public Health health;
	public Health playerHealth;
	public float nextPhaseHealthLevel = 250.0f;

	private ZoneAttacks kAtks;
	private MovingPlatform movement;
	private MyAnimator anim;
	private float elapsedTime = 0.0f;
	private float timeBetweenAttacks = 5.0f;
	private int count = 0;
	
	void Start()
	{
		kAtks = GetComponent<ZoneAttacks> ();
		movement = GetComponent<MovingPlatform> ();
		anim = GetComponent<MyAnimator> ();
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

			if( health.CurrentHealth < nextPhaseHealthLevel && health.CurrentHealth > 0.0f ) {
				anim.swimAnim ();
				movement.EndOnTopRow();
				return AIState.phase3; 
			} else {
				return AIState.phase2;
			}
		}
		else 
		{
			health = this.gameObject.GetComponent<Health>();
			GameObject obj = GameObject.FindGameObjectWithTag("Player");
			if( obj ) { playerHealth = obj.GetComponent<Health>(); }
			return AIState.phase2; // return to self
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
				kAtks.BothRightTwo (1);
			}
			elapsedTime = 0.0f;
		}
	}
}
