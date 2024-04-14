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

    // for animation
    public TextMeshProUGUI GameOverText;
    public TextMeshProUGUI GameOverSubText;
    public void Start()
    {
        gameOverMenu.SetActive(false);
    }

    private void Update()
    {

    }
    private void DoDelayAction(float delayTime)
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
        DoDelayAction(2f);
    }

    public void ExitButton()
    {
        GameManager.Instance.Play(); //if paused, Exit() will not work!
        GameManager.Instance.Exit(); // To MainMenu!
    }
}
