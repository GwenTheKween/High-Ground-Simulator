using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour {

    private AudioSource AS;

	// Use this for initialization
	void Start () {
        AS = GetComponent<AudioSource>();
        AS.volume = VolumeScript.bgm;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
