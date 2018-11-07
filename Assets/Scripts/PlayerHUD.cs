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
	public GameObject object_first;

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
		int max = 0;

        for(int i = 0; i < 4; i++){
            if(PlayerSelection.scores[i] > max) 
				max = PlayerSelection.scores[i];
        }

		if(PlayerSelection.scores[player_number-1] == max){
			SetFirst(true);
		}else{
			SetFirst(false);
		}
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

    public void SetName(string name)
    {
        text_player_name.text = name;
    }
	
	public void SetFirst(bool first){
		object_first.SetActive(first);
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
