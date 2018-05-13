using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Vector3 start;
	private Vector3 end;

	public GameObject lightningBolt;
	public GameObject wings;
	public GameObject boltcarry;

	public bool lightning = false;
	public bool flight = false;
	public bool fast = false;
	private float speed;
	private float elapsedTime = 0.0f;
	private float powerupTime = 0.0f;
	private RandomDrop gameController;
	private CharAnim anim;
	//private Attack weapon;

	// Use this for initialization
	void Start () {
		GameObject obj = GameObject.FindWithTag ("GameController");
		gameController = obj.GetComponent<RandomDrop>();
		//GameObject wpn = GameObject.FindWithTag ("Weapon");
		//weapon = wpn.GetComponent<Attack> ();
		//weapon = GetComponent<Attack> ();
		GameObject[] model = GameObject.FindGameObjectsWithTag ("Animated");

		if (model == null)
						Debug.Log ("no model");
		foreach (GameObject m in model) {
			Debug.Log (m.name);
			anim = m.GetComponent<CharAnim> ();
			if (anim == null)
				Debug.Log ("no anim");
				}

		wings.SetActive (false);
		boltcarry.SetActive (false);

	}

	// Update is called once per frame
	void Update () {

		elapsedTime += Time.deltaTime;
		if (elapsedTime >= powerupTime && (flight || fast)) 
		{
			flight = false;
			fast = false;
			//weapon.setFast (false);
			gameController.powerSet (false);
			wings.SetActive(false);

		}

		if (transform.position.y > 5.0f) {gameController.playerOnTopRow (true);}
		else 							 {gameController.playerOnTopRow (false);}

		if (flight) { rigidbody.useGravity = false;} 
		else 		{ rigidbody.useGravity = true; }

		if (fast) { speed = 2.5f; } 
		else 	  { speed = 1.0f; }

		if (Input.GetKey (KeyCode.RightArrow)) {

			if (transform.position.x < 3.5f)
			transform.position = new Vector3(transform.position.x + 0.1f*speed,
			                                 transform.position.y,
			                                 transform.position.z);
			anim.Walk();
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.position = new Vector3(transform.position.x - 0.1f*speed,
			                                 transform.position.y,
			                                 transform.position.z);
			anim.Walk ();
		}
		if (Input.GetKey (KeyCode.UpArrow) ) {

				transform.position = new Vector3(transform.position.x,
				                                 transform.position.y + 0.1f,
				                                 transform.position.z);
			anim.Jump ();
		}

		if (Input.GetKey (KeyCode.DownArrow) && flight) {
				
			transform.position = new Vector3(transform.position.x,
			                                 transform.position.y - 0.1f,
			                                 transform.position.z);
		}

		if (Input.GetKey (KeyCode.LeftControl) && lightning) {
			Vector3 spot = new Vector3 (transform.position.x+0.5f,transform.position.y,0.0f);
			Instantiate (lightningBolt, spot, Quaternion.Euler (50,180,0));
			gameController.powerSet (false);
			lightning = false;
			boltcarry.SetActive(false);
		}

	}

	public void flightPower(float timer)
	{
		flight = true;
		powerupTime = timer;
		elapsedTime = 0.0f;
		gameController.powerSet (true);
		wings.SetActive (true);
	}

	public void speedPower(float timer)
	{
		fast = true;
		//weapon.setFast (true);
		powerupTime = timer;
		elapsedTime = 0.0f;
		gameController.powerSet (true);
	}

	public void lightningPower()
	{
		lightning = true;
		gameController.powerSet (true);
		boltcarry.SetActive (true);

	}

	public bool speedTrue()
	{
		return fast;
	}

}
