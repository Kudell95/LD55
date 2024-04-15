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

	public void PlayCard()
	{
		
		GameManager.Instance.PlayerController.RemoveMana(CardData.Mana);
		
		if(CardData.CardAbilities == null || CardData.CardAbilities.Count == 0)
		{
			GameManager.Instance.InputBlockers.Pop();
			return;
		}
		
		foreach(CardAbilitySO ability in CardData.CardAbilities)		
		{
			
			//if we are not placing, just skip...
			if(ability.AbilityActionType != Enums.AbilityActionType.Place)
				continue;
			
			switch(ability.AbilityType)
			{
				case Enums.AbilityType.Attack:
					//will reference Opponent and attack that opponent based on power of card.
					GameManager.Instance.ObjectAnimationController.PlayAttackAnimation(CardData, ()=>
					{
						GameManager.Instance.OpponentManagerObject.OpponentObject.TakeDamage(ability.Power);
					}, ()=>
					{
						GameManager.Instance.InputBlockers.Pop();
					});
					
					break;
				case Enums.AbilityType.Heal:
					GameManager.Instance.ObjectAnimationController.PlayMiscObjectAnimation(CardData, ()=>
					{
						GameManager.Instance.PlayerController.Heal(ability.Power);
						GameManager.Instance.InputBlockers.Pop();
					});
					break;
				case Enums.AbilityType.DefenceBuff:
					GameManager.Instance.ObjectAnimationController.PlayMiscObjectAnimation(CardData, ()=>
					{
						GameManager.Instance.InputBlockers.Pop();
						MutatorList.Instance.Add(CardData);
					});
					
					break;
				case Enums.AbilityType.TurnSkip:
					GameManager.Instance.ObjectAnimationController.PlayMiscObjectAnimation(CardData, ()=>
					{
						//just add the mutator
						GameManager.Instance.InputBlockers.Pop();
						MutatorList.Instance.Add(CardData);
					});
					
					break;
				case Enums.AbilityType.AttackBuff:
					GameManager.Instance.ObjectAnimationController.PlayMiscObjectAnimation(CardData, ()=>
					{
						GameManager.Instance.InputBlockers.Pop();
						MutatorList.Instance.Add(CardData);
					});
					
					break;
				case Enums.AbilityType.HealForRound:
					GameManager.Instance.ObjectAnimationController.PlayMiscObjectAnimation(CardData, ()=>
					{
						GameManager.Instance.InputBlockers.Pop();
						MutatorList.Instance.Add(CardData);
					});
					
					break;
				case Enums.AbilityType.AttackRange:
					int attackPower = UnityEngine.Random.Range(ability.AttackRangeStart, ability.AttackRangeEnd);
					GameManager.Instance.ObjectAnimationController.PlayAttackAnimation(CardData, ()=>
					{
						GameManager.Instance.OpponentManagerObject.OpponentObject.TakeDamage(attackPower);
					}, ()=>
					{
						GameManager.Instance.InputBlockers.Pop();
					});
					
					return;
				default:
					Debug.LogWarning("Ability type not implemented: " + ability.AbilityType);
					// GameManager.Instance.InputBlockers.Pop();
					break;
			}
			
		}
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
