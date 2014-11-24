using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;

[CustomEditor(typeof(ScriptedAnimationList))]
public class ScriptedAnimationListEditor : Editor {

	SerializedProperty scriptedAnimationList;

	void OnInspectorGUI() {
		scriptedAnimationList = serializedObject.FindProperty("scriptedAnimations");
		if (GUILayout.Button ("New")) {
			scriptedAnimationList.InsertArrayElementAtIndex(scriptedAnimationList.arraySize);
			scriptedAnimationList.GetArrayElementAtIndex(scriptedAnimationList.arraySize);
		}
	}
}