using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDB : MonoBehaviour
{
	[HideInInspector]
	public List<Card> AvailableCards = new List<Card>();
	
	[SerializeField]
	private DeckSO CurrentDeck;
	
	
	private void GenerateCards()
	{
		foreach(CardDataSO c in CurrentDeck.Cards)
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
