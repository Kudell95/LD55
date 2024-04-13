using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance { get; private set; }
	
	
	public Player PlayerController;
	public CardDB CardDatabase;

	public OpponentDB OpponentList;
	
	
	private void Awake() {
		if (Instance == null) {
			Instance = this;
		} else {
			Destroy(this);
		}
	}
	
	private void Start()
	{
		//ensure timescale running etc...
		Play();
		
		//TODO: Initialise the Turn Manager... What order do we need!!!
		// Game manager handles each level, on opponent kill we advance to the next enemy/boss.
		// when new enemy queued, play lil animation.
		// and let the turn manager know to queue up a player turn.
		// If player dies, display death screen with stats.
		// Once all enemies are dead, display victory screen with stats? or something... Fireworks 😳
		// 
		
		
		//Levels consist of 2/3 minion enemies, 1 boss enemy.
		//After 3 levels, show final boss.
	}
	
	public void TogglePause()
	{
		if (Time.timeScale == 0.0f)
		{
			Play();
		}
		else
		{
			Pause();
		}
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
}
