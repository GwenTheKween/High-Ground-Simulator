using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class ControleXBox : MonoBehaviour {

	private Rigidbody rb;
	private float timeToShoot;
	private float timeToNextBullet;
	private int bulletCount;

	private float timeToBomb;
	private float protectionCount;
	private PlayerStatus stat;
	private float sangle;
	private float cangle;
	private Animator anim;

	
	public XboxController controller;
	public float deadzone_leftAnalog = 0.1f;
	public float deadzone_rightAnalog = 0.1f;
	public float deadzone_trigger = 0.1f;
	public float moveSpeed = 100f;
	public GameObject bullet;
	public GameObject bomb;
	public Vector3 bulletOffset;
	public Vector3 grenadeOffset;
	public GameObject protEffect;
	public Color bulletColor;
	public float shotDelay = 1f;
	public int bulletsToShoot = 3;
	public float bulletFrequency = 0.05f;

	public float bombDelay = 2f;
	public float protectionTime = 5f;
    public AudioSource shootSFX;
	public float angle;
	public float velocidadeRotacao = 8f;
	
	private static bool didQueryNumOfCtrlrs = false;
	
	void Start(){
		
		timeToShoot = 0;
		rb = GetComponent<Rigidbody>();

		timeToBomb = 0;
		
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
		sangle = Mathf.Sin(angle*Mathf.PI/180);
		cangle = Mathf.Cos(angle*Mathf.PI/180);
		
		anim = GetComponentInChildren<Animator>();
		stat = GetComponent<PlayerStatus>();
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
		var movement = new Vector3((leftX*cangle-leftY*sangle)*moveSpeed, rb.velocity.y, (leftX*sangle + leftY*cangle)*moveSpeed);
		
		if(movement.magnitude > deadzone_leftAnalog){
			rb.velocity = movement;
			//rb.MovePosition(rb.position + movement*moveSpeed*Time.deltaTime);
		}

		//rb.position = new Vector3(Mathf.Clamp (rb.position.x, 8, 490),
		//								rb.position.y,
		//								Mathf.Clamp (rb.position.z, 8, 489));
		
		anim.SetFloat("Speed", movement.magnitude/moveSpeed);
	}

	// Virar personagem
	void Turn(){
		// Mira no analógico direito
		var rightX = XCI.GetAxis(XboxAxis.RightStickX, controller);
        var rightY = XCI.GetAxis(XboxAxis.RightStickY, controller);
		var direction = new Vector3(-rightX, 0, -rightY);
		if(direction.magnitude > deadzone_rightAnalog){
			//rb.transform.forward = direction;
			
			//Código adaptado de https://forum.unity.com/threads/smooth-look-at.26141/
			var targetRotation = Quaternion.LookRotation(direction);
			// Smoothly rotate towards the target point.
			rb.transform.rotation = Quaternion.Slerp(rb.transform.rotation, targetRotation, velocidadeRotacao * Time.deltaTime);
		}
	}

	// Atirar com a arma
	void Shoot(){

		// Tempo entre tiros
		if(timeToShoot > 0){
			timeToShoot -= Time.deltaTime;
			timeToNextBullet -= Time.deltaTime;
			if(timeToNextBullet < 0 && bulletCount > 0){
				shootSFX.Play();
				var shot = Instantiate(bullet, transform.position, transform.rotation);
				shot.transform.Translate(bulletOffset);
				shot.GetComponent<Bullet>().SetParentName(stat.name);
				shot.GetComponent<MeshRenderer>().material.color = bulletColor;
				shot.GetComponent<Bullet>().stat = stat;
				bulletCount--;
				timeToNextBullet = bulletFrequency;
			}
		}

		// Atirar
		// O quanto o trigger direito foi apertado
		if(XCI.GetAxis(XboxAxis.RightTrigger, controller) > deadzone_trigger && timeToShoot <= 0){
			shootSFX.Play();
			var shot = Instantiate(bullet, transform.position, transform.rotation);
			shot.transform.Translate(bulletOffset);
			shot.GetComponent<Bullet>().SetParentName(stat.name);
			shot.GetComponent<MeshRenderer>().material.color = bulletColor;
			shot.GetComponent<Bullet>().stat = stat;
			timeToShoot = shotDelay;
			timeToNextBullet = bulletFrequency;
			bulletCount = bulletsToShoot-1;
		}
	}

	// Arremessar Granada
	void Grenade(){
		if(timeToBomb > 0){ 
			timeToBomb -= Time.deltaTime;
			stat.UpdateColorPercentage((bombDelay-timeToBomb)/bombDelay);
		}

		// O quanto o trigger esquerdo foi apertado
		if(XCI.GetAxis(XboxAxis.LeftTrigger, controller) > deadzone_trigger && timeToBomb <= 0){
			var shot = Instantiate(bomb, transform.position, transform.rotation);
			shot.transform.Translate(grenadeOffset);
			shot.GetComponent<BulletBomb>().SetParentName(this.gameObject.name);
			timeToBomb = bombDelay;
			stat.UpdateColorPercentage((bombDelay-timeToBomb)/bombDelay);
		}
	}

	// Invulnerabilidade
	void Invulnerable(){
		if (protectionCount > 0){
			protectionCount -= Time.deltaTime;
			if (protectionCount <= 0){
				GetComponent<PlayerStatus>().isProtected = false;
			}
		}
		// Bumpers
		if((XCI.GetButtonDown(XboxButton.LeftBumper, controller) 
			|| XCI.GetButtonDown(XboxButton.RightBumper, controller)) 
			&& GetComponent<PlayerStatus>().useProtection()){
			protectionCount = protectionTime;
			var effect = Instantiate(protEffect,transform.position,transform.rotation);
			effect.transform.SetParent(this.transform);
		}
	}

    public void setController(XboxController cont)
    {
        controller = cont;
    }
}
