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
				return ConfigManager.Instance.ConfigObject.CommonCardWeight;
			case Enums.Rarity.Rare:
				return ConfigManager.Instance.ConfigObject.RareCardWeight;
			case Enums.Rarity.Epic:
				return ConfigManager.Instance.ConfigObject.EpicCardWeight;
			case Enums.Rarity.Legendary:
				return ConfigManager.Instance.ConfigObject.LegendaryCardWeight;
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
