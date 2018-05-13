using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

	public float xRPM = 0.0f;
	public float yRPM = 0.0f;
	public float zRPM = 0.0f;

	public bool die = false;
	public float elapsedTime = 0.0f;

	// Update is called once per frame
	void Update () {
		elapsedTime += Time.deltaTime;
		if (die && elapsedTime < 1.0f) {
			transform.Rotate (0.0f, 0.0f, -90 * Time.deltaTime);	
		}

		else
		transform.Rotate (xRPM * Time.deltaTime, yRPM * Time.deltaTime, zRPM * Time.deltaTime);
	}

	public void Die()
	{
		die = true;
		elapsedTime = 0.0f;
	}

}
