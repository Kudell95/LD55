using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private readonly KeyCode pauseMenuKey = KeyCode.Escape;
    private void Update()
    {
        if (Input.GetKeyDown(pauseMenuKey))
        {
            GameManager.Instance.TogglePause();
        }
    }
}
