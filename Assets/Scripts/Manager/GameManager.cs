using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance { get; private set; }
	
	public ConfigSO Config;
	
	
	
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


        Time.timeScale = 0.0f;
    }

    public void Play()
    {
        Time.timeScale = 1.0f;
    }
}
