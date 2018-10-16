using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1_Move : MonoBehaviour {

	public Rigidbody rb;
	
	void Start(){
		
		rb = GetComponent<Rigidbody>();
		
	}
	
	// Update is called once per frame
	void Update () {
		var h = Input.GetAxis("Horizontal_P1");
        var v = Input.GetAxis("Vertical_P1");
		var movement = new Vector3(-v*100f, 0f, h*100f);
		transform.Translate(movement*Time.deltaTime, Space.World);
	
		rb.position = new Vector3
		(
			Mathf.Clamp (rb.position.x, 70, 450),
			rb.position.y,
			Mathf.Clamp (rb.position.z, 10, 489)
		);
	
	}
}
