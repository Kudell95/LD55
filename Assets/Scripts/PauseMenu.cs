using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
	private readonly KeyCode pauseMenuKey = KeyCode.Escape;
	private bool isPaused = false;
	public GameObject pauseMenu;

   void Start()
	{
		pauseMenu.SetActive(false);
	}
	void Update()
	{
		if (Input.GetKeyDown(pauseMenuKey))
		{
			GameManager.Instance.TogglePause();
			if (isPaused)
			{
				Hide();
			}
			else
			{
				Show();	
			}
		}
	}
	
	public void Show()
	{
		SoundManager.Instance?.PlaySound("Pause");
		isPaused = true;
		pauseMenu.SetActive(true);
		GameManager.Instance.Pause();		
	}
	
	public void Hide()
	{
		SoundManager.Instance?.PlaySound("Resume");		
		isPaused = false;
		pauseMenu.SetActive(false);
		GameManager.Instance.Play();
	}
	
	

	public void MuteButton()
	{
		SoundManager.Instance?.PlaySound("ButtonClick");
		SoundManager.Instance.ToggleMute();
	}

	public void ExitButton()
	{
		SoundManager.Instance?.PlaySound("ButtonClick");
		Hide();
		GameManager.Instance.Exit(); // To MainMenu!
	}
	
	public void ResumeButton()
	{
		SoundManager.Instance?.PlaySound("ButtonClick");
		Hide();
	}
}
