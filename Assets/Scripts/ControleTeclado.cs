using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleTeclado : MonoBehaviour {

	private Rigidbody rb;
	private float timeToShoot;
	public float moveSpeed = 100f;
	public GameObject bullet;
	public Color bulletColor;
	public float shotDelay = 1f;
	
	void Start(){
		timeToShoot = 0;
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

		// Mover personagem
		Move();
		
		// Virar personagem
		Turn();

		// Atirar
		Shoot();
		
	}

	// Mover personagem
	void Move(){
		var leftX = Input.GetAxis("Horizontal");
        var leftY = Input.GetAxis("Vertical");
		var movement = new Vector3(-leftY, 0f, leftX);
		rb.MovePosition(rb.position + movement*moveSpeed*Time.deltaTime);

		// Limites de cenário (hardcoded)
		rb.position = new Vector3(Mathf.Clamp (rb.position.x, 70, 450),
									rb.position.y,
									Mathf.Clamp (rb.position.z, 10, 489));
	}

	// Virar personagem
	void Turn(){
		var rZ = Input.GetAxis("Horizontal_2");
        var rX = Input.GetAxis("Vertical_2");
		var direction = new Vector3(-rX, 0, rZ);
		if(direction != Vector3.zero)
			rb.transform.forward = direction;
	}

	// Atirar com a arma
	void Shoot(){
		// Tempo entre tiros
		if(timeToShoot > 0) 
			timeToShoot -= Time.deltaTime;

		// Atirar
		if(Input.GetButtonDown("Fire1") && timeToShoot <= 0){
			var shot = Instantiate(bullet, transform.position, transform.rotation);
//			shot.GetComponent<Bullet>().SetParentName(this.name);
			shot.GetComponent<BulletBomb>().SetParentName(this.name);
			shot.GetComponent<MeshRenderer>().material.color = bulletColor;
			timeToShoot = shotDelay;
		}
	}

	// Arremessar Granada
	void Grenade(){
		
	}

	// Invulnerabilidade
	void Invulnerable(){
		
	}
}
