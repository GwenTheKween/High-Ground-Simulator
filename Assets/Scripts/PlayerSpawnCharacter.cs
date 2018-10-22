using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class PlayerSpawnCharacter : MonoBehaviour{

    public XboxController controller;
    public int playerNum;
    public GameObject[] prefabs;
    // Use this for initialization
    void Start () {
        GameObject pref;
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
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
