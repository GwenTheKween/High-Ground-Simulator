using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using XboxCtrlrInput;

public class MenuCommands : MonoBehaviour {

	public GameObject pausePanel;
	public GameObject endPanel;
	public GameObject input;
	public XboxController controller;
	private GameControl gameControl;
	private AudioSource AS;

	// Use this for initialization
	void Start () {
		gameControl = input.GetComponent<GameControl>();
		AS = input.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if(XCI.GetButtonDown(XboxButton.Start, controller)){
			if(!pausePanel.activeSelf){
				pausePanel.SetActive(true);
				Pause();
				AS.Pause();
			}
			else {
				AS.UnPause();
				Hide();
			}
		}
		if (endPanel.activeSelf){
			AS.Stop();
			Pause();
		}
	}

	public void Pause () {
		Time.timeScale = 0;
	}

	public void UnPause() {
		AS.UnPause();
		Hide();
	}
	
	public void Hide(){
		Time.timeScale = 1;
		pausePanel.SetActive(false);
	}
	public void Return(){
		Time.timeScale = 1;
	}

	public void ReturnMenu(){
		Time.timeScale = 1;
		gameControl.seconds_left = gameControl.gameTime;
		PlayerSelection.count = 0;
		SceneManager.LoadScene(0);
	}
}
