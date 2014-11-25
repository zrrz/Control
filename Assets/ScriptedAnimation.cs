using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class ScriptedAnimation {

	public enum Action {
		PopTo, MoveToPoint, LookAt, Pause, TurnEuler
	}

	[SerializeField]
	public Action action;
	[SerializeField]
	public float time;
	[SerializeField]
	public Vector3 point;
}