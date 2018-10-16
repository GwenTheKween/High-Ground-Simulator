using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

    Rigidbody rg;
    public float torque;

	// Use this for initialization
	void Start () {
		rg=gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		rg.AddTorque(transform.up*torque*Random.Range(-1.0f,1.0f));
	}
}
