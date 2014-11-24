using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AnimationEvent : PathEvent {
	
	public List<AnimationAndTime> animsToPlay;

	float startTime = 0f;

	/// <summary>
	/// Starts the animation event.
	/// </summary>
	protected override void StartEvent () {
		base.StartEvent ();
		startTime = Time.time;
	}

	void Update () {
		if(started) {
			for(int i = 0; i < animsToPlay.Count; i++) {
				if(Time.time - startTime > animsToPlay[i].timeToPlay) {
					if(null == animsToPlay[i].animatedObject) {
						Debug.LogError("Missing animatedGameObject ref");
						return;
					}
					animsToPlay[i].animatedObject.SetActive(true);
					if(!animsToPlay[i].animatedObject.animation.isPlaying)
						animsToPlay[i].animatedObject.animation.Play();
					animsToPlay.RemoveAt(i);
					i--;
				}
			}
		}
	}
}