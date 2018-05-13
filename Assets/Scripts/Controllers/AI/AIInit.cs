using UnityEngine;
using System.Collections;

public class AIInit : AIBehavior 
{
	private MovingPlatform movement;

	void Start()
	{
		movement = GetComponent<MovingPlatform> ();
		movement.StayStill (true);
		}

	public override AIState doTransition( ) 
	{
		return AIState.start;
	}

	public override void doActions()
	{
		// initial actions, only occurs once.
	}
}
