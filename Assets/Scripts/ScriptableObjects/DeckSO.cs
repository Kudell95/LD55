using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDeck", menuName = "Cards/Deck", order = 1)]
public class DeckSO : ScriptableObject
{
	public List<CardDataSO> Cards = new List<CardDataSO>();
}
