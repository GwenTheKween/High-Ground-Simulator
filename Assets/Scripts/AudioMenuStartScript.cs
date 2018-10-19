using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMenuStartScript : MonoBehaviour {
    private AudioSource AS;
	// Use this for initialization
	void Start () {
        AS = GetComponent<AudioSource>();
        AS.volume = 0.1f;
        VolumeScript.bgm = 0.1f;
        VolumeScript.sfx = 1f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
