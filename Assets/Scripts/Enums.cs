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
}
