using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	[HideInInspector]
	public int Health;
	[HideInInspector]
	public int Mana;
	
	//Not even sure if this is needed, maybe can just use the UI elements to keep track of current hand.	
	public List<Card> CurrentHand = new List<Card>();
}
