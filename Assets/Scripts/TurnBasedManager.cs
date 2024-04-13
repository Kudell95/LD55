using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnBasedManager : MonoBehaviour
{
	public static TurnBasedManager Instance { get; private set; }
	
	
	private void Awake() {
		if (Instance == null) {
			Instance = this;
		} else {
			Destroy(this);
		}
	}
	
	public Action<Enums.TurnStates> OnTurnEnded;
	public Action<Enums.TurnStates> OnTurnStarted;
	
	
	
	public Enums.TurnStates CurrentTurnState { get; private set; } = Enums.TurnStates.InitialTurn;
	
	public void StartTurn(Enums.TurnStates turnState)
	{		
		//if we try and start
		if(CurrentTurnState != turnState && CurrentTurnState != Enums.TurnStates.InitialTurn)
			EndTurn();
			
		CurrentTurnState = turnState;
		OnTurnStarted?.Invoke(turnState);
	}
	
	public void EndTurn()
	{
		CurrentTurnState = Enums.TurnStates.PlayerTurn;
		OnTurnEnded?.Invoke(CurrentTurnState);
	}
	
}
