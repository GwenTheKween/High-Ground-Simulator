using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class ControleXBox : MonoBehaviour {

	private Rigidbody rb;
	public XboxController controller;
	public float deadzone_leftAnalog = 0.1f;
	public float deadzone_rightAnalog = 0.1f;
	public float deadzone_trigger = 0.1f;
	private float timeToShoot;
	public float moveSpeed = 100f;
	public GameObject bullet;
	public Color bulletColor;
	public float shotDelay = 1f;
	
	private static bool didQueryNumOfCtrlrs = false;
	
	void Start(){
		
		timeToShoot = 0;
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

		// Mover personagem
		Move();
		
		// Virar personagem
		Turn();

		// Atirar
		Shoot();
		
		// Granada
		Grenade();

		// Invulnerabilidade
		Invulnerable();
		
	}

	// Mover personagem
	void Move(){
		// Movimento no analógico esquerdo
		var leftX = XCI.GetAxis(XboxAxis.LeftStickX, controller);
        var leftY = XCI.GetAxis(XboxAxis.LeftStickY, controller);
		var movement = new Vector3(-leftY, 0f, leftX);

		if(movement.magnitude > deadzone_leftAnalog){
			rb.MovePosition(rb.position + movement*moveSpeed*Time.deltaTime);
		}

		rb.position = new Vector3(Mathf.Clamp (rb.position.x, 70, 450),
										rb.position.y,
										Mathf.Clamp (rb.position.z, 10, 489));
	}

	// Virar personagem
	void Turn(){
		// Mira no analógico direito
		var rightX = XCI.GetAxis(XboxAxis.RightStickX, controller);
        var rightY = XCI.GetAxis(XboxAxis.RightStickY, controller);
		var direction = new Vector3(-rightY, 0, rightX);
		if(direction.magnitude > deadzone_rightAnalog)
			rb.transform.forward = direction;
	}

	// Atirar com a arma
	void Shoot(){
		// Tempo entre tiros
		if(timeToShoot > 0) 
			timeToShoot -= Time.deltaTime;

		// Atirar
		// O quanto o trigger direito foi apertado
		if(XCI.GetAxis(XboxAxis.RightTrigger, controller) > deadzone_trigger && timeToShoot <= 0){
			var shot = Instantiate(bullet, transform.position, transform.rotation);
			shot.GetComponent<Bullet>().SetParentName(this.name);
			shot.GetComponent<MeshRenderer>().material.color = bulletColor;
			timeToShoot = shotDelay;
		}
	}

	// Arremessar Granada
	void Grenade(){
		// O quanto o trigger esquerdo foi apertado
		if(XCI.GetAxis(XboxAxis.LeftTrigger, controller) > deadzone_trigger && timeToShoot <= 0){

		}
	}

	// Invulnerabilidade
	void Invulnerable(){
		// Bumpers
		if(XCI.GetButtonDown(XboxButton.LeftBumper, controller) || XCI.GetButtonDown(XboxButton.RightBumper, controller)){
			
		}
	}
}
