using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCountControl : MonoBehaviour {
	public GameObject fail;
	public Iniciar Worked;
	public int minimum;
	public void go(){
		if(PlayerSelection.count >= minimum) Worked.LoadScene(1);
		else fail.SetActive(true);
	}
}
