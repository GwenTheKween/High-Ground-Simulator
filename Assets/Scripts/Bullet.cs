using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	private Rigidbody rb;
	private string parentName;
	public float speed = 500f;
	public float size = 6f;
	
	void Start(){
		rb = GetComponent<Rigidbody>();
		transform.localScale = new Vector3(size,size,size);
	}

	// Mover a bala
	void Update () {
		// Mover a bala em direção e velocidade constante
		//transform.position += transform.forward * Time.deltaTime * speed;
		rb.MovePosition(transform.position + transform.forward * Time.deltaTime * speed);
	}

	// Colisão
	void OnTriggerEnter(Collider other){
		if(other.gameObject.name != parentName && other.gameObject.tag != "Region"){
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
