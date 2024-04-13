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
        pauseMenu.SetActive(false);
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
       SceneTransitionManager.Instance.LoadScene(Enums.Scenes.MainMenu);
    }
}
