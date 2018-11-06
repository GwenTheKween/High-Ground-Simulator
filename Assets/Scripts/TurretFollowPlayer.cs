using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretFollowPlayer : MonoBehaviour {
	
	private GameObject[] players;
	private Transform target;
	private Rigidbody rb;
	public float velocidadeRotacao = 5f;
	
	
	
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		players = GameObject.FindGameObjectsWithTag("Player");
		
		Transform[] alvos = new Transform[players.Length];
		int i;
		for(i = 0; i < players.Length; i++)
			alvos[i] = players[i].transform;
		target = GetClosestEnemy(alvos);
		
		
		//Código adaptado de https://forum.unity.com/threads/smooth-look-at.26141/
		var targetRotation = Quaternion.LookRotation(target.position - rb.transform.position);
		// Smoothly rotate towards the target point.
		transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, velocidadeRotacao * Time.deltaTime);
		
	}
	
	// Código tirado de https://forum.unity.com/threads/clean-est-way-to-find-nearest-object-of-many-c.44315/
	Transform GetClosestEnemy (Transform[] enemies)
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach(Transform potentialTarget in enemies)
        {
            Vector3 directionToTarget = potentialTarget.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if(dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
        }
     
        return bestTarget;
    }
}
