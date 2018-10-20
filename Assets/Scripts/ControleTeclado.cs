using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleTeclado : MonoBehaviour {

	private Rigidbody rb;
	private float timeToShoot;
	public GameObject bullet;
	public Color bulletColor;
	public float shotDelay = 0.5f;
	
	void Start(){
		timeToShoot = 0;
		rb = GetComponent<Rigidbody>();
		
	}
	
	// Update is called once per frame
	void Update () {

		// Mover personagem
		var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");
		var movement = new Vector3(-v*100f, 0f, h*100f);
		transform.Translate(movement*Time.deltaTime, Space.World);

		// Limites de cenário (melhorar)
		rb.position = new Vector3
		(
			Mathf.Clamp (rb.position.x, 70, 450),
			rb.position.y,
			Mathf.Clamp (rb.position.z, 10, 489)
		);
		
		// Virar personagem
		var rZ = Input.GetAxis("Horizontal_2");
        var rX = Input.GetAxis("Vertical_2");
		var direction = new Vector3(-rX, 0, rZ);
		if(direction != Vector3.zero)
			rb.transform.forward = direction;

		// Tempo entre tiros
		if(timeToShoot > 0) 
			timeToShoot -= Time.deltaTime;

		// Atirar
		if(Input.GetButtonDown("Fire1") && timeToShoot <= 0){
			var shot = Instantiate(bullet, transform.position, transform.rotation);
			shot.GetComponent<PlayerBullet>().SetParentName(this.name);
			shot.GetComponent<MeshRenderer>().material.color = bulletColor;
			timeToShoot = shotDelay;
		}
	}
}
