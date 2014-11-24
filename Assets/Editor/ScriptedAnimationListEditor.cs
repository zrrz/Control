using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(ScriptedAnimationList))]
public class ScriptedAnimationListEditor : Editor {

	SerializedProperty scriptedAnimationSerialized;

	public override void OnInspectorGUI() {
		serializedObject.Update ();
		Show(serializedObject.FindProperty("scriptedAnimations"));

		serializedObject.ApplyModifiedProperties ();
	}

	public static void Show(SerializedProperty list) {
		EditorGUILayout.PropertyField(list);
		if(list.isExpanded) {
			for (int i = 0; i < list.arraySize; i++) {
				GUILayout.BeginHorizontal();
				if(GUILayout.Button("-", EditorStyles.toolbarButton, GUILayout.ExpandWidth(false))) {
					list.DeleteArrayElementAtIndex(i);
				} else {
					SerializedProperty property = list.GetArrayElementAtIndex(i);

					SerializedProperty action = property.FindPropertyRelative("action"); 
					action.enumValueIndex = (int)(ScriptedAnimation.Action)EditorGUILayout.EnumPopup((ScriptedAnimation.Action)action.enumValueIndex, GUILayout.Width(90f));

					SerializedProperty speed = property.FindPropertyRelative("speed");
					GUILayout.Label("Speed", GUILayout.Width(40f));
					speed.floatValue = EditorGUILayout.FloatField(speed.floatValue, GUILayout.Width(80f));
				}
				GUILayout.EndHorizontal();
			}
		}
		if (GUILayout.Button ("New")) {
			list.InsertArrayElementAtIndex(list.arraySize);
		}
	}
}