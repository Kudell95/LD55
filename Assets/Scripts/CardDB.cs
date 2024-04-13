using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
	
	
	public Card GetRandomCard()
	{
		return AvailableCards[Random.Range(0, AvailableCards.Count)].Clone();
	}
	
}
