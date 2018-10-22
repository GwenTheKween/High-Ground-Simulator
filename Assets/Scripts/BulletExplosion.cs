using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletExplosion : MonoBehaviour {

	private Rigidbody rb;
	public float size = 10f;

	void Start(){
		rb = GetComponent<Rigidbody>();
		transform.localScale = new Vector3(size,size,size);
	}

	// Colisão
	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Player"){
			other.gameObject.GetComponent<PlayerStatus>().Death();
		}
	}

	void KillSelf(){
		Destroy(this.gameObject);
	}
}
