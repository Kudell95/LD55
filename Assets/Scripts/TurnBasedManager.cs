using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnBasedManager : MonoBehaviour
{
	public Action<Enums.TurnStates> OnTurnEnded;
	public Action<Enums.TurnStates> OnTurnStarted;
	
	public Enums.TurnStates CurrentTurnState { get; private set; }
	
	public void StartTurn(Enums.TurnStates turnState)
	{
		CurrentTurnState = turnState;
		OnTurnStarted?.Invoke(turnState);
	}
	
	public void EndTurn()
	{
		CurrentTurnState = Enums.TurnStates.PlayerTurn;
		OnTurnEnded?.Invoke(CurrentTurnState);
	}
	
}
