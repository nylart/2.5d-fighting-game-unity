using UnityEngine;
using System.Collections;

public class AIStart : AIBehavior 
{
	public override AIState doTransition( ) 
	{
		return AIState.phase1;
	}

	public override void doActions()
	{
		// starting actions, animations, etc.
	}
}
