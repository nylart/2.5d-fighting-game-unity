using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public abstract class AIBehavior : MonoBehaviour
{
	public abstract AIState doTransition( );
	public abstract void doActions( ) ;
}


// change this if you want to add or remove states
public enum AIState {
	init = 0,
	start = 1,
	phase1 = 2,
	phase2 = 3,
	phase3 = 4,
	death = 5,
	win = 6
}

[RequireComponent(typeof(Health))]
public class BossAIController : MonoBehaviour {

	public AIBehavior[] aiBehaviors = new AIBehavior[7];
	private AIState currentState;
	
	void FixedUpdate( ) 
	{
			// transition
			currentState = aiBehaviors[(int)currentState].doTransition();

			// state actions
			aiBehaviors[(int)currentState].doActions();
	}

	
}
