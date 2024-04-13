using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Opponent", menuName = "Opponents/OpponentData", order = 1)]
public class OpponentSO : ScriptableObject
{
    public List<OpponentDataSO> Opponents = new List<OpponentDataSO>();
}
