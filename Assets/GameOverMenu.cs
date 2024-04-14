using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

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
        if (Input.GetKeyDown(KeyCode.G))
        {
            GameOver();
        }
    }
    public IEnumerator GameOverScreenAnimation()
    {
        float _moveTime = 0f;
        float elapsedTime = 0f;
        while (elapsedTime < _moveTime)
        {
            elapsedTime += Time.deltaTime;

            GameOverText.DOFade(255f, 3f);
            
            yield return null;
        }

    }

    public void GameOver()
    {
        gameOverMenu.SetActive(true);
        StartCoroutine(GameOverScreenAnimation());
    }

    public void ExitButton()
    {
        GameManager.Instance.Play(); //if paused, Exit() will not work!
        GameManager.Instance.Exit(); // To MainMenu!
    }
}
