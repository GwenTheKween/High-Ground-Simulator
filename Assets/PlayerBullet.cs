using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour {

	private string parentName;
	public float speed = 500;
	
	void Update () {
		// Mover a bala em direção e velocidade constante
		transform.position += transform.forward * Time.deltaTime * speed;
	}

	// Colisão com player
	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Player" && other.gameObject.name != parentName){
			Destroy(other.gameObject); // usar método Death quando existir
			Destroy(this.gameObject);
		}
	}

	public void SetParentName(string name){
		parentName = name;
	}
}
