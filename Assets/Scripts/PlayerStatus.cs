using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour {

	private Rigidbody rb;
	public string name;
	public float protectedY;
	public bool isProtected = false;
	public bool hasProtection = true;
	public int deathPenalty = 5;
	public int killPoints = 100;
    public GameObject Teleport;
	public PlayerHUD ScriptHUD;
	public int PlayerNum;

    private Transform here;
    private AudioSource AS;
    
	void Start(){
		rb = GetComponent<Rigidbody>();
        here = GetComponent<Transform>();
        AS = GetComponent<AudioSource>();
		AS.volume = VolumeScript.sfx;
	}

	public void Death(PlayerStatus stat){
		if(transform.position.y > protectedY && !isProtected)
		{
			if(stat != null) stat.ChangeScore(killPoints);
			Teleporte();
			ChangeScore(-deathPenalty);
			
		}
	}
	
	public void Teleporte(){
		transform.position = new Vector3(765,-13,rb.position.z);
        Instantiate(Teleport, here.position, Quaternion.identity);
		hasProtection = true;
		
		
		
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
		Debug.Log("playerNum = " + n);
        PlayerNum = n;
        name = "P" + (n+1).ToString();
    }

    public void ImTheKing()
    {
        ScriptHUD.IHaveTheHighGround();
    }

    public void NotTheKing()
    {
        ScriptHUD.LostIt();
    }

	public void UpdateColorPercentage(float perc){
		ScriptHUD.UpdateColorPercentage(perc);
	}

	public void ChangeScore(int value = 1){
        PlayerSelection.scores[PlayerNum] += value;
        if(PlayerSelection.scores[PlayerNum] < 0) PlayerSelection.scores[PlayerNum] = 0;

        ScriptHUD.SetPoints(PlayerNum);
    }
}
