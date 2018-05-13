using UnityEngine;
using System.Collections;

public class AIDeath : AIBehavior 
{
	private Rotate rot;
	private WinLoseMessage gController;
	private float elapsedTime = 0.0f;
	private bool death = false;

	void Start()
	{
		rot = GetComponent<Rotate> ();
		GameObject obj = GameObject.FindWithTag ("GameController");
		gController = obj.GetComponent<WinLoseMessage> ();
	}

	void Update()
	{
		elapsedTime += Time.deltaTime;
		}

	public override AIState doTransition( ) 
	{
		return AIState.death;
	}

	public override void doActions()
	{
		if (!death) {
			elapsedTime = 0.0f;
						death = true;
						rot.Die ();
						
				}
		if (elapsedTime > 2.0f && death)
			gController.enemyDied ();
		// stuff it does while dying
	}

}
