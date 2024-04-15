using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using System;

public class GameOverMenu : MonoBehaviour
{
	public GameObject gameOverMenu;
	
	public static GameOverMenu Instance;
	
	
	

	// for animation
	public TextMeshProUGUI GameOverText;
	public TextMeshProUGUI GameOverSubText;
	
	private void Awake() {
		if(Instance == null)
		{
			Instance = this;
		}
		else
		{
			Destroy(this);
		}
	}
	
	public void Start()
	{
		gameOverMenu.SetActive(false);
	}

	
	private void DoDelaySubTextAlpha(float delayTime)
	{
		StartCoroutine(DelayAction(delayTime));
	}
	
	private IEnumerator DelayAction(float delayTime)
	{
		yield return new WaitForSeconds(delayTime);
		GameOverSubText.DOFade(2f, 5f);
	}

	public void GameOver()
	{
		
		gameOverMenu.SetActive(true);
		GameOverText.DOFade(1f, 3f);
		DoDelaySubTextAlpha(2f);
	}

	public void ExitButton()
	{
		SoundManager.Instance?.PlaySound("ButtonClick");
		GameManager.Instance.Play(); //if paused, Exit() will not work!
		GameManager.Instance.Exit(); // To MainMenu!
	}
}
