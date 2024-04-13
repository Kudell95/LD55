using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewOpponentAbility", menuName = "Opponent/OpponentAbility", order = 1)]
public class OpponentAbilitySO : ScriptableObject
{
    public string Name;
    [Multiline]
    public string Description;

    public Enums.OpponentAbility OpponentAbility;

    public int PowerModifier;
}
