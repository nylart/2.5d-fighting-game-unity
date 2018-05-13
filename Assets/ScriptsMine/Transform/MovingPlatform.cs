using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {
	
	public float endTime;
	public float xDistance;
	public float yDistance;

	private Vector3 start;
	private Vector3 end;
	private float elapsedTime;
	private bool initialDirection;
	private bool endOnTopRow=false;
	private bool loopOnce = false;
	private bool stayStill = false;
	
	void Start () {
		start = new Vector3(transform.position.x,transform.position.y,transform.position.z);
		end = new Vector3(transform.position.x + xDistance,
		                  transform.position.y + yDistance,
		                  transform.position.z);

		elapsedTime = 0.0f;
		initialDirection = true;
	}

	void Update () {
		if (!stayStill) {
						elapsedTime += Time.deltaTime; 
						float lerp_elapsed_time = elapsedTime / endTime;

						if (initialDirection)
								transform.position = Vector3.Lerp (start, end, lerp_elapsed_time);
						else 
								transform.position = Vector3.Lerp (end, start, lerp_elapsed_time);

						if (lerp_elapsed_time >= 1.0f) {
								elapsedTime = 0.0f;
								initialDirection = !initialDirection;
								if(endOnTopRow && !initialDirection)
									stayStill = true;
						}
				}
	}

	public void EndOnTopRow()
	{endOnTopRow = true;}
	public void LoopOnce()
	{loopOnce = true;}
	public void StayStill(bool status)
	{stayStill = status;}
}
