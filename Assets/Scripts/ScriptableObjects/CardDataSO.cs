using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;


[CreateAssetMenu(fileName = "NewCard", menuName = "Cards/CardData", order = 1)]
public class CardDataSO : ScriptableObject
{
	public string Name;
	[Multiline]
	public string Description;
	public int Mana;
	public Enums.Rarity CardRarity;
	public Sprite Image;
	public List<CardAbilitySO> CardAbilities = new List<CardAbilitySO>();
	public Enums.BroadAbilityType BroadAbilityType;
	
	[HideIf("BroadAbilityType", Enums.BroadAbilityType.Heal)]
	[HideIf("BroadAbilityType", Enums.BroadAbilityType.Attack)]	
	public bool ActiveTillEndOfRound;
	[HideIf("BroadAbilityType", Enums.BroadAbilityType.Heal)]
	[HideIf("BroadAbilityType", Enums.BroadAbilityType.Attack)]	
	public bool SingleUse;
}
