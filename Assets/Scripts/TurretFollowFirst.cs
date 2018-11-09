using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretFollowFirst : MonoBehaviour {
	
	private GameObject[] players;
	private Transform target;
	private Rigidbody rb;
	private int numFirst;
	public float velocidadeRotacao = 5f;
	public int pontuacaoLimitante = 500;
	
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		players = GameObject.FindGameObjectsWithTag("Player");
		
		numFirst = PlayerSelection.GetFirst();
		//numFirst--;

		Debug.Log("Tamanho de scores:" + PlayerSelection.scores.Length + "   NumFirst: " + numFirst);
		
		if(PlayerSelection.scores.Length > 0){
			if(PlayerSelection.scores[numFirst] > pontuacaoLimitante){
				//target = players[numFirst].transform;
				for (int i=0; i < players.Length; i++){
					//Debug.Log("player atual " + players[i].GetComponent<PlayerStatus>().name);
					if(players[i].GetComponent<PlayerStatus>().name == "P" + (numFirst+1).ToString()){
						target = players[i].transform;
						Debug.Log("first encontrado " + players[i].GetComponent<PlayerStatus>().name);
					}
				}
				//Código adaptado de https://forum.unity.com/threads/smooth-look-at.26141/
				var targetRotation = Quaternion.LookRotation(target.position - rb.transform.position);
				// Smoothly rotate towards the target point.
				transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, velocidadeRotacao * Time.deltaTime);
			}
		}
		
		
	}
	
	public bool isShooting(){
		if(PlayerSelection.scores[numFirst] > pontuacaoLimitante)
			return true;
		return false;
	}
	
}
