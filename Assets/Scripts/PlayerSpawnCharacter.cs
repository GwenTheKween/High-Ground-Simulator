using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XboxCtrlrInput;

public class PlayerSpawnCharacter : MonoBehaviour{

    public XboxController controller;
    public int playerNum;
    public GameObject[] prefabs;
    public GameObject HUD;
    // Use this for initialization
    void Start () {
        GameObject pref;
        if (PlayerSelection.chars[playerNum] >= 0)
        {
            //se foi escolhido algum personagem, esse jogador vai estar jogando
            pref = Instantiate(
                prefabs[PlayerSelection.chars[playerNum]],
                new Vector3( 470f, 17f, (playerNum + 1) * 100f),
                Quaternion.identity
                );
            pref.GetComponent<ControleXBox>().setController(controller);
            HUD.GetComponent<PlayerHUD>().SetName((playerNum+1).ToString());
            pref.GetComponent<PlayerStatus>().SetHUD(HUD.GetComponent<PlayerHUD>());
            pref.GetComponent<PlayerStatus>().SetName(playerNum);
        }
        else
        {// desativa o  score do jogador
            HUD.SetActive(false);

        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
