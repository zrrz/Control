using UnityEngine;
using System.Collections;

public class ShotManager : MonoBehaviour {

	public static ShotManager s_instance;

	public GameObject hitParticle;

	public LayerMask hitMask;

	void Start () {
		s_instance = this;
	}

	void Update () {
		//Temp until I make FakeOSC
		if(Input.GetButtonDown("Fire1")) {
			ShotManager.Shoot(Input.mousePosition);
		}
	}

	public static void Shoot(float x, float y) {
		Shoot(new Vector2(x, y));
	}

	public static void Shoot(Vector2 pos) {
		if (null == s_instance) {
			Debug.LogError("No ShotManager in scene");
			return;
		}
		RaycastHit hit;
		if (Physics.Raycast (Camera.main.ScreenPointToRay (pos), out hit, 100f, s_instance.hitMask)) {
			hit.collider.SendMessage("Hit", 1f, SendMessageOptions.DontRequireReceiver);
			//TODO different particle depending on what you hit
			GameObject particle = (GameObject)Instantiate(s_instance.hitParticle, hit.point, Quaternion.identity);
			particle.transform.rotation = Quaternion.LookRotation(hit.normal, particle.transform.forward);
		}
	}
}