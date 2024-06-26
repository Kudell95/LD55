using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewOpponentAbility", menuName = "Opponents/OpponentAbility", order = 1)]
public class OpponentAbilitySO : ScriptableObject
{
	public string Name;
	[Multiline]
	public string Description;

	public Enums.OpponentAbility OpponentAbility;
    public Enums.OpponentAbilityType BroadAbilityType;
	

	public int PowerModifier;
}
