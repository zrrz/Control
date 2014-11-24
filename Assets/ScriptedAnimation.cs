using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class ScriptedAnimation {

	public enum Action {
		MoveToPoint, LookAt
	}

	[SerializeField]
	public Action action;
	[SerializeField]
	public float speed;
}