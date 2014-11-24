using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class ScriptedAnimation : MonoBehaviour {

	public enum Action {
		MoveToPoint, LookAt
	}

	public Action action;
	public float speed;
}