using UnityEngine;
using System.Collections;

public class DamageOnContact : MonoBehaviour {

	private Health player;
	public float damage;


	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {
						player = other.GetComponent<Health> ();
						player.Damage (damage);
				}

	}
}
