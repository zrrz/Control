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
				GUILayout.BeginHorizontal();
					if( GUILayout.Button("-", EditorStyles.toolbarButton, GUILayout.ExpandWidth(false)) ) {
						//TODO Send message to inspector window to use demon magic to delete from the list
					}
					anim.action = (ScriptedAnimation.Action) EditorGUILayout.EnumPopup("Action", anim.action);
					anim.time = EditorGUILayout.FloatField("Time", anim.time);
				GUILayout.EndHorizontal();

				switch( anim.action )
				{
				case ScriptedAnimation.Action.TurnEuler:
				case ScriptedAnimation.Action.MoveToPoint:
				case ScriptedAnimation.Action.PopTo:
				case ScriptedAnimation.Action.MoveBy:
				case ScriptedAnimation.Action.LookAt:
					anim.point = EditorGUILayout.Vector3Field( "Point", anim.point );
					break;
				case ScriptedAnimation.Action.Pause:
					break;
				}
			}
		
			if( GUILayout.Button( "Add new", EditorStyles.toolbarButton, GUILayout.ExpandWidth( false ) ) ) {
				//TODO Demon magic that creates another ScriptedAnimation
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