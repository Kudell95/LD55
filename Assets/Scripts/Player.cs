using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
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
	
	AnimationHelper _animationHelper;
	public SpriteRenderer VisualsSpriteRenderer;
	
	
	private void Awake() {
		if(ConfigManager.Instance == null)
			return;
		_StartingHealth = ConfigManager.Instance.ConfigObject.StartingHealth;
		_StartingMana = ConfigManager.Instance.ConfigObject.StartingMana;
		Health = _StartingHealth;
		Mana = _StartingMana;
		_animationHelper = GetComponent<AnimationHelper>();
	}
	
	
	private void Start() {
		OnHealthUpdated?.Invoke(Health);
		OnManaUpdated?.Invoke(Mana);
	}
	
	
	
	public void TakeDamage(int damage)
	{
		SoundManager.Instance.PlaySound("TakeDamage");
		HealthText.ShowDamage(damage);
		Debug.Log("Damage Taken");
		if(Health - damage <= 0)
		{
			Health = 0;
			Die();
			return;
		}
		Health -= damage;
		_animationHelper.OnHit(transform,VisualsSpriteRenderer);
		OnHealthUpdated?.Invoke(Health);
	}
	
	
	
	public void Heal(int amount)
	{
		SoundManager.Instance.PlaySound("Heal");
		
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
		SoundManager.Instance.PlaySound("AddMana");
		if((Mana + amount) > _StartingMana)
			Mana = _StartingMana;
		else
			Mana += amount;
			
		OnManaUpdated?.Invoke(Mana);
	}
	
	public void RemoveMana(int amount)	
	{
		SoundManager.Instance.PlaySound("RemoveMana");
		if(Mana - amount < 0)
			Mana = 0;
		else
			Mana -= amount;
			
		OnManaUpdated?.Invoke(Mana);
	}
	
	
	public void AddBuff(CardDataSO card, int power)
	{
		//TODO: Implement This
	}
	
	
	public void Die()
	{
		TurnBasedManager.Instance.StartTurn(Enums.TurnStates.PlayerDeadTurn,false,false);
		transform.DOShakeScale(1f).OnComplete(()=>
		{
			transform.DOScaleX(0,0.2f).OnComplete(()=>
			{
				GameOverMenu.Instance.GameOver();
			});
		});		
	}
}
