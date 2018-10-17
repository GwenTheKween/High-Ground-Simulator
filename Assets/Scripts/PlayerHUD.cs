using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour {

	public int player_number;
	public int points;
	public Color color;
	public Image image_back_border;
	public Image image_king_border;
	public Text text_points;
	public Text text_player_name;
	public GameObject object_king;

	// Use this for initialization
	void Start () {
		text_player_name.text = "P" + player_number.ToString();
		text_points.text = points.ToString("D7");
		image_back_border.color = color;
		image_king_border.color = color;
		LostIt();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Enable the king icon
	void IHaveTheHighGround(){
		object_king.SetActive(true);
	}

	// Disable the king icon
	void LostIt(){
		object_king.SetActive(false);
	}

	void AddPoints(int pnts){
		points += pnts;
	}
}
