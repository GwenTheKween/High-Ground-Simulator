using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSnipeIt : MonoBehaviour {

	public GameObject bullet;
	private float timeToShot;
	private float timeToAct;
	
	private TurretFollowFirst followScript;
	public ParticleSystem smokePrefab;
	private ParticleSystem smoke;
	
	
	public float shotDelay;
	public float actDelay;
	public Color bulletColor;
	public Vector3 offsetBullet = new Vector3(0f, 0f, 1.7f);
	public Vector3 offsetSmoke = new Vector3(0f, 1f, -2f);
	private Rigidbody rb;
	public float velocidadeRotacao = 5f;
	
	public GameObject laser;
	
	
	private bool descanso;
	
	
	// Use this for initialization
	void Start () {
		followScript = GetComponent<TurretFollowFirst>();
		rb = GetComponent<Rigidbody>();
		descanso = false;
		timeToShot = shotDelay;
		timeToAct = -1;
		
		smoke = Instantiate(smokePrefab,transform.position,transform.rotation);
		smoke.transform.Translate(offsetSmoke);
		smoke.Pause();
		
		laser.SetActive(false);
		
	}
	
	// Update is called once per frame
	void Update () {
		if(followScript.isShooting()){
			if(timeToAct > 0)
				timeToAct -= Time.deltaTime;
			if(timeToAct < 0.2*actDelay)
				smoke.Stop();
			
			if(timeToAct <= 0){
				
				laser.SetActive(true);
				
				descanso = false;
				followScript.enabled = true;
				
				if(smoke!=null)
					smoke.Stop();
				
				if(timeToShot > 0) 
					timeToShot -= Time.deltaTime;

				if(timeToShot <= 0){
					var shot = Instantiate(bullet, transform.position, transform.rotation);
					shot.transform.Translate(offsetBullet, Space.Self);
					shot.GetComponent<Bullet>().SetParentName(this.gameObject.name);
					shot.GetComponentInChildren<MeshRenderer>().material.color = bulletColor;
					timeToShot = shotDelay;
					timeToAct = actDelay;
					followScript.enabled = false;
					descanso = true;
					
					laser.SetActive(false);
					smoke.Play();
					
					
				}	
			}
		} else{
			descanso = true;
			timeToShot = shotDelay;
			timeToAct = -1;
			if(smoke!=null)
					smoke.Stop();
		}
		if(descanso){
				var target = new Vector3(260,20,100);
				//Código adaptado de https://forum.unity.com/threads/smooth-look-at.26141/
				var targetRotation = Quaternion.LookRotation(target- rb.transform.position);
				// Smoothly rotate towards the target point.
				rb.transform.rotation = Quaternion.Slerp(rb.transform.rotation, targetRotation, velocidadeRotacao * Time.deltaTime);
				laser.SetActive(false);
		}
	}
	
}


