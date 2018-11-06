using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour {

	private Rigidbody rb;
	public string name;
	public float protectedY;
	public bool isProtected = false;
	public bool hasProtection = true;
	public int deathPenalty = 10;
    public GameObject Teleport;

    private Transform here;
    private PlayerHUD ScriptHUD;
    private AudioSource AS;
    private int PlayerNum;

	void Start(){
		rb = GetComponent<Rigidbody>();
        here = GetComponent<Transform>();
        AS = GetComponent<AudioSource>();
		AS.volume = VolumeScript.sfx;
	}
	
	public void IncreaseScore(int value = 1){
		PlayerSelection.scores[PlayerNum] += value;
		ScriptHUD.SetPoints(PlayerNum);
	}

	public void Death(){
		if(transform.position.y > protectedY && !isProtected)
		{
			transform.position = new Vector3(765,-13,rb.position.z);
            Instantiate(Teleport, here.position, Quaternion.identity);
			PlayerSelection.scores[PlayerNum] -= deathPenalty;
			if(PlayerSelection.scores[PlayerNum] < 0)
				PlayerSelection.scores[PlayerNum] = 0;
			ScriptHUD.SetPoints(PlayerNum);
			
		}
	}

	public bool useProtection(){
		isProtected = hasProtection;
		hasProtection = false;
		return isProtected;
	}

    public void SetHUD(PlayerHUD hud)
    {
        ScriptHUD = hud;
    }

    public void SetName(int n)
    {
        PlayerNum = n;
        name = "P"+(n+1).ToString();
    }

    public void ImTheKing()
    {
        ScriptHUD.IHaveTheHighGround();
    }

    public void NotTheKing()
    {
        ScriptHUD.LostIt();
    }
}
