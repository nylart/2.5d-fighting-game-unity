using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {
	
	public float maxHealth;
	public float curHealth;
	
	public Texture2D bgImage; 
	public Texture2D fgImage; 

	public float x = 300;
	public float y= 66;
	public float myBarLength = 150;

	public GUISkin mySkin;

	public float healthBarLength;

	public GameObject character;
	private Health healthController;

	// Use this for initialization
	void Start () {   
		healthBarLength = 200;//Screen.width /2;    
		healthController = character.GetComponent<Health> ();
	}
	
	// Update is called once per frame
	void Update () {
		float thisHealth = healthController.CurrentHealth;
		AddjustCurrentHealth(thisHealth);
	}
	
	void OnGUI () {

		GUI.skin = mySkin;
		GUIStyle myStyle = GUI.skin.GetStyle ("RedBox");
		// Create one Group to contain both images
		// Adjust the first 2 coordinates to place it somewhere else on-screen
		GUI.BeginGroup (new Rect (x,y, myBarLength,15));
		
		// Draw the background image
		GUI.Box (new Rect (0,0, myBarLength, 15), bgImage);
		
		// Create a second Group which will be clipped
		// We want to clip the image and not scale it, which is why we need the second Group
		GUI.BeginGroup (new Rect (0,0, myBarLength, 15));
		
		// Draw the foreground image
		GUI.Box (new Rect (maxHealth- (curHealth / maxHealth * healthBarLength),0,curHealth / maxHealth * healthBarLength,15), fgImage,myStyle);
		
		// End both Groups
		GUI.EndGroup ();
		
		GUI.EndGroup ();
	}
	
	public void AddjustCurrentHealth(float currentHealth){
		
		curHealth = currentHealth;
		
		if(curHealth <0)
			curHealth = 0;
		
		if(curHealth > maxHealth)
			curHealth = maxHealth;
		
		if(maxHealth <1)
			maxHealth = 1;
		
		healthBarLength =(myBarLength) * (curHealth / maxHealth);
	}
}