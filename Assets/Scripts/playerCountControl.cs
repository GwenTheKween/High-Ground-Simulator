using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class playerCountControl : MonoBehaviour {
	
	private Iniciar worked;
	private ButtonSound bs;

	public GameObject mainMenu;

	public XboxController controller;
	public GameObject fail;
	public int minimum;

	void Start(){
		worked = GetComponent<Iniciar>();
		bs = GetComponent<ButtonSound>();
	}

	void Update(){
		if(XCI.GetButtonDown(XboxButton.Start, controller)){
			if(PlayerSelection.count >= minimum) worked.LoadScene(1);
			else fail.SetActive(true);
        }else if(XCI.GetButtonDown(XboxButton.B, controller)){
			mainMenu.SetActive(true);
			this.gameObject.SetActive(false);
        }
	}
}
