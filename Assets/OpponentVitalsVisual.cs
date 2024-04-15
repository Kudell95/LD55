using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpponentVitalsVisual : MonoBehaviour
{
	public List<Image> HealthIconImages = new List<Image>();
	public Sprite FullHealthIcon;
	public Sprite EmptyHealthIcon;
	

	
	private void Awake() {
		Opponent.OnHealthUpdated += OnHealthUpdated;
		Opponent.OnHealthInitialised += OnHealthInitialised;
	}

	private void OnHealthInitialised(int val)
	{
	   for(int i = 0; i < HealthIconImages.Count; i++)
		{
			if(i < val){
				HealthIconImages[i].enabled = true;
				HealthIconImages[i].sprite = FullHealthIcon;				
			}else{
				HealthIconImages[i].enabled = false;
			}
			
			
		}
	}

	private void OnHealthUpdated(int val)
	{
		for(int i = 0; i < HealthIconImages.Count; i++)
		{
			if(i < val)			
			{
				HealthIconImages[i].sprite = FullHealthIcon;
			}
			else
			{
				HealthIconImages[i].sprite = EmptyHealthIcon;
			}
		}
	}
	
	void OnDestroy()
	{
		Opponent.OnHealthUpdated -= OnHealthUpdated;
		Opponent.OnHealthInitialised -= OnHealthInitialised;
	}
}
