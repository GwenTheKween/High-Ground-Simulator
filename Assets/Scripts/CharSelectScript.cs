﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XboxCtrlrInput;

public class CharSelectScript : MonoBehaviour {

    
    public XboxController controller;
    public RenderTexture[] texs;
    public int playerNum;

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
        chosen = false;

        if (PlayerSelection.chars == null) PlayerSelection.chars = new int[4];
        PlayerSelection.chars[playerNum] = -1;

        if (!didQueryNumOfCtrlrs)
        {

            didQueryNumOfCtrlrs = true;

            int queriedNumberOfCtrlrs = XCI.GetNumPluggedCtrlrs();

            if (queriedNumberOfCtrlrs == 1)
            {
                Debug.Log("Só um controle Xbox conectado.");
            }
            else if (queriedNumberOfCtrlrs == 0)
            {
                Debug.Log("Não há controles Xbox conectados");
            }
            else
            {
                Debug.Log(queriedNumberOfCtrlrs + " controles Xbox conectados.");
            }

            XCI.DEBUG_LogControllerNames();

            // This code only works on Windows
            if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
            {
                Debug.Log("Apenas em Windows:: Algum controle conectado: " + XCI.IsPluggedIn(XboxController.Any).ToString());

                Debug.Log("Apenas em Windows:: Controle 1 conectado: " + XCI.IsPluggedIn(XboxController.First).ToString());
                Debug.Log("Apenas em Windows:: Controle 2 conectado: " + XCI.IsPluggedIn(XboxController.Second).ToString());
                Debug.Log("Apenas em Windows:: Controle 3 conectado: " + XCI.IsPluggedIn(XboxController.Third).ToString());
                Debug.Log("Apenas em Windows:: Controle 4 conectado: " + XCI.IsPluggedIn(XboxController.Fourth).ToString());
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

        // Movimento no analógico esquerdo
        var rightX = XCI.GetAxis(XboxAxis.RightStickX, controller);

        Debug.Log(PlayerSelection.chars[playerNum]);

        if (!pressed && (rightX != 0) && !chosen)
        {
            pressed = true;
            if (rightX > 0) selected = (selected + 1) % texs.Length;
            else selected = (selected + texs.Length - 1) % texs.Length;
            me.texture = texs[selected];

        }
        else if (pressed && rightX == 0 && !chosen) { 
            pressed = false;
        }else if (!chosen && XCI.GetButton(XboxButton.Start))
        {
            PlayerSelection.chars[playerNum] = selected;
            chosen = true;
            Debug.Log(selected);
        }

    }
}
