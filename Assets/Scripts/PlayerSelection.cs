using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerSelection {
    public static int[] chars;
    public static int[] scores;
	public static int count;
	
	public static int GetFirst(){
		int first = 0;
		
		for(int i = 1; i < PlayerSelection.scores.Length; i++)
			if(PlayerSelection.scores[i] > PlayerSelection.scores[first])
				first = i;
			
		return first;
	}
	
}


