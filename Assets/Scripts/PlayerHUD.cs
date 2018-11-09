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
	public Text text_player_position;
	public GameObject object_king;
	public GameObject object_first;

	// Use this for initialization
	void Start () {
		text_points.text = points.ToString("D7");
		image_back_border.color = color;
		image_king_border.color = color;
		LostIt();
	}
	
	// Update is called once per frame
	void Update () {
		int position = PlayerSelection.GetMyPosition(player_number);

		if(position == 1){
			object_first.SetActive(true);
		}else{
			object_first.SetActive(false);
		}

		Debug.Log(position);

		text_player_position.text = (position).ToString() + "º";
	}

	// Enable the king icon
	public void IHaveTheHighGround(){
		object_king.SetActive(true);
	}

	// Disable the king icon
	public void LostIt(){
		object_king.SetActive(false);
	}

	public void SetPoints(int player){
		text_points.text = PlayerSelection.scores[player].ToString("D7");
	}

	public void SetColor(Color cor){
		this.color = cor;
		image_back_border.color = color;
		image_king_border.color = color;
	}

	public void UpdateColorPercentage(float perc){
		var tmp = color*perc + Color.red*(1-perc);
		tmp.a = 1f;
		image_back_border.color = tmp;
		image_king_border.color = tmp;
	}
}
