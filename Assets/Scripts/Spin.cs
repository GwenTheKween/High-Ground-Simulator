using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour {

	public float speedX = 100f;
	public float speedY = 100f;
	public float speedZ = 100f;
	
	void Update () {
		transform.Rotate(new Vector3(1f,0f,0f), speedX * Time.deltaTime);
		transform.Rotate(new Vector3(0f,1f,0f), speedY * Time.deltaTime);
		transform.Rotate(new Vector3(0f,0f,1f), speedZ * Time.deltaTime);
	}
}
