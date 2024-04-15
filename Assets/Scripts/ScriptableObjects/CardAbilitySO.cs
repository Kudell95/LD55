using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCardAbility", menuName = "Cards/CardAbility", order = 1)]
public class CardAbilitySO : ScriptableObject
{
	public string Name;
	[Multiline]
	public string Description;
	
	public Enums.AbilityType AbilityType;
	public Enums.AbilityActionType AbilityActionType;
	
	[HideIf("AbilityType", Enums.AbilityType.AttackRange)]
	public int Power;
	public bool SkipTurn;
	
	[HideIf("AbilityType", Enums.AbilityType.Attack)]
	[HideIf("AbilityType", Enums.AbilityType.DefenceBuff)]
	
	public int AttackRangeStart;
	
	[HideIf("AbilityType", Enums.AbilityType.Attack)]
	[HideIf("AbilityType", Enums.AbilityType.DefenceBuff)]
	public int AttackRangeEnd;
	
}
