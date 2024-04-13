using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCardAbility", menuName = "Cards/CardAbility", order = 1)]
public class CardAbilitySO : ScriptableObject
{
   public string Name;
   [Multiline]
   public string Description;
   
   public Enums.AbilityType AbilityType;
   public Enums.AbilityActionType AbilityActionType;
   
   public int Power;
}
