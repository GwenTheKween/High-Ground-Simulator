using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletExplosion : MonoBehaviour {

	public float size = 10f;

    private AudioSource AS;

	void Start(){
		transform.localScale = new Vector3(size,size,size);
        AS = GetComponent<AudioSource>();
	}

	// Colisão
	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Player"){
			other.gameObject.GetComponent<PlayerStatus>().Death(null);
		}
	}

    void play()
    {
        AS.Play();
    }

	void KillSelf(){
		Destroy(this.gameObject);
	}
}
