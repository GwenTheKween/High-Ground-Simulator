using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	private Rigidbody rb;
	private string parentName;
	public float speed = 500f;
	public float size = 6f;
	public float lifeTime = 10f;
	public GameObject spawnParticle;
	public GameObject destroyParticle;
	
	void Start(){
		rb = GetComponent<Rigidbody>();
		transform.localScale = new Vector3(size,size,size);
		var particles = Instantiate(spawnParticle,transform.position,transform.rotation);
		particles.transform.localScale = new Vector3(size,size,size);
		rb.velocity = transform.forward*speed;
	}

	// Mover a bala
	void Update () {
		if(lifeTime < 0) Destroy(this.gameObject);
		lifeTime -= Time.deltaTime;

		// Mover a bala em direção e velocidade constante
		//transform.position += transform.forward * Time.deltaTime * speed;
		//rb.MovePosition(transform.position + transform.forward * Time.deltaTime * speed);
	}

	// Colisão
	void OnTriggerEnter(Collider other){
		if(other.gameObject.name != parentName && other.gameObject.tag != "Region" && other.gameObject.tag != "Bullet"
												&& other.gameObject.tag != "MapLimit"){
			Destroy(this.gameObject);
			var particles = Instantiate(destroyParticle,transform.position,Quaternion.identity);
			particles.transform.localScale = new Vector3(size,size,size);
			
			if(other.gameObject.tag == "Player" && !other.GetComponent<PlayerStatus>().isProtected){
				other.gameObject.GetComponent<PlayerStatus>().Death();
			}
		}
	}

	public void SetParentName(string name){
		parentName = name;
	}
}
