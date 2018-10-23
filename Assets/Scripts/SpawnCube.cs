using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCube : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		if (other.tag != "Bullet" && other.tag != "Bomb"){
			var pos = new Vector3(Random.Range(70f,450f),17f, 20f);
			other.transform.position = pos;
		}
	}
	
}
