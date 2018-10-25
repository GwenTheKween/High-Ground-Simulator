using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBomb : MonoBehaviour {

	private Rigidbody rb;
	private GameObject detect;
	private string parentName;
	public float speed = 300f;
	public float verticalSpeed = 5f;
	public float gravity = 20f;
	public float size = 10f;
	public GameObject bomb;
	public GameObject bulletDetector;
	public Color parentColor;
	
	void Start(){
		rb = GetComponent<Rigidbody>();
		transform.localScale = new Vector3(size,size,size);
		detect = Instantiate(bulletDetector, transform.position, transform.rotation);
		detect.GetComponent<bulletDetection>().parent = this.gameObject;
	}

	// Mover a bala
	void Update () {
		// Mover a bala em direção e velocidade constante com aplicação de gravidade
		verticalSpeed -= gravity*Time.deltaTime;
		rb.MovePosition(transform.position + transform.forward * Time.deltaTime * speed + 
		(new Vector3(0,verticalSpeed,0)));
		detect.transform.position = this.transform.position;
	}

	// Colisão
	void OnTriggerEnter(Collider other){
		if(other.gameObject.name != parentName && other.gameObject.tag != "Detector" && other.gameObject.tag != "Region"){
			Explode();
		}
	}

	public void Explode(){
		var explode = Instantiate(bomb, transform.position, transform.rotation);
		explode.GetComponent<MeshRenderer>().material.color = parentColor;
		Destroy(this.gameObject);
	}

	public void SetParentName(string name){
		parentName = name;
	}
}
