using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class ControleXBox : MonoBehaviour {

	private Rigidbody rb;
	public XboxController controller;
	
	private static bool didQueryNumOfCtrlrs = false;
	
	void Start(){
		
		rb = GetComponent<Rigidbody>();
		
		if(!didQueryNumOfCtrlrs){
			
			didQueryNumOfCtrlrs = true;
			
			int queriedNumberOfCtrlrs = XCI.GetNumPluggedCtrlrs();
			
			if(queriedNumberOfCtrlrs == 1){
				Debug.Log("Só um controle Xbox conectado.");
			}
			else if (queriedNumberOfCtrlrs == 0){
				Debug.Log("Não há controles Xbox conectados");
			}
			else{
				Debug.Log(queriedNumberOfCtrlrs + " controles Xbox conectados.");
			}
			
			XCI.DEBUG_LogControllerNames();

            // This code only works on Windows
            if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor){
                Debug.Log("Apenas em Windows:: Algum controle conectado: " + XCI.IsPluggedIn(XboxController.Any).ToString());

                Debug.Log("Apenas em Windows:: Controle 1 conectado: " + XCI.IsPluggedIn(XboxController.First).ToString());
                Debug.Log("Apenas em Windows:: Controle 2 conectado: " + XCI.IsPluggedIn(XboxController.Second).ToString());
                Debug.Log("Apenas em Windows:: Controle 3 conectado: " + XCI.IsPluggedIn(XboxController.Third).ToString());
                Debug.Log("Apenas em Windows:: Controle 4 conectado: " + XCI.IsPluggedIn(XboxController.Fourth).ToString());
            }
        }
		
	}
	
	// Update is called once per frame
	void Update () {
		
		// Movimento no analógico esquerdo
		var leftX = XCI.GetAxis(XboxAxis.LeftStickX, controller);
        var leftY = XCI.GetAxis(XboxAxis.LeftStickY, controller);
		var movement = new Vector3(-leftY*100f, 0f, leftX*100f);
		transform.Translate(movement*Time.deltaTime, Space.World);
	
		rb.position = new Vector3
		(
			Mathf.Clamp (rb.position.x, 70, 450),
			rb.position.y,
			Mathf.Clamp (rb.position.z, 10, 489)
		);
		
		
		// Mira no analógico direito
		var rightX = XCI.GetAxis(XboxAxis.LeftStickX, controller);
        var rightY = XCI.GetAxis(XboxAxis.LeftStickY, controller);
		
		// Invulnerabilidade
		if(XCI.GetButtonDown(XboxButton.LeftBumper, controller) || XCI.GetButtonDown(XboxButton.RightBumper, controller)){
			
		}
		
		// Tiro Laser 
		// O quanto o trigger direito foi apertado
		// XCI.GetAxis(XboxAxis.RightTrigger, controller) 
		
		// Granada
		// O quanto o trigger esquerdo foi apertado
		// XCI.GetAxis(XboxAxis.LeftTrigger, controller)
		
	}
}
