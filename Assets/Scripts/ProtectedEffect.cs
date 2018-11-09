using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtectedEffect : MonoBehaviour {

	public float timeToDestroy = 5f;

	void Start(){
		GetComponent<Animation>().Play("Invulnerability");
	}

	void Update(){
		timeToDestroy -= Time.deltaTime;
		if (timeToDestroy <= 0.1)
			GetComponent<Animation>().Play("InvulnerabilityFadeOut");
	}
	public void Destruction(){
		Destroy(this.gameObject);
	}
}
