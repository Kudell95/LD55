using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : ICard
{
	public CardDataSO CardData;
	
	
	public void Discard()
	{
		throw new System.NotImplementedException();
	}

	public void PlayCard()
	{
		throw new System.NotImplementedException();
	}
	
	public Card(){}
	public Card(CardDataSO carddata)	
	{
		CardData = carddata;
	}

}
