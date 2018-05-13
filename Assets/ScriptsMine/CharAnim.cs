using UnityEngine;
using System.Collections;

public class CharAnim : MonoBehaviour {

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
				animator.SetBool("jump",false);
				animator.SetBool("attack",false);
				animator.SetBool("walk",false);
				timerOn = false;
				elapsedTime = 0.0f;
			}
			
		}
	}
	
	public void Die()
	{
		animator.SetBool ("die", true);
	}
	
	public void Jump()
	{
		animator.SetBool ("jump", true);
		timerOn = true;
	}
	
	public void Attack()
	{
		animator.SetBool ("attack", true);
		timerOn = true;
	}
	
	public void Walk()
	{
		animator.SetBool ("walk", true);
		timerOn = true;
	}
	
	
}