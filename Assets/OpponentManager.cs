using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentManager : MonoBehaviour
{
	public Action OnNewOpponent;	
	
	
	public Opponent OpponentObject;
	
	/// <summary>
	/// This event exists to let the gamemanager/turn based manager know when an opponent is ready to fight
	/// </summary>
	public static Action OnOpponentReadyForFight;
	
	
	private void Awake() {
		if(OpponentObject == null)
			Debug.LogError("OpponentObject not set!");
	}
	
	
	
	private void Start() {
		TurnBasedManager.Instance.OnTurnStarted += OnNewTurn;
	}

	public void OnNewTurn(Enums.TurnStates state)
	{
		if(state != Enums.TurnStates.OpponentTurn)
			return;			
			
		OpponentObject.Attack();
	}
	
	public void GetNewOpponent(Enums.OpponentDifficulty difficulty, bool boss = false, bool finalboss = false)
	{
		OpponentDataSO newOpponentData = null;
		if(!finalboss)
		 	newOpponentData = GameManager.Instance.OpponentList.GetRandomOpponent(difficulty, boss);
		else
			newOpponentData = GameManager.Instance.OpponentList.GetFinalBoss();
			
		OpponentObject.SpawnNewOpponent(newOpponentData);		
	}
	
	private void OnDestroy() {
		TurnBasedManager.Instance.OnTurnStarted -= OnNewTurn;
	}
	
}
