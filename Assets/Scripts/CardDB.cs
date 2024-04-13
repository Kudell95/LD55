using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDB : MonoBehaviour
{
	[HideInInspector]
	public List<Card> AvailableCards = new List<Card>();
	
	[SerializeField]
	private List<CardDataSO> CardData = new List<CardDataSO>();
	
	
	private void GenerateCards()
	{
		foreach(CardDataSO c in CardData)
		{
			Card newCard = new Card(c);
			AvailableCards.Add(newCard);
		}
	}
	
	public void Awake()
	{
		GenerateCards();
	}
	
	
	
	
}
