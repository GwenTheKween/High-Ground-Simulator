using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBomb : MonoBehaviour {

	private Rigidbody rb;
	private string parentName;
	public float speed = 300f;
	public float verticalSpeed = 5f;
	public float gravity = 20f;
	public float size = 10f;
	public GameObject bomb;
	
	void Start(){
		rb = GetComponent<Rigidbody>();
		transform.localScale = new Vector3(size,size,size);
		transform.position += (transform.forward/transform.forward.magnitude)*20;
	}

	// Mover a bala
	void Update () {
		// Mover a bala em direção e velocidade constante
		//transform.position += transform.forward * Time.deltaTime * speed;
		verticalSpeed -= gravity*Time.deltaTime;
		rb.MovePosition(transform.position + transform.forward * Time.deltaTime * speed + 
		(new Vector3(0,verticalSpeed,0)));
	}

	// Colisão
	void OnTriggerEnter(Collider other){
		if(other.gameObject.name != parentName){
			var explode = Instantiate(bomb, transform.position, transform.rotation);
			explode.GetComponent<MeshRenderer>().material.color = this.GetComponent<MeshRenderer>().material.color;
			Destroy(this.gameObject);
		}
	}

	public void SetParentName(string name){
		parentName = name;
	}
}
