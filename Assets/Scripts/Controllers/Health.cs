using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
	// add your GameController here:
	public WinLoseMessage gameController;

	[Tooltip("An array of prefabs that should be instantiated on the death of this gameObject.  Can be explosions or dropped items.")]
	public GameObject[] spawnOnDeathPrefabs;
	
	[Tooltip("Starting Health of this GameObject")]
	public float
		startingHealth = 1.0f;
	[Tooltip("Maximum Health of this GameObject")]
	public float
		maxHealth = 1.0f;
	public float currentHealth;

	[Tooltip("If true, use lives instead of health.  Health will be set to 1.0")]
	public bool useLivesOnly = false;
	
	private MyAnimator anim;
	private CharAnim charAnim;

	void Start( ) {
		if( useLivesOnly ) {
			maxHealth = 1.0f;
			startingHealth = 1.0f;
		}
		if (this.tag == "Enemy") {
						anim = GetComponent<MyAnimator> ();
				}
		currentHealth = startingHealth;
		GameObject obj = GameObject.FindWithTag ("GameController");
		gameController = obj.GetComponent<WinLoseMessage> ();
		GameObject model = GameObject.FindWithTag ("Animated");
		charAnim = model.GetComponent<CharAnim> ();
	}

	public void Damage( float amount )
	{
		currentHealth -= amount;
		if (anim != null) {
			anim.isHit ();		
		}
		if( currentHealth <= 0 ) {
			death();
		}                               
	}

	public void Heal( float amount )
	{
		currentHealth += amount;

		if( currentHealth > maxHealth ) {
			currentHealth = maxHealth;
		}
	}

	private void death( ) 
	{
		if ( this.gameObject.tag == "Player" ) {
			// tell the GameController/GameManager death has occurred.
			gameController.playerDied();
			charAnim.Die ();
			Debug.Log ("died");
		}
	
		foreach( GameObject obj in spawnOnDeathPrefabs ) {
			Instantiate( obj, this.transform.position, this.transform.rotation );
		}
		//gameController.enemyDied ();
		//Destroy (gameObject);
	} 

	// Use this to get the currentHealth of this gameObject.
	public float CurrentHealth {
		get { return currentHealth; }
	}
}
