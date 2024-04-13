using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class CardDB : MonoBehaviour
{
	[HideInInspector]
	public Dictionary<Card,float> AvailableCards = new Dictionary<Card, float>();
	
	[SerializeField]
	private DeckSO CurrentDeck;
		
	
	private void GenerateCards()
	{
		foreach(CardDataSO c in CurrentDeck.Cards)
		{
			Card newCard = new Card(c);
			AvailableCards.Add(newCard, GetRarityWeight(c.CardRarity));
		}
	}
	
	public void Awake()
	{
		GenerateCards();
	}
	
	
	public Card GetRandomCard()
	{
		return AvailableCards.RandomElementByWeight(e=> e.Value).Key.Clone();
	}
	
	
	public float GetRarityWeight(Enums.Rarity rarity)
	{
		switch(rarity)
		{
			case Enums.Rarity.Common:
				return 0.91f;
			case Enums.Rarity.Rare:
				return 0.2f;
			case Enums.Rarity.Epic:
				return 0.1f;
			case Enums.Rarity.Legendary:
				return 0.05f;
			default:
				return 1f;
		}
	}
	
	public Card GetCardByID(string id)
	{
		return AvailableCards.Keys.FirstOrDefault(x => x.GUID == id);
	}
	
	public Card GetCardByName(string name)
	{
		return AvailableCards.Keys.FirstOrDefault(x => x.CardData.Name == name);
	}
	
}
