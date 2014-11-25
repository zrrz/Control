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

		Repaint ();
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
					ScriptedAnimation.Action actionEnum = (ScriptedAnimation.Action)EditorGUILayout.EnumPopup((ScriptedAnimation.Action)action.enumValueIndex, GUILayout.Width(90f));
					action.enumValueIndex = (int)actionEnum;

					bool showTime = false, showVec3 = false;

					switch (actionEnum) {
					case ScriptedAnimation.Action.LookAt:
						showTime = showVec3 = true;
						break;
					case ScriptedAnimation.Action.MoveToPoint:
						showTime = showVec3 = true;
						break;
					case ScriptedAnimation.Action.Pause:
						showTime = true;
						break;
					case ScriptedAnimation.Action.PopTo:
						break;
					case ScriptedAnimation.Action.TurnEuler:
						showTime = showVec3 = true;
						break;
					case ScriptedAnimation.Action.MoveBy:
						showTime = showVec3 = true;
						break;
					default:
						break;
					}
					if(showTime) {
						SerializedProperty time = property.FindPropertyRelative("time");
						GUILayout.Label("Time", GUILayout.Width(40f));
						time.floatValue = EditorGUILayout.FloatField(time.floatValue, GUILayout.Width(80f));
					}
					GUILayout.EndHorizontal();
					if(showVec3) {
						SerializedProperty point = property.FindPropertyRelative("point");
						EditorGUI.indentLevel++;
						GUILayout.BeginHorizontal();
						EditorGUILayout.LabelField("Point", GUILayout.Width(50f));
						point.vector3Value = EditorGUILayout.Vector3Field("", point.vector3Value, GUILayout.Width(240f));
						GUILayout.EndHorizontal();
						EditorGUI.indentLevel--;
					}
				}
			}
		}
		if (GUILayout.Button ("New")) {
			list.InsertArrayElementAtIndex(list.arraySize);
		}
	}
}