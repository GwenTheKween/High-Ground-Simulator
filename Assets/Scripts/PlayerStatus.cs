using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour {

	private Rigidbody rb;
	public int score;
	public float lowGroundZ;

	void Start(){
		rb = GetComponent<Rigidbody>();
	}
	
	public void Death(){
		if(transform.position.z > lowGroundZ)
		{
			score -= 1;
			if (score < 0)
				score = 0;
			rb.MovePosition(new Vector3(rb.position.x,rb.position.y,15));
		}
	}
}
