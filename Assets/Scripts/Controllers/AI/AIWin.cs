using UnityEngine;
using System.Collections;

public class AIWin : AIBehavior 
{
	public override AIState doTransition( ) 
	{
		return AIState.win;
	}

	public override void doActions()
	{	
		// stuff it does after it won
	}
}
