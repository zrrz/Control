using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float maxHealth;
	float curHealth;

	void Start () {
	
	}

	void Update () {
	
	}

	void Hit(float damage) {
		curHealth -= damage;
		if(curHealth <= 0f) {
			animation.Stop ();
			animation.enabled = false;
			rigidbody.isKinematic = false;
			rigidbody.AddForce (100f * (transform.position - Camera.main.transform.position).normalized);
			transform.GetChild (0).GetComponent<TextMesh> ().text = "Bleh";
		}
	}
}
