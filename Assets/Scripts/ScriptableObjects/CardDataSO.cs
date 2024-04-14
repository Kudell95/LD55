using System.Collections;
using System.Collections.Generic;
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
}
