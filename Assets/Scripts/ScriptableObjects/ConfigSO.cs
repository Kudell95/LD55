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
	
}
