using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndTurnButton : MonoBehaviour
{
	private Button _button;
	public Color TextEnabledColour;
	public Color TextDisabledColour;
	public TextMeshProUGUI ButtonText;
	
	
	// Start is called before the first frame update
	void Start()
	{
		_button = GetComponent<Button>();
		SetDisabled();
		TurnBasedManager.Instance.OnTurnStarted += onTurnStarted;
		GameManager.Instance.OnInputUnblocked += onInputUnblocked;
	}

	private void onInputUnblocked()
	{
		if(TurnBasedManager.Instance.CurrentTurnState == Enums.TurnStates.PlayerTurn)
			SetEnabled();
	}

	public void onTurnStarted(Enums.TurnStates turnState)
	{
		if(turnState == Enums.TurnStates.PlayerTurn)
			SetEnabled();
		else
			SetDisabled();
	}
	
	
	public void EndTurn()
	{
		SoundManager.Instance?.PlaySound("ButtonClick");
		TurnBasedManager.Instance.EndTurn();
	}
	
	private void Update() {
		//TODO: maybe just use events here?
		if(GameManager.Instance.InputBlocked)
		{
			SetDisabled();
		}	
	}
	

	
	public void SetEnabled()
	{
		_button.interactable = true;
		ButtonText.color = TextEnabledColour;
	}
	
	public void SetDisabled()
	{
		_button.interactable = false;
		ButtonText.color = TextDisabledColour;
	}
	
	
	private void OnDestroy() {
		TurnBasedManager.Instance.OnTurnStarted -= onTurnStarted;
		GameManager.Instance.OnInputUnblocked -= onInputUnblocked;
		
	}
}
