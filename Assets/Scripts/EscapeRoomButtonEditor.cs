using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EscapeRoomButton))]
public class EscapeRoomButtonEditor : Editor {
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector ();
		EscapeRoomButton escapeRoomButton = (EscapeRoomButton)target;
		if (GUILayout.Button ("Push Button"))
		{
			escapeRoomButton.PushButton ();
		}
	}
}
