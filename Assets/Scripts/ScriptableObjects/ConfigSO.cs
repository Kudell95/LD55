using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Config", menuName = "Config/GameConfig", order = 1)]
public class ConfigSO : ScriptableObject
{
	[Header("Cards")]
	public float CommonCardWeight;
	public float RareCardWeight;
	public float EpicCardWeight;
	public float LegendaryCardWeight;
	
	[Header("Player")]
	public int StartingHealth;
	public int StartingMana;	
	public int MaxCardsInHand;
	public int ManaRestoredAtEndOfRound;
	
	[Header("Opponents")]
	public float OpponentHealThreshold;
	public int NumberOfMinionsPerDifficulty;
	
	
	[Header("Cards")]
	public int CardsForStartOfRound;
	public int CardsReceivedEndOfTurn;
	
}
