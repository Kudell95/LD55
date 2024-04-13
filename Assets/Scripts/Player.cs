using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public int Health;
	public int Mana;
	
	//Not even sure if this is needed, maybe can just use the UI elements to keep track of current hand.	
	public List<Card> CurrentHand = new List<Card>();
}
