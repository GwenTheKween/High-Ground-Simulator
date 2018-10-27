using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

    public GameObject final_game_panel;
    public Text final_game_score;
    public Text final_game_name;
    public Text final_game_player;
    public GameObject final_back_button;
    public Text Timer;

    private AudioSource AS;
    private float seconds_left;
    private int stage;
    private int mx_score;
    private string players;
    private string chars;

	// Use this for initialization
	void Start () {
        AS = GetComponent<AudioSource>();
        AS.volume = VolumeScript.bgm;
        seconds_left = 30;
        stage = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if(stage<5) seconds_left -= Time.deltaTime;
        if (stage == 0)
        {
            Timer.text = ((int)seconds_left / 60).ToString() + ":" + (((int)seconds_left) % 60).ToString("D2");
        }
        Debug.Log(stage);
        if(seconds_left <= 0)
        {
            if(stage == 0)
            {
                //activate end game panel
                final_game_panel.SetActive(true);
                stage = 1;
                seconds_left = 1f;
                mx_score = PlayerSelection.scores[0];
                players = "";
                for (int i = 1; i < 4; i++) if (PlayerSelection.scores[i] > mx_score) mx_score = PlayerSelection.scores[i];
                for (int i = 0; i < 4; i++)
                {
                    if (PlayerSelection.scores[i] == mx_score)
                    {
                        players += (i + 1).ToString() + " ";
                    }
                }
                if (players.Length > 2)
                {
                    chars = "Empate";
                    players = "Jogadores: " + players;
                }
                else
                {
                    int p = (int)players[0] - 48;
                    if (PlayerSelection.chars[p] == 0) chars = "Dort";
                    else if (PlayerSelection.chars[p] == 1) chars = "Ikis";
                    else if (PlayerSelection.chars[p] == 2) chars = "Ucan";
                    else chars = "Ibir";
                    players = "Jogador: " + players;
                }
            }
            else if(stage == 1)
            {
                //shows score
                final_game_score.gameObject.SetActive(true);
                final_game_score.text = "Pontuacao: "+mx_score.ToString();
                stage = 2;
                seconds_left = 1f;
            }
            else if(stage == 2)
            {
                //shows character name
                final_game_name.gameObject.SetActive(true);
                final_game_name.text = chars;
                stage = 3;
                seconds_left = 1f;
            }
            else if (stage == 3)
            {
                //shows which player won.
                final_game_player.gameObject.SetActive(true);
                final_game_player.text = players;
                stage = 4;
                seconds_left = 1f;
            }
            else
            {
                final_back_button.SetActive(true);
                stage = 5;
            }
        }
	}
}
