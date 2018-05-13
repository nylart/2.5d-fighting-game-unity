using UnityEngine;
using System.Collections;

public class UICrosshair : MonoBehaviour {

	[Tooltip("The Texture used for the crosshair image")]
	public Texture2D crosshairImage;
	[Tooltip("The width of the crosshair on screen")]
	public float width = 50.0f;
	[Tooltip("The height of the crosshair on screen")]
	public float height = 50.0f;
	
	void OnGUI() 
	{
		if ( crosshairImage ) {
			float xMin = (Input.mousePosition.x) - (width / 2);
			float yMin = (Screen.height - Input.mousePosition.y) - (height / 2);
			GUI.DrawTexture(new Rect(xMin, yMin, width, height), crosshairImage);
		}
	}
}
