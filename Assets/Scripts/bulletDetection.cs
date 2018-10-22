using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletDetection : MonoBehaviour {

	public GameObject parent;

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Bullet"){
			if (parent == null){
				Destroy(this.gameObject);
				return;
			}
			parent.GetComponent<BulletBomb>().Explode();
			Destroy(this.gameObject);
		}
	}
}
