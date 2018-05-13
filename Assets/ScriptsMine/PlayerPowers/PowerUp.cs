using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {

	public enum Power { Lightning, Speed, Flight, Ultra}
	public Power powerUp;
	public float powerTime;
	
	private RandomDrop gameController;
	private PlayerController pController;
	private WinLoseMessage win;

	// Use this for initialization
	void Start () {
		GameObject obj = GameObject.FindWithTag ("GameController");
		gameController = obj.GetComponent<RandomDrop>();
		win = obj.GetComponent<WinLoseMessage> ();
		GameObject p = GameObject.FindWithTag ("Player");
		pController = p.GetComponent<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter( Collider other ) {
		if (other.tag == "Player" && !(win.IsGameOver())) {
			gameController.itemGet ();
			if(powerUp == Power.Ultra)
				gameController.ultraGet ();
			else if(powerUp == Power.Speed)
				pController.speedPower(powerTime);
			else if(powerUp == Power.Flight)
				pController.flightPower (powerTime);
			else if(powerUp == Power.Lightning)
				pController.lightningPower ();
			Destroy( gameObject );		
		}
		
	}
}
