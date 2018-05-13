using UnityEngine;
using System.Collections;

public class ActivateUltra : MonoBehaviour {

	public enum Ultra {Arrow, Earthquake, Song}

	public Ultra ultraType;

	public GameObject ultrabar1;
	public GameObject ultrabar2;
	public GameObject ultrabar3;
	
	public bool available = false;

	public GameObject arrowUltra;
	public GameObject earthquakeUltra;
	public GameObject songUltra;
	public GameObject harp;

	private GameObject player;
	private RandomDrop gameController;

	// Use this for initialization
	void Start () {
		ultrabar1.SetActive(false);
		ultrabar2.SetActive(false);
		ultrabar3.SetActive(false);
		harp.SetActive (false);
		GameObject obj = GameObject.FindWithTag ("GameController");
		gameController = obj.GetComponent<RandomDrop>();
		player = GameObject.FindWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (available && Input.GetKey (KeyCode.LeftShift)) {

			if (ultraType == Ultra.Arrow)	   { activateArrowUltra(); }
			if (ultraType == Ultra.Earthquake) { activateEarthquakeUltra(); }
			if (ultraType == Ultra.Song)       { activateSongUltra(); }
			AddUltraBar(0);
		
		}
		if (Input.GetKey (KeyCode.P)) {
				
			AddUltraBar (3);
		}
	}

	public void AddUltraBar(int num)
	{
		if (num >= 1) {	ultrabar1.SetActive (true); }
		if (num >= 2) {	ultrabar2.SetActive (true); }
		if (num == 3) { ultrabar3.SetActive (true); available = true; }
		if (num == 0) {
			ultrabar1.SetActive(false);
			ultrabar2.SetActive(false);
			ultrabar3.SetActive(false);
			available = false;
			gameController.resetUltra();
		}
	}

	private void activateArrowUltra()
	{
		for (int i = 0; i < 5; i++)
		{
			Vector3 spot = new Vector3(-8.0f, i*2.0f+1.0f, 0.0f);
			Instantiate (arrowUltra, spot, Quaternion.Euler (0.0f,180.0f,0.0f));	
		}
	}

	private void activateEarthquakeUltra()
	{
		for (int i = 0; i < 10; i++) 
		{
			Vector3 spot = new Vector3 (-8.0f + i*2.0f, -1.0f,-1.0f);
			Instantiate (earthquakeUltra,spot,Quaternion.identity);
		}

	}

	private void activateSongUltra()
	{
		harp.SetActive (true);
		Vector3 spot = player.transform.position;
		Instantiate (songUltra, spot, Quaternion.identity);

	}
}
