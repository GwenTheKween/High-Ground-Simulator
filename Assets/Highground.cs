using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highground : MonoBehaviour {

	private List<PlayerStatus> kings;

	// Use this for initialization
	void Start () {
		kings = new List<PlayerStatus>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Player entrou no Highground
	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Player"){
			kings.Add(other.gameObject.GetComponent<PlayerStatus>());
		}
	}

	void OnTriggerExit(Collider other){
		if(other.gameObject.tag == "Player"){
			
		}
	}
}
