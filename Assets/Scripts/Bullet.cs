using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	private Rigidbody rb;
	private string parentName;
	public float speed = 500;
	
	void Start(){
		rb = GetComponent<Rigidbody>();
	}

	// Mover a bala
	void Update () {
		// Mover a bala em direção e velocidade constante
		//transform.position += transform.forward * Time.deltaTime * speed;
		rb.MovePosition(transform.position + transform.forward * Time.deltaTime * speed);
	}

	// Colisão
	void OnTriggerEnter(Collider other){
		if(other.gameObject.name != parentName){
			if(other.gameObject.tag == "Player"){
				//Destroy(other.gameObject); // usar método Death quando existir
				other.gameObject.GetComponent<PlayerStatus>().Death();
			}
			Destroy(this.gameObject);
		}
	}

	public void SetParentName(string name){
		parentName = name;
	}
}
