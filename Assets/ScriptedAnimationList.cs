using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScriptedAnimationList : MonoBehaviour {

//	[SerializeField]
	public ScriptedAnimation[] scriptedAnimations;

	Animation generatedAnimation;

	void Start() {
		GenerateAnimation ();
		animation.Play ("playerAnim");
	}

	public void GenerateAnimation() {
		AnimationCurve curveXPos = new AnimationCurve ();
		AnimationCurve curveZPos = new AnimationCurve ();

		AnimationCurve curveXRot = new AnimationCurve ();
		AnimationCurve curveYRot = new AnimationCurve ();
		AnimationCurve curveZRot = new AnimationCurve ();
		float elapsedTime = 0f;

		Vector3 pos = transform.position;
		Vector3 rot = transform.GetChild(0).eulerAngles;

		for(int i = 0; i < scriptedAnimations.Length; i++) {
			switch(scriptedAnimations[i].action) {
			case ScriptedAnimation.Action.Pause:
				if(!KeyExistsAtTime(curveXPos, elapsedTime))
					curveXPos.AddKey(elapsedTime, pos.x);
				if(!KeyExistsAtTime(curveZPos, elapsedTime))
					curveZPos.AddKey(elapsedTime, pos.z);

				if(!KeyExistsAtTime(curveXRot, elapsedTime))
					curveXRot.AddKey(elapsedTime, rot.x);
				if(!KeyExistsAtTime(curveYRot, elapsedTime))
					curveYRot.AddKey(elapsedTime, rot.y);
				if(!KeyExistsAtTime(curveZRot, elapsedTime))
					curveZRot.AddKey(elapsedTime, rot.z);

				elapsedTime += scriptedAnimations[i].time;

				curveXPos.AddKey(elapsedTime, pos.x);
				curveZPos.AddKey(elapsedTime, pos.z);

				curveXRot.AddKey(elapsedTime, rot.x);
				curveYRot.AddKey(elapsedTime, rot.y);
				curveZRot.AddKey(elapsedTime, rot.z);

				break;
			}
		}

		AnimationClip clip = new AnimationClip();
		clip.SetCurve("", typeof(Transform), "localPosition.x", curveXPos);
		clip.SetCurve("", typeof(Transform), "localPosition.z", curveZPos);
		clip.SetCurve("", typeof(Transform), "localRotation.x", curveXRot);
		clip.SetCurve("", typeof(Transform), "localRotation.y", curveYRot);
		clip.SetCurve("", typeof(Transform), "localRotation.z", curveZRot);
		animation.AddClip(clip, "playerAnim");
	}

	bool KeyExistsAtTime(AnimationCurve curve, float time) {
		for(int i = 0; i < curve.keys.Length; i++) {
			if(curve.keys[i].time == time)
				return true;
		}
		return false;
	}
}