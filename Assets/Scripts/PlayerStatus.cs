using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour {

	private Rigidbody rb;
	private int score;
	public string name;
	public float lowGroundZ;
	public float highGroundZ;
	public bool isProtected;
	public int deathPenalty = 10;
    public GameObject Teleport;

    private Transform here;

	void Start(){
		rb = GetComponent<Rigidbody>();
        here = GetComponent<Transform>();
		isProtected = false;
		score = 0;
	}
	
	public void IncreaseScore(int value = 1){
		score += value;
		print(name + ": " + score);
	}

	public int getScore(){
		return score;
	}

	public void Death(){
		if(transform.position.z > lowGroundZ && !isProtected)
		{
			score -= deathPenalty;
			if (score < 0)
				score = 0;
			rb.MovePosition(new Vector3(rb.position.x,rb.position.y,15));
            Instantiate(Teleport, here.position, Quaternion.identity);
		}
	}

	public bool isOnHighGround(){
		if (transform.position.z >= highGroundZ){
			return true;
		}
		return false;
	}
}
