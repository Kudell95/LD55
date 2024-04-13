using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : ICard
{
	public CardDataSO CardData;
	public string GUID;
	
	public void Discard()
	{
		throw new System.NotImplementedException();
	}

	//TODO: This will grab the card data, loop through the abilities and perform actions based on the ability type
	public void PlayCard()
	{
		throw new System.NotImplementedException();
	}

	public Card Clone()
	{
		return (Card)MemberwiseClone();
	}
	
	public Card()
	{
		GUID = System.Guid.NewGuid().ToString();		
	}
	public Card(CardDataSO carddata)	
	{
		GUID = System.Guid.NewGuid().ToString();
		CardData = carddata;
	}

}
