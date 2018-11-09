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
                new Vector3( 765f, -13f, 50 +  (playerNum) * 100f),
                Quaternion.identity
                );
            pref.GetComponent<ControleXBox>().setController(controller);
            var tmpHUD = HUD.GetComponent<PlayerHUD>();
            tmpHUD.SetColor(prefabs[PlayerSelection.chars[playerNum]].GetComponent<ControleXBox>().bulletColor);
            pref.GetComponent<PlayerStatus>().SetHUD(HUD.GetComponent<PlayerHUD>());
            pref.GetComponent<PlayerStatus>().SetName(playerNum);
            Debug.Log(playerNum);
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
