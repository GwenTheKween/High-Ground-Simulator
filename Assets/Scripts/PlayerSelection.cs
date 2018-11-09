using System;
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

	public static int GetMyPosition(int player){
		int[] tmp = (int[]) PlayerSelection.scores.Clone();
		Array.Sort(tmp);

//		Debug.Log("player = " + (player-1));
//		Debug.Log("score = " + scores[player-1]);
//		Debug.Log("score = " + tmp[player-1]);

		for(int i = scores.Length - 1; i >= 0; i--){
			if(scores[player-1] == tmp[i])
				return scores.Length - i;
		}

		return 0;
	}
	
}


