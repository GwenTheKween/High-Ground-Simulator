using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour {


	public string name;
	public float lowGroundZ;
	public float highGroundZ;
	public bool isProtected;
	public int deathPenalty = 10;
    public GameObject Teleport;

    private Rigidbody rb;
    private Transform here;
    private PlayerHUD ScriptHUD;
    private AudioSource AS;
    private int PlayerNum;

	void Start(){
		rb = GetComponent<Rigidbody>();
        here = GetComponent<Transform>();
        AS = GetComponent<AudioSource>();
		isProtected = false;
        AS.volume = VolumeScript.sfx;
	}
	
	public void IncreaseScore(int value = 1){
		PlayerSelection.scores[PlayerNum] += value;
        ScriptHUD.SetPoints(PlayerNum);
	}

	public void Death(){
		if(transform.position.z > lowGroundZ && !isProtected)
		{
			PlayerSelection.scores[PlayerNum] -= deathPenalty;
			if (PlayerSelection.scores[PlayerNum] < 0)
				PlayerSelection.scores[PlayerNum] = 0;
            ScriptHUD.SetPoints(PlayerNum);
            rb.MovePosition(new Vector3(rb.position.x,rb.position.y,15));
            Instantiate(Teleport, here.position, Quaternion.identity);
		}
	}

	public bool isOnHighGround(){
		if (transform.position.z >= highGroundZ){
			return true;
		}
		return false;
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
