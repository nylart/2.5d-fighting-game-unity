#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(TooltipAttribute))]
public class TooltipDrawer : PropertyDrawer
{
	public override void OnGUI(Rect position, SerializedProperty prop, GUIContent label)
	{
		var atr = (TooltipAttribute) attribute;
		var content = new GUIContent(label.text, atr.text);
		EditorGUI.PropertyField(position, prop, content);
	}
}
#endif