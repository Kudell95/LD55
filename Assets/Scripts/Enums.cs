using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enums : MonoBehaviour
{	
	public enum Scenes
	{
		MainMenu = 1,
		GameScene = 2,
		LoadingScene = 3,
	}
	
	public enum Rarity
	{
		Common,
		Rare,
		Epic,
		Legendary
	}
	
	
	public enum AbilityType
	{
		Attack,
		Heal,
		Repel,
	}
	
	public enum AbilityActionType
	{
		Place,
		Discard
	}

	public enum OpponentDifficulty
	{
		Recruit = 1,
		Champion,
		Legend
	}

	public enum OpponentAbility // WIP
	{
		BasicAttack,
		Retreat,
		Heal
	}

	//public enum OpponentAttributes // WIP
	//{
	//	Stunned,
	//	Thorned,
	//	Frightened,
	//	Thirsty
	//}
	
	
	public enum TurnStates
	{
		InitialTurn,
		PlayerTurn,
		
		OpponentTurn,
		
	}
}
