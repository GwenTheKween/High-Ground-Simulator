using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDetection : MonoBehaviour {

	public GameObject parent;

	void Update(){
		if (parent == null){
			Destroy(this.gameObject);
			return;
		}
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Bullet"){
			parent.GetComponent<BulletBomb>().Explode();
			Destroy(this.gameObject);
		}		
	}
}
