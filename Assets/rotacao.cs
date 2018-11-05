using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotacao : MonoBehaviour {
	
	private Rigidbody rb;
	public float velocidadeRotacao = 50f;
	
	// Use this for initialization
	void Start () {
		rb=gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		rb.transform.Rotate(velocidadeRotacao * Vector3.up * Time.deltaTime, Space.World);
	}
}
