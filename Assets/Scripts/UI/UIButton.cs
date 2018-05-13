using UnityEngine;
using System.Collections;

public class UIButton : UIElement
{
	[Tooltip("Link to script to be called on button press")]
	public MonoBehaviour script;
	[Tooltip("Name of function to call on button press")]
	public string functionToInvoke;
	
	void OnGUI( ) 
	{
		init();  // required to be called first

		if( useCustomStyle ) {
			if( icon ) {
				if( GUI.Button (elementRect, icon, elementStyle) )
				{
					script.Invoke( functionToInvoke, 0 );
				}
			} else {
				if( GUI.Button ( elementRect, text, elementStyle) )
				{
					script.Invoke( functionToInvoke, 0 );
				}
			}
		} else {
			if( icon ) {
				if( GUI.Button (elementRect, icon) )
				{
					script.Invoke( functionToInvoke, 0 );
				}
			} else {
				if( GUI.Button ( elementRect, text) )
				{
					script.Invoke( functionToInvoke, 0 );
				}
			}
		}
	}
}
