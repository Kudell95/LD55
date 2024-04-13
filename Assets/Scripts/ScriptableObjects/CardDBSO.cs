using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardDB", menuName = "Cards/Card Database", order = 1)]
public class CardDBSO : ScriptableObject
{
	public List<CardDataSO> Cards = new List<CardDataSO>();
}
