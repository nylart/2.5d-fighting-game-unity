using UnityEngine;
using System.Collections;

public class WinLoseMessage : MonoBehaviour {

	public GameObject win;
	public GameObject lose;
	private bool gameOver = false;

	private float elapsedTime = 0.0f;
	private bool dead = false;
	// Use this for initialization
	void Start () {
		lose.SetActive (false);
		win.SetActive (false);
	}

	void Update(){
		elapsedTime += Time.deltaTime;
		if (dead && elapsedTime > 3.0f)
						lose.SetActive (true);
	}

	public void playerDied()
	{
		elapsedTime = 0.0f;
		//lose.SetActive (true);
		dead = true;
		gameOver = true;
	}
	public void enemyDied()
	{
		win.SetActive (true);
		gameOver = true;
	}
	public bool IsGameOver()
	{
		return gameOver;
	}
}
