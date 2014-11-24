using UnityEngine;
using System.Collections;

/// <summary>
/// Animation and time to play the animation.
/// </summary>
[System.Serializable]
public class AnimationAndTime {
	public AnimationAndTime(GameObject p_animatedObject, float p_timeToPlay, bool p_pauseGameTillDone = false) {
		animatedObject = p_animatedObject;
		timeToPlay = p_timeToPlay;
//		pauseGameTillDone = p_pauseGameTillDone;
	}
	public GameObject animatedObject;
	public float timeToPlay;
//	public bool pauseGameTillDone; // Maybe unnecessary 
}