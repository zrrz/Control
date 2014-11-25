using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class ScriptedAnimationEditorWindow : EditorWindow {

	ScriptedAnimation[] scriptedAnimations;

	[MenuItem("ScriptedAnimation/Editor")]
	public static void ShowWindow() {
		EditorWindow.GetWindow (typeof(ScriptedAnimationEditorWindow), true, "Scripted Animation Editor", true);
	}

	void OnGUI() {
		if(null != scriptedAnimations) {
			Debug.Log("showing");
			GUILayout.Label("Events"); 
			foreach(ScriptedAnimation anim in scriptedAnimations) {
				anim.action = (ScriptedAnimation.Action) EditorGUILayout.EnumPopup("Action", anim.action);
				anim.time = EditorGUILayout.FloatField("Time", anim.time);
			}

		} else {
			GUILayout.Label("No ScriptedAnimationList found");
		}
	}

	void OnSelectionChange() {
		if(null == Selection.activeGameObject) {
			scriptedAnimations = null;
			return;
		}
		ScriptedAnimationList activeObjList = Selection.activeGameObject.GetComponent<ScriptedAnimationList> ();
		if (null != activeObjList) {
			scriptedAnimations = activeObjList.scriptedAnimations;
			Debug.Log("Found");
		} else {
			Debug.Log("Not found");
			scriptedAnimations = null;
		}
		Repaint ();
	}
}