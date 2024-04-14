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
	private int _StartingMana;
	
	public static Action<int> OnHealthUpdated;
	public static Action<int> OnManaUpdated;
	
	
	private void Awake() {
		_StartingHealth = ConfigManager.Instance.ConfigObject.StartingHealth;
		_StartingMana = ConfigManager.Instance.ConfigObject.StartingMana;
		Health = _StartingHealth;
		Mana = _StartingMana;
		
	}
	
	
	private void Start() {
		OnHealthUpdated?.Invoke(Health);
		OnManaUpdated?.Invoke(Mana);
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
		OnHealthUpdated?.Invoke(Health);
	}
	
	
	
	public void Heal(int amount)
	{
		if((Health + amount) > _StartingHealth)
		{
			Health = _StartingHealth;
		}
		else
		{
			Health += amount;
		}
		
		HealthText.ShowHeal(amount);		
		OnHealthUpdated?.Invoke(Health);
	}
	
	
	public void AddMana(int amount)
	{
		if((Mana + amount) > _StartingMana)
			Mana = _StartingMana;
		else
			Mana += amount;
			
		OnManaUpdated?.Invoke(Mana);
	}
	
	public void RemoveMana(int amount)	
	{
		if(Mana - amount < 0)
			Mana = 0;
		else
			Mana -= amount;
			
		OnManaUpdated?.Invoke(Mana);
	}
	
	public void Die()
	{
		
	}
}
