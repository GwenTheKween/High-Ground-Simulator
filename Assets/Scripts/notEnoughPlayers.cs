using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notEnoughPlayers : MonoBehaviour {
	public float duration;
	
	private float time_left;
	// Use this for initialization
	void Start () {
		time_left = duration;
	}
	
	void OnEnable(){
		time_left = duration;
	}
	
	// Update is called once per frame
	void Update () {
		time_left -= Time.deltaTime;
		if(time_left <= 0) this.gameObject.SetActive(false);
	}
}
