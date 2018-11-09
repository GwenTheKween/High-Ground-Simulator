using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XboxCtrlrInput;

public class CharSelectScript : MonoBehaviour {

    public XboxController controller;
    public RenderTexture[] texs;
    public string[] names;
    public int playerNum;
    public GameObject Panel;
    public Text nameText;

    private static bool didQueryNumOfCtrlrs = false;
    private bool pressed;
    private bool chosen;
    private int selected;
    private RawImage me;

    void Start()
    {
        pressed = false;
        selected = 0;
        me = GetComponent<RawImage>();
        me.texture = texs[0];
        nameText.text = names[0];
        chosen = false;

        if (PlayerSelection.chars == null){
			PlayerSelection.chars = new int[4];
			PlayerSelection.count = 0;
		}
        if (PlayerSelection.scores == null) PlayerSelection.scores = new int[4];
        PlayerSelection.chars[playerNum] = -1;
        PlayerSelection.scores[playerNum] = 0;
    }

    // Update is called once per frame
    void Update()
    {

        // Movimento no analógico esquerdo
        var leftX = XCI.GetAxis(XboxAxis.LeftStickX, controller);

        if (!pressed && (leftX != 0) && !chosen) {
            pressed = true;
            if (leftX > 0) selected = (selected + 1) % texs.Length;
            else selected = (selected + texs.Length - 1) % texs.Length;
            me.texture = texs[selected];
            nameText.text = names[selected];
        }
        else if (pressed && leftX == 0 && !chosen) { 
            pressed = false;
        }else if (!chosen && XCI.GetButtonDown(XboxButton.X,controller)) {
            PlayerSelection.chars[playerNum] = selected;
			PlayerSelection.count++;
            chosen = true;
            Panel.SetActive(true);
        }else if(chosen && XCI.GetButtonDown(XboxButton.X, controller)) {
            PlayerSelection.chars[playerNum] = -1;
			PlayerSelection.count--;
            chosen = false;
            Panel.SetActive(false);
        }
    }
}
