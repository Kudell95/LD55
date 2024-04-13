using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardTester : MonoBehaviour
{
	public TextMeshProUGUI NameText;
	public TextMeshProUGUI DescriptionText;
	public TextMeshProUGUI ManaText;
	
	
	public void Start()
	{
		GetRandomCard();		
	}
	
	public void GetRandomCard()
	{
		Card card = GameManager.Instance.CardDatabase.GetRandomCard();
		
		NameText.text = card.CardData.Name;
		DescriptionText.text = card.CardData.Description;
		ManaText.text = card.CardData.Mana.ToString();
	}
	
	public void Update()
	{
		#if UNITY_EDITOR
		if(Input.GetKeyDown(KeyCode.J))
		{
			GetRandomCard();
		}
		#endif
	}
}
