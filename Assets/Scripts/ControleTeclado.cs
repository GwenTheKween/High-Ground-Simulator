using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleTeclado : MonoBehaviour {

	private Rigidbody rb;
	
	void Start(){
		
		rb = GetComponent<Rigidbody>();
		
	}
	
	// Update is called once per frame
	void Update () {
		var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");
		var movement = new Vector3(-v*100f, 0f, h*100f);
		transform.Translate(movement*Time.deltaTime, Space.World);
	
		rb.position = new Vector3
		(
			Mathf.Clamp (rb.position.x, 70, 450),
			rb.position.y,
			Mathf.Clamp (rb.position.z, 10, 489)
		);
		
		var rZ = Input.GetAxis("Horizontal_2");
        var rX = Input.GetAxis("Vertical_2");
		var direction = new Vector3(-rX, 0, rZ);
		if(direction != Vector3.zero)
			rb.transform.forward = direction;
	
	}
}
