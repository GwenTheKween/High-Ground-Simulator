using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

    private Rigidbody rb;
	private float timeToShoot;
    public float torque;
	public GameObject bullet;
	public Color bulletColor;
	public float shotDelay = 1f;

	// Use this for initialization
	void Start () {
		timeToShoot = 0;
		rb=gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		rb.AddTorque(transform.up*torque);

		// Tempo entre tiros
		if(timeToShoot > 0)
			timeToShoot -= Time.deltaTime;

		// Atirar
		if(timeToShoot <= 0){
			var shot = Instantiate(bullet, transform.position, transform.rotation);
			shot.GetComponent<Bullet>().SetParentName(this.name);
			shot.GetComponent<MeshRenderer>().material.color = bulletColor;
			shot.transform.Translate(0,10,15);

			var shot2 = Instantiate(bullet, transform.position, transform.rotation * Quaternion.Euler(0,90,0));
			shot2.GetComponent<Bullet>().SetParentName(this.name);
			shot2.GetComponent<MeshRenderer>().material.color = bulletColor;
			shot2.transform.Translate(0,10,15);

			var shot3 = Instantiate(bullet, transform.position, transform.rotation * Quaternion.Euler(0,180,0));
			shot3.GetComponent<Bullet>().SetParentName(this.name);
			shot3.GetComponent<MeshRenderer>().material.color = bulletColor;
			shot3.transform.Translate(0,10,15);

			var shot4 = Instantiate(bullet, transform.position, transform.rotation * Quaternion.Euler(0,270,0));
			shot4.GetComponent<Bullet>().SetParentName(this.name);
			shot4.GetComponent<MeshRenderer>().material.color = bulletColor;
			shot4.transform.Translate(0,10,15);
			timeToShoot = shotDelay;
		}
	}
}
