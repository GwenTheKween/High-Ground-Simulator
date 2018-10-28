using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highground : MonoBehaviour {

	public short[] players;
	private PlayerStatus[] status;
	private short playerCount = 0;
	private float timeToPoint;
	public int pointStep = 1;
	public float delayPoint = 1;

	// Use this for initialization
	void Start () {
		timeToPoint = delayPoint;
		players = new short[4];
		status = new PlayerStatus[4];

		for(int i = 0; i < 4; i++)
			players[i] = -1;
	}
	
	// Update is called once per frame
	void Update () {
		timeToPoint -= Time.deltaTime;
		if(timeToPoint <= 0){
			for(int i = 0; i < 4; i++){
				if(players[i] == 0)
					status[i].IncreaseScore(pointStep);
			}
			timeToPoint = delayPoint;
		}
	}

	// Player entrou no Highground
	void OnTriggerEnter(Collider other){
        Debug.Log("entrou");
		if(other.gameObject.tag == "Player"){
			var tmp = other.gameObject.GetComponent<PlayerStatus>();
            if (playerCount == 0) tmp.ImTheKing();
			playerCount++;
			
			for(int i = 1; i <= 4; i++){
				if(tmp.name == "P"+i.ToString()){
					players[i-1] += playerCount;
					status[i-1] = tmp;
					return;
				}
			}
		}
	}

	void OnTriggerExit(Collider other){
		if(other.gameObject.tag == "Player"){
			var tmp = other.gameObject.GetComponent<PlayerStatus>();
			playerCount--;
			
			for(int i = 1; i <= 4; i++){
				if(tmp.name == "P"+i.ToString()){
					for(int j = 1; j <= 4; j++){
						if(players[j-1] > players[i-1])
							players[j-1]--;
					}
                    if (players[i - 1] == 0) tmp.NotTheKing();
					players[i-1] = -1;
					return;
				}
			}
			
		}
	}
}
