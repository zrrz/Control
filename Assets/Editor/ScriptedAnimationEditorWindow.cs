using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class ScriptedAnimationEditorWindow : EditorWindow {

	List<ScriptedAnimation> scriptedAnimations;

	[MenuItem("ScriptedAnimation/Editor")]
	public static void ShowWindow() {
		EditorWindow.GetWindow (typeof(ScriptedAnimationEditorWindow), true, "Scripted Animation Editor", true);
	}

	void OnGUI() {
		if(null != scriptedAnimations) {
			GUILayout.Label("Events"); 
			foreach(ScriptedAnimation anim in scriptedAnimations) {

				anim.action = (ScriptedAnimation.Action) EditorGUILayout.EnumPopup("Action", anim.action);
				anim.speed = EditorGUILayout.FloatField("Speed", anim.speed);
			}
		} else {
			GUILayout.Label("No ScriptedAnimationList found");
		}
	}

	void OnSelectionChange() {
		ScriptedAnimationList scriptedAnimationList = Selection.activeGameObject.GetComponent<ScriptedAnimationList> ();
		if(null != scriptedAnimationList) {
			scriptedAnimations = scriptedAnimationList.scriptedAnimations;
		} else {
			scriptedAnimations = null;
		}
		Repaint ();
	}
}