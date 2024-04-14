using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	[HideInInspector]
	public int Health;
	[HideInInspector]
	public int Mana;
	
	public static Action OnPlayerDeath;
	
	public HealthModifierText HealthText;
	
	//Not even sure if this is needed, maybe can just use the UI elements to keep track of current hand.	
	public List<Card> CurrentHand = new List<Card>();
	
	private int _StartingHealth;
	
	private void Awake() {
		_StartingHealth = ConfigManager.Instance.ConfigObject.StartingHealth;
	}
	
	
	public void TakeDamage(int damage)
	{
		HealthText.ShowDamage(damage);
		Debug.Log("Damage Taken");
		if(Health - damage <= 0)
		{
			Health = 0;
			Die();
			return;
		}
		Health -= damage;		
	}
	
	public void Heal(int amount)
	{
		if(Health + amount > _StartingHealth)
		{
			Health = _StartingHealth;
		}
		else
		{
			Health += amount;
		}
		
		HealthText.ShowHeal(amount);
	}
	
	public void Die()
	{
		
	}
}
