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
    public float gameTime = 300f;
    public float seconds_left;
    private AudioSource AS;
    private int stage;
    private int mx_score;
    private string players;
    private string chars;

	// Use this for initialization
	void Start () {
        AS = GetComponent<AudioSource>();
        AS.volume = VolumeScript.bgm;
        seconds_left = gameTime;
        stage = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if(stage<5) seconds_left -= Time.deltaTime;
        if (stage == 0)
        {
            Timer.text = ((int)seconds_left / 60).ToString() + ":" + (((int)seconds_left) % 60).ToString("D2");
        }
        if(seconds_left <= 0 || stage == 5)
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
                    int p = (int)players[0] - 49;
                    if (PlayerSelection.chars[p] == 0) chars = "Dort";
                    else if (PlayerSelection.chars[p] == 1) chars = "Ikis";
                    else if (PlayerSelection.chars[p] == 2) chars = "Ucan";
                    else chars = "Ibir";
                    Debug.Log(p);
                    Debug.Log(PlayerSelection.chars[p]);
                    players = "Jogador: " + players;
                }
            }
            else if(stage == 1)
            {
				Debug.Log(mx_score);
                //shows score
                final_game_score.gameObject.SetActive(true);
                final_game_score.text = "Pontuacao: "+mx_score.ToString();
                stage = 2;
                seconds_left = 1f;
            }
            else if(stage == 2)
            {
				Debug.Log(chars);
                //shows character name
                final_game_name.gameObject.SetActive(true);
                final_game_name.text = chars;
                stage = 3;
                seconds_left = 1f;
            }
            else if (stage == 3)
            {
				Debug.Log(players);
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
                PlayerSelection.count = 0;
                seconds_left = gameTime;
            }
        }
	}
}
