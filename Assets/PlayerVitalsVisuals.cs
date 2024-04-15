using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerVitalsVisuals : MonoBehaviour
{
	public List<Image> HealthIconImages = new List<Image>();
	public List<Image> ManaIconImages = new List<Image>();
	
	public Sprite FullHealthIcon;
	public Sprite EmptyHealthIcon;
	
	public Sprite CompletelyEmptyHealthIcon;
	public Sprite FullManaIcon;
	public Sprite EmptyManaIcon;
	
	
	
	
	private void Awake() {
		Player.OnHealthUpdated += OnHealthUpdated;
		Player.OnManaUpdated += OnManaUpdated;
	}

	private void OnManaUpdated(int val)
	{
		for(int i = 0; i < ManaIconImages.Count; i++)
		{
			if(i < val)			
			{
				ManaIconImages[i].sprite = FullManaIcon;
			}
			else
			{
				ManaIconImages[i].sprite = EmptyManaIcon;
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
			else if(i == val)
			{
				HealthIconImages[i].sprite = EmptyHealthIcon;
			}
			else
			{
				HealthIconImages[i].sprite = CompletelyEmptyHealthIcon;
			}
		}
	}
	
	void OnDestroy()
	{
		Player.OnHealthUpdated -= OnHealthUpdated;
		Player.OnManaUpdated -= OnManaUpdated;
	}
}
