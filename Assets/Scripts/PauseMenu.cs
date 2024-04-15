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
		isPaused = true;
		pauseMenu.SetActive(true);
	}
	
	public void Hide()
	{
		isPaused = false;
		pauseMenu.SetActive(false);
	}
	
	

	public void MuteButton()
	{
		SoundManager.Instance.ToggleMute();
	}

	public void ExitButton()
	{
		GameManager.Instance.Play(); //if paused, Exit() will not work!
		Hide();
		GameManager.Instance.Exit(); // To MainMenu!
	}
	
	public void ResumeButton()
	{
		
		GameManager.Instance.TogglePause();
		Hide();
	}
}
