using UnityEngine;
using System.Collections;

public class UIElement : MonoBehaviour {

	[Tooltip("GUISkin to be used by this button")]
	public GUISkin gameSkin;
	[Tooltip("Text if you don't want to use an image.  You cannot use both.")]
	public string text;
	[Tooltip("Image to use instead of text.  You cannot use both.")]
	public Texture2D icon;
	[Tooltip("Pixel width of the element on screen")]
	public float width = 170.0f;
	[Tooltip("Pixel height of the element on screen")]
	public float height = 70.0f;
	[Tooltip("Location of the button on screen")]
	public Vector2 location;
	[Tooltip("If true, Center the button on the screen")]
	public bool center;
	[Tooltip("Only if centered, an offset from center of the screen")]
	public Vector2 offset;
	[Tooltip("If true, use a custom style in the GUISkin")]
	public bool useCustomStyle = false;
	[Tooltip("The name of the custom style to use")]
	public string style;

	protected Rect elementRect;
	protected GUIStyle elementStyle;

	protected void init() {
		GUI.skin = gameSkin;
		if( useCustomStyle ) {
			elementStyle = GUI.skin.GetStyle(style);
		}

		if( center ) {
			location = new Vector2( (Screen.width / 2) - (width/2) + offset.x, 
			                       (Screen.height / 2) - (height/2) + offset.y );
			
		}

		elementRect = new Rect( location.x, location.y, width, height );
	}
}
