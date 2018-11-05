using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombardeiaGalera : MonoBehaviour {
	
	public GameObject bomb;
	private float timeToBomb;
	public float bombDelay;
	public Color bombColor;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(timeToBomb > 0) 
			timeToBomb -= Time.deltaTime;

		if(timeToBomb <= 0){
			var shot = Instantiate(bomb, transform.position, transform.rotation);
			shot.GetComponent<BulletBomb>().SetParentName(this.gameObject.name);
			shot.GetComponent<MeshRenderer>().material.color = bombColor;
			shot.GetComponent<BulletBomb>().parentColor = bombColor;
			timeToBomb = bombDelay;
		}	
	}
}
