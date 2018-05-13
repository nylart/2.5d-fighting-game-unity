using UnityEngine;
using System.Collections;

public class WeaponAnim : MonoBehaviour {
	
	public float xRPM = 0.0f;
	public float yRPM = 0.0f;
	public float zRPM = 60.0f;

	public float endTime = 1.0f;
	private float elapsedTime = 0.0f;
	public bool attacking = false;
	public bool initialDirection = true;
	public bool fresh = true;

	// Update is called once per frame
	void Update () {
		elapsedTime += Time.deltaTime;
		if (attacking) 
		{
			transform.Rotate (xRPM * Time.deltaTime, yRPM * Time.deltaTime, zRPM * Time.deltaTime*2);
			if (elapsedTime >= endTime/2.0f) {
				xRPM = -xRPM;
				yRPM = -yRPM;
				zRPM = -zRPM;
				if(initialDirection)
				{
					elapsedTime = 0.0f;
					initialDirection = false;
				}
				else 
				{
					attacking = false;
					fresh = true;
				}
			}
		}


	}

	public void setAttacking()
	{
		if (fresh) {
						initialDirection = true;
						attacking = true;
						elapsedTime = 0.0f;
			fresh = false;
				}
	}
}

