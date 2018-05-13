using UnityEngine;
using System.Collections;

public class RandomDrop : MonoBehaviour {

	public GameObject[] powerup;
	public GameObject ultra;
	
	public float spawnTime;
	private float elapsedTime = 0.0f;

	public int powerToUltraRatio;
	private int numPowerupsMade = 0;

	private float[] row = {7.0f,2.0f};
	private float[] col = {-6.5f,-3.5f,-0.5f,2.5f};
	private int rowIndex;
	private int colIndex;

	private bool itemMade = false;
	private bool powered = false;
	private bool playerOnRowOne = false;
	private Vector3 spot;

	private int ultraCount = 0;
	private int RNG;
	
	private ActivateUltra ultraController;

	void Start(){
		GameObject obj = GameObject.FindWithTag ("GameController");
		ultraController = obj.GetComponent<ActivateUltra> ();
		}

	void Update () {
	
		elapsedTime += Time.deltaTime;

		if (elapsedTime >= spawnTime) 
		{
			if (!itemMade && !powered)
			{
				while(true)
				{
					RNG = Random.Range (0,8);
					if (RNG < 4 && !playerOnRowOne) 
						break;
					else if (RNG >=4 && playerOnRowOne)
						break;
				}

				colIndex = RNG%4;
				if (RNG <4){rowIndex = 0;}
				else {rowIndex = 1;}
				spot = new Vector3(col[colIndex],row[rowIndex],0.0f);

				if(numPowerupsMade >= powerToUltraRatio  && ultraCount < 3)
				{
					numPowerupsMade = 0;
					Instantiate(ultra,spot,Quaternion.Euler (0,90,90));
				}
				else
				{
					numPowerupsMade++;
					RNG = Random.Range (0,3);
					Instantiate (powerup[RNG],spot,Quaternion.Euler (0,90,90));

				}
				itemMade = true;
			}
			elapsedTime = 0.0f;
		}
	}

	public void itemGet()
	{
		itemMade = false;
	}

	public void ultraGet()
	{
		ultraCount ++;
		ultraController.AddUltraBar (ultraCount);
	}
	public void resetUltra()
	{
		ultraCount = 0;
		elapsedTime = 0.0f;
	}

	public void powerSet (bool status)
	{
		powered = status;
	}

	public void playerOnTopRow (bool status)
	{
		playerOnRowOne = status;
	}
}
