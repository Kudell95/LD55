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
	
	public void StartTurn(Enums.TurnStates turnState, bool drawCards = false)
	{		
		if(turnState == Enums.TurnStates.PlayerTurn && drawCards)
		{
			GameManager.Instance.DrawCards(ConfigManager.Instance.ConfigObject.CardsReceivedEndOfTurn);
			return;
		}			
		CurrentTurnState = turnState;
		OnTurnStarted?.Invoke(turnState);
		
		
		NotificationManager.Instance?.Notify(getTurnText(turnState));
	}
	
	public void EndTurn()
	{
		Enums.TurnStates nextTurn;
		switch(CurrentTurnState)
		{
			case Enums.TurnStates.PlayerTurn:
				nextTurn = Enums.TurnStates.OpponentTurn;
				break;
			case Enums.TurnStates.OpponentTurn:
				nextTurn = Enums.TurnStates.PlayerTurn;
				break;
			default:
				nextTurn = Enums.TurnStates.PlayerTurn;
				break;
		}
		
		OnTurnEnded?.Invoke(CurrentTurnState);
		
		StartTurn(nextTurn);
	}
	
	
	public string getTurnText(Enums.TurnStates turnStates)
	{
		switch(turnStates)
		{
			case Enums.TurnStates.PlayerTurn:
				return "Player's Turn";
			case Enums.TurnStates.OpponentTurn:
				return "Opponent's Turn";
			default:
				return "";
		}
	}
	
}
