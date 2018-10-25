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
        int i;
        float x_pos;
        if (PlayerSelection.chars[playerNum] > 0)
        {
            //se foi escolhido algum personagem, esse jogador vai estar jogando
            pref = Instantiate(
                prefabs[PlayerSelection.chars[playerNum]],
                new Vector3((playerNum + 1) * 100f, 17f, 20f),
                Quaternion.identity
                );
            pref.GetComponent<ControleXBox>().setController(controller);
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
