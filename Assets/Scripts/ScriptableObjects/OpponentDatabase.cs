using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewOpponentDB", menuName = "Opponents/OpponentDatabase", order = 1)]
public class OpponentDatabase : ScriptableObject
{
    public List<OpponentDataSO> Opponents = new List<OpponentDataSO>();
}
