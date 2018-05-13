using UnityEngine;
using System.Collections;

public class MyAnimator : MonoBehaviour {

	protected Animator animator;
	private float elapsedTime = 0.0f;
	private bool timerOn = false;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (timerOn) {
			elapsedTime += Time.deltaTime;
			if (elapsedTime > 0.1f)
			{
				animator.SetBool("flinch",false);
				animator.SetBool("thrash",false);
				animator.SetBool("tentaclehit",false);
				animator.SetBool("swim",false);
				timerOn = false;
				elapsedTime = 0.0f;
			}
		
		}
	}

	public void isHit()
	{
		animator.SetBool ("flinch", true);
		timerOn = true;
	}

	public void thrashAnim()
	{
		animator.SetBool ("thrash", true);
		timerOn = true;
	}

	public void hitTentacleAnim()
	{
		animator.SetBool ("tentaclehit", true);
		timerOn = true;
	}

	public void swimAnim()
	{
		animator.SetBool ("swim", true);
		timerOn = true;
	}


}
