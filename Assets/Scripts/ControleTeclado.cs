using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleTeclado : MonoBehaviour {

	private Rigidbody rb;
	private float timeToShoot;
	private float timeToShoot2;
	private float protectionCount;
	private Animator anim;
	public float moveSpeed = 100f;
	public GameObject bullet;
	public GameObject bomb;
	public GameObject protEffect;
	public Vector3 bulletOffset;
	public Vector3 grenadeOffset;
	public Color bulletColor;
	public float shotDelay = 1f;
	public float shotDelay2 = 3f;
	public float protectionTime = 5f;
	public AudioSource shootSFX;
	
	void Start(){
		timeToShoot = 0;
		timeToShoot2 = 0;
		protectionCount = 0;
		rb = GetComponent<Rigidbody>();
		anim = GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

		// Mover personagem
		Move();
		
		// Virar personagem
		Turn();

		// Atirar
		Shoot();

		//Granadas
		Grenade();		

		Invulnerable();
	}

	// Mover personagem
	void Move(){
		var leftX = Input.GetAxis("Horizontal");
        var leftY = Input.GetAxis("Vertical");
		var movement = new Vector3(-leftY, 0f, leftX);
		rb.MovePosition(rb.position + movement*moveSpeed*Time.deltaTime);
		anim.SetFloat("Speed", movement.magnitude);

		// Limites de cenário (hardcoded)
		//rb.position = new Vector3(Mathf.Clamp (rb.position.x, 70, 450),
		//							rb.position.y,
		//							Mathf.Clamp (rb.position.z, 10, 489));
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
			shootSFX.Play();
			var shot = Instantiate(bullet, transform.position, transform.rotation);
			shot.transform.Translate(bulletOffset);
			shot.GetComponent<Bullet>().SetParentName(this.name);
			shot.GetComponent<MeshRenderer>().material.color = bulletColor;
			timeToShoot = shotDelay;
		}
	}

	// Arremessar Granada
	void Grenade(){
		if(timeToShoot2 > 0) 
			timeToShoot2 -= Time.deltaTime;

		if(Input.GetButtonDown("Fire2") && timeToShoot2 <= 0){
			var shot = Instantiate(bomb, transform.position, transform.rotation);
			shot.transform.Translate(grenadeOffset);
			shot.GetComponent<BulletBomb>().SetParentName(this.gameObject.name);
			timeToShoot2 = shotDelay2;
		}	
	}

	// Invulnerabilidade
	void Invulnerable(){
		if (protectionCount > 0){
			protectionCount -= Time.deltaTime;
			if (protectionCount <= 0){
				GetComponent<PlayerStatus>().isProtected = false;
			}
		}

		if (Input.GetButtonDown("Jump") && GetComponent<PlayerStatus>().useProtection()){
			protectionCount = protectionTime;
			var effect = Instantiate(protEffect,transform.position,transform.rotation);
			effect.transform.SetParent(this.transform);
		}
	}
}
