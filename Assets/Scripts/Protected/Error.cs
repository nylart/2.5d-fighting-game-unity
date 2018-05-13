using UnityEngine;
using System.Collections;

public static class Error
{

	public enum ErrorType
	{
		Message,
		Warning,
		Error 
	}

	public static void DisabledGameObject( string name, string reason, ErrorType err = ErrorType.Warning )
	{
		string txt = "Disabled GameObject.name = " + name + ".  " + "Reason : " + reason;

		Log( txt, err );
	}

	public static void MissingComponent( string name, string component, ErrorType err = ErrorType.Warning )
	{
		string txt = "Missing Component " + component + " on GameObject.name = " + name + ". It may not function as intended or at all.";
		
		Log( txt, err );
	}

	public static void Inquiry( string name, string behavior, ErrorType err = ErrorType.Warning )
	{
		string txt = "On GameObject.name = " + name + ", did you intend the behavior: " + behavior + "?";

		Log( txt, err );
	}

	private static void Log( string txt, ErrorType err )
	{
		if ( err == ErrorType.Warning ) {
			Debug.LogWarning( txt );
		}
		if ( err == ErrorType.Message ) {
			Debug.Log( txt );
		}
		if ( err == ErrorType.Error ) {
			Debug.LogError( txt );
		}
	}
}
