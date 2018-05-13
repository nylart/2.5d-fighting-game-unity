using UnityEngine;
using System.Collections;



public class UILabel : UIElement 
{
	public int depth;
	void OnGUI ( ) {
		
		init();
		GUI.depth = depth;
		if( useCustomStyle ) 
		{


			if( icon ) {
				GUI.Label (elementRect, 
				           icon,
				           elementStyle);
			} else {
				GUI.Label (elementRect, 
				           text,
				           elementStyle);
			}
		} 
		else {
			if( icon ) {
				GUI.Label (elementRect, icon );
			} else {
				GUI.Label (elementRect, text);
			}
		}
		
	}
	

}
