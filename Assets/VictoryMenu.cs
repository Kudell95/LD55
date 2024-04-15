using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using System;

public class VictoryMenu : MonoBehaviour
{
    public GameObject victoryMenu;

    // for animation
    public TextMeshProUGUI VictorText;
    public TextMeshProUGUI victorySubText;
    public void Start()
    {
        victoryMenu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            Victory();
        }
    }
    private void DoDelaySubTextAlpha(float delayTime)
    {
        StartCoroutine(DelayAction(delayTime));
    }
    private IEnumerator DelayAction(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        victorySubText.DOFade(2f, 5f);
    }

    public void Victory()
    {
        victoryMenu.SetActive(true);
        VictorText.DOFade(1f, 3f);
        DoDelaySubTextAlpha(2f);
    }

    public void ExitButton()
    {
        GameManager.Instance.Play(); //if paused, Exit() will not work!
        GameManager.Instance.Exit(); // To MainMenu!
    }
}