using UnityEngine;
using System.Collections;

public class ZoneAttacks : MonoBehaviour {
	
	public GameObject proj;
	public GameObject tentacleHit;
	public GameObject thrash;
	public GameObject chokehold;

	private float[] row = {7.0f,2.0f};
	private float[] col = {-6.5f,-3.5f,-0.5f,2.5f};
	private Vector3 spot;
	private Vector3 zone1;  private Vector3 zone2;  
	private Vector3 zone3;  private Vector3 zone4;  
	private Vector3 zone5;  private Vector3 zone6;
	private Vector3 zone7;  private Vector3 zone8;

	private int RNG;
	private int thrashCount = 0;
	private float elapsedTime = 0.0f;

	private MyAnimator anim;

	void Start()
	{
		zone1 = new Vector3(col[0],row[0],0.0f);
		zone2 = new Vector3(col[1],row[0],0.0f);
		zone3 = new Vector3(col[2],row[0],0.0f);
		zone4 = new Vector3(col[3],row[0],0.0f);
		zone5 = new Vector3(col[0],row[1],0.0f);
		zone6 = new Vector3(col[1],row[1],0.0f);
		zone7 = new Vector3(col[2],row[1],0.0f);
		zone8 = new Vector3(col[3],row[1],0.0f);

		anim = GetComponent<MyAnimator> ();
	
	}

	void Update()
	{
		elapsedTime += Time.deltaTime;
		if (Input.GetKey (KeyCode.Q))
						EnemyProj (0);
		if(Input.GetKey (KeyCode.W))
			OneOfLeftThreeZones(1);
		if (Input.GetKey (KeyCode.E))
						Thrash ();
		if (Input.GetKey (KeyCode.R))
						BothRightTwo (0);
	}

	//BUBBLEBEAM
	public void EnemyProj(int rowIndex) //projectile travels through one row
	{
		spot = new Vector3(5.0f, row [rowIndex], 0.0f);
		Instantiate(proj, spot, Quaternion.Euler (0.0f,180.0f,0.0f));

	}

	//TENTACLE HIT
	public void OneOfLeftThreeZones(int rowIndex) //
	{
		int RNG = Random.Range (0, 3);
		if (rowIndex == 1) {
						if (RNG == 0)
								spot = zone6;
						if (RNG == 1)
								spot = zone7;
						if (RNG == 2)
								spot = zone8;
				} else {
						if (RNG == 0)
								spot = zone3;
						if (RNG == 1)
								spot = zone4;
						if (RNG == 2)
								spot = zone5;
				}

		Instantiate (tentacleHit, spot, Quaternion.identity);
		anim.hitTentacleAnim ();
	}

	public bool Thrash()
	{
		if (thrashCount < 5 && elapsedTime > 1.0f) 
		{
			int rowIndex = Random.Range (0,2);
			int colIndex = Random.Range (0,4);
			spot = new Vector3(col[colIndex],row[rowIndex],0.0f);
			Instantiate (thrash, spot, Quaternion.identity);
			elapsedTime = 0.0f;
			anim.thrashAnim();
			return true;
		}
		thrashCount = 0;
		return false;

	}

	//CHOKEHOLD
	public void BothRightTwo(int rowIndex)
	{
		if (rowIndex == 0) 
		{
			Instantiate (chokehold, zone3, Quaternion.identity);
			Instantiate (chokehold, zone4, Quaternion.identity);
			anim.hitTentacleAnim();
		} 
		else 
		{
			Instantiate (chokehold, zone7, Quaternion.identity);
			Instantiate (chokehold, zone8, Quaternion.identity);
			anim.hitTentacleAnim();
		}

	}

	}


