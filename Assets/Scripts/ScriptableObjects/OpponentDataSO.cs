using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "OpponentData", menuName = "Opponents/OpponentData", order = 1)]
public class OpponentDataSO : ScriptableObject
{
	public string Name;
	[Multiline]
	public string Description;
	public int Health;

    public Enums.OpponentDifficulty OpponentDifficulty;
    //Enums.OpponentAttributes OpponentAttributes;
    public Enums.OpponentAbility OpponentAbilities;

	public Sprite Image;

    //public List<OpponentAbilitySO> OpponentAbilities = new List<OpponentAbility>();
    //public List<OpponentAttributesSO> OpponentAttributes = new List<OpponentAttributes>();

}
