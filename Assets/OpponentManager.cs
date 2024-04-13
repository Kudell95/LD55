using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentManager : MonoBehaviour
{
	public Action OnNewOpponent;	
	
	public Action OnOpponentDeath;
	
	public Opponent OpponentObject;
	
	/// <summary>
	/// This event exists to let the gamemanager/turn based manager know when an opponent is ready to fight
	/// </summary>
	public static Action OnOpponentReadyForFight;
	
	
	private void Awake() {
		if(OpponentObject == null)
			Debug.LogError("OpponentObject not set!");
	}
	
	
	public void GetNewOpponent(Enums.OpponentDifficulty difficulty, bool boss = false)
	{
		var newOpponentData = GameManager.Instance.OpponentList.GetRandomOpponent(difficulty, boss);
		
		
		
	}
	
}
