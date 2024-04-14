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
		foreach(CardAbilitySO ability in CardData.CardAbilities)		
		{
			//if we are not placing, just skip...
			if(ability.AbilityActionType != Enums.AbilityActionType.Place)
				continue;
			
			//TODO: Maybe should implement events for attack/heal etc... as there will only be one enemy at a time for now no need to worry about targets etc...
			switch(ability.AbilityType)
			{
				case Enums.AbilityType.Attack:
					//TODO: Perform attack
					//will reference Opponent and attack that opponent based on power of card.
					GameManager.Instance.OpponentManagerObject.OpponentObject.TakeDamage(ability.Power);
					break;
				case Enums.AbilityType.Heal:
					//TODO: Perform healing.
					//will reference player and heal that player based on power of card.
					GameManager.Instance.PlayerController.Heal(ability.Power);
					break;
				case Enums.AbilityType.Repel:
					//TODO: Perform debuff
					break;
				default:
					Debug.LogWarning("Ability type not implemented: " + ability.AbilityType);
					break;
			}
			
		}
		GameManager.Instance.PlayerController.RemoveMana(CardData.Mana);
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
