using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SphereCollider))]

/// <summary>
/// Abstract event. Mark collider as trigger
/// </summary>
public abstract class PathEvent : MonoBehaviour {

	protected bool started = false;

	/// <summary>
	/// Starts the event.
	/// </summary>
	protected virtual void StartEvent() {
		if(!started) {
			started = true;
		}
	}

	void Update () {
		
	}
	
	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "Player")
			StartEvent ();
	}
}