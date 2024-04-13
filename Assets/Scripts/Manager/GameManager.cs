using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance { get; private set; }
	
	public ConfigSO Config;
	public CardDB CardDatabase;
	
	
	private void Awake() {
		if (Instance == null) {
			Instance = this;
		} else {
			Destroy(this);
		}
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
