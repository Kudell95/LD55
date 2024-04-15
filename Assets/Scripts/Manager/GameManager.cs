using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance { get; private set; }
	public Player PlayerController;
	public CardDB CardDatabase;
	
	public VisualAnimationController ObjectAnimationController;
	public OpponentManager OpponentManagerObject;

	public OpponentDB OpponentList;
	
	public Enums.OpponentDifficulty CurrentDifficulty;	
	
	public static Action<int> OnCardsAdded;
	public static Action OnCardAddComplete;
	public static Action OnCardUsed;
	
	public Stack<string> InputBlockers = new Stack<string>();
	
	public bool InputBlocked 
	{
		get
		{
			if(InputBlockers == null || InputBlockers.Count == 0) return false;
			
			return InputBlockers.Count > 0;
		}	
	}
	public static bool Paused;
	
	
	int MinionCounter;
	bool finalboss = false;
	//dont like this method of doing this, but JAM BABY
	bool isFreshStart;
	
	private void Awake() {
		if (Instance == null) {
			Instance = this;
		} else {
			Destroy(this);
		}
	}
	
	private void Start()
	{
		OpponentManager.OnOpponentReadyForFight += onOpponentReadyForFight;
		OnCardAddComplete += onCardAddComplete;
		Opponent.OnOpponentDeath += onOpponentDeath;
		isFreshStart = true;
		CurrentDifficulty = Enums.OpponentDifficulty.Recruit;
		//ensure timescale running etc...
		Play();
		
		GetNewOpponent(CurrentDifficulty);		
	}

	private void onOpponentDeath()
	{
		if(finalboss)
		{
			TurnBasedManager.Instance.StartTurn(Enums.TurnStates.VictoryTurn,false,false);
			VictoryMenu.Instance.Victory();
			return;
		}
		
		bool boss = false;
		finalboss = false;
		if(MinionCounter == ConfigManager.Instance.ConfigObject.NumberOfMinionsPerDifficulty && CurrentDifficulty != Enums.OpponentDifficulty.Legend)		
		{
			boss = true;
		}else if (MinionCounter == ConfigManager.Instance.ConfigObject.NumberOfMinionsPerDifficulty && CurrentDifficulty == Enums.OpponentDifficulty.Legend)
		{
			finalboss = true;
		}else if(MinionCounter > ConfigManager.Instance.ConfigObject.NumberOfMinionsPerDifficulty)		
		{
			MinionCounter = 0;
			CurrentDifficulty = CurrentDifficulty + 1;
		}
		
		GetNewOpponent(CurrentDifficulty,boss,finalboss);		
		
	}

	private void onOpponentReadyForFight()
	{
		//if the opponent is ready to fight, tell the turn manager to start a player turn.
		if(isFreshStart)
		{
			DrawCards(ConfigManager.Instance.ConfigObject.CardsForStartOfRound);	
		}
		else
		{
			DrawCards(ConfigManager.Instance.ConfigObject.CardsReceivedEndOfTurn);
			PlayerController.AddMana(ConfigManager.Instance.ConfigObject.ManaRestoredAtEndOfRound);
		}
		isFreshStart = false;
	}
	
	private void onCardAddComplete()
	{
		TurnBasedManager.Instance.StartTurn(Enums.TurnStates.PlayerTurn, false);
	}

	public void TogglePause()
	{
		if (Paused)
		{
			Paused = false;
			Play();
		}
		else
		{
			Paused = true;
			Pause();
		}
	}
	
	void GetNewOpponent(Enums.OpponentDifficulty difficulty, bool boss = false, bool finalboss = false)
	{
		OpponentManagerObject.GetNewOpponent(difficulty, boss,finalboss);
		MinionCounter++;
	}
	
	public void DrawCards(int amount)
	{
		Debug.Log("drawing cards");
		OnCardsAdded?.Invoke(amount);
	}
	
	
	public void Pause()
	{
		Time.timeScale = 0.0f;
	}

	public void Play()
	{
		Time.timeScale = 1.0f;
	}

	public void Exit()
	{
		SceneTransitionManager.Instance.LoadScene(Enums.Scenes.MainMenu);
		Debug.Log("Exiting to main menu.");
	}
	
	
	private void OnDestroy() {
		OpponentManager.OnOpponentReadyForFight -= onOpponentReadyForFight;
		OnCardAddComplete -= onCardAddComplete;
	}
}
