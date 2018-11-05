using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tirinhoDeQuatro : MonoBehaviour {
	
	//private Rigidbody rb;
	private float timeToShoot;
	public float delayEntreCargas = 2f;
	public float shotDelay = 0.2f;
	public GameObject bullet;
	public Color bulletColor;
	public Vector3 offsetBullet = new Vector3(0f, 0f, 1.7f);
	public int[] carga = new int[5];
	private int qualCarga = 0;
	private int quantosTirosFaltam;
	
	// Use this for initialization
	void Start () {
		//rb=gameObject.GetComponent<Rigidbody>();
		qualCarga = 0;
		quantosTirosFaltam = carga[0];
	}
	
	// Update is called once per frame
	void Update () {
		if(timeToShoot > 0)
			timeToShoot -= Time.deltaTime;
		if(timeToShoot <= 0){
			if(quantosTirosFaltam > 1){
				Shoot4Me();
				timeToShoot = shotDelay;
				quantosTirosFaltam--;
			}
			else if (quantosTirosFaltam <= 1){
				Shoot4Me();
				timeToShoot = delayEntreCargas;
				qualCarga++;
				if(qualCarga >= carga.Length)
					qualCarga = 0;
				quantosTirosFaltam = carga[qualCarga];
			}
		}
	}
	
	void Shoot4Me(){
			var shot = Instantiate(bullet, transform.position, transform.rotation);
			shot.transform.Translate(offsetBullet, Space.Self);
			shot.GetComponent<Bullet>().SetParentName(this.name);
			shot.GetComponent<MeshRenderer>().material.color = bulletColor;
			
			var shot2 = Instantiate(bullet, transform.position, transform.rotation);
			shot2.transform.Rotate(90 * Vector3.up, Space.World);
			shot2.transform.Translate(offsetBullet, Space.Self);
			shot2.GetComponent<Bullet>().SetParentName(this.name);
			shot2.GetComponent<MeshRenderer>().material.color = bulletColor;
			
			var shot3 = Instantiate(bullet, transform.position, transform.rotation);
			shot3.transform.Rotate(180 * Vector3.up, Space.World);
			shot3.transform.Translate(offsetBullet, Space.Self);
			shot3.GetComponent<Bullet>().SetParentName(this.name);
			shot3.GetComponent<MeshRenderer>().material.color = bulletColor;
			
			var shot4 = Instantiate(bullet, transform.position, transform.rotation);
			shot4.transform.Rotate(270 * Vector3.up, Space.World);
			shot4.transform.Translate(offsetBullet, Space.Self);
			shot4.GetComponent<Bullet>().SetParentName(this.name);
			shot4.GetComponent<MeshRenderer>().material.color = bulletColor;
	}
}
