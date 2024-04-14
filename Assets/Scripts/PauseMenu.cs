using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private readonly KeyCode pauseMenuKey = KeyCode.Escape;
    private bool isPaused = false;
    public GameObject pauseMenu;

   void Start()
    {

    }
    void Update()
    {
        if (Input.GetKeyDown(pauseMenuKey))
        {
            GameManager.Instance.TogglePause();
            if (isPaused)
            {
                isPaused = false;
                pauseMenu.SetActive(false);
            }
            else
            {
                isPaused = true;
                pauseMenu.SetActive(true);
            }
        }
    }

    public void MuteButton()
    {
        SoundManager.Instance.ToggleMute();
    }

    public void ExitButton()
    {
        GameManager.Instance.Play(); //if paused, Exit() will not work!
        GameManager.Instance.Exit(); // To MainMenu!
    }
}
