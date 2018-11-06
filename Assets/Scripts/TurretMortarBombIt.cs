using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretMortarBombIt : MonoBehaviour {
	
	public GameObject bomb;
	private float timeToBomb;
	public float bombDelay;
	public Color bombColor;
	public Vector3 offsetBullet = new Vector3(0f, 0f, 1.7f);
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(timeToBomb > 0) 
			timeToBomb -= Time.deltaTime;

		if(timeToBomb <= 0){
			var shot = Instantiate(bomb, transform.position, transform.rotation);
			shot.transform.Translate(offsetBullet, Space.Self);
			shot.GetComponent<BulletBomb>().SetParentName(this.gameObject.name);
			shot.GetComponent<MeshRenderer>().material.color = bombColor;
			timeToBomb = bombDelay;
		}	
	}
}
