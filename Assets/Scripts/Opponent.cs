using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using JetBrains.Annotations;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Timeline;

public class Opponent : MonoBehaviour, IOpponent
{
	public OpponentDataSO OpponentData;
	
	public int Health;
	public string GUID;
	public SpriteRenderer OpponentSpriteRenderer;
	public Transform SpriteOriginPoint;
	
	public static Action<int> OnHealOpponent;
	public static Action<int> OnOpponentDamage;
	
	public static Action OnOpponentDeath;
	public HealthModifierText healthModifierText;
	
	public static Action<int> OnHealthInitialised;
	public static Action<int> OnHealthUpdated;
	
	private AnimationHelper animationHelper;
	
	float _opponentOriginalScaleY;
	
	private void Awake() {
		_opponentOriginalScaleY = SpriteOriginPoint.localScale.y;
		SpriteOriginPoint.transform.DOScaleY(0,0);
		
		SpriteOriginPoint.transform.localScale = new Vector3(SpriteOriginPoint.transform.localScale.x, 0, SpriteOriginPoint.transform.localScale.z);
		animationHelper = GetComponent<AnimationHelper>();
	}
	
	public void Attack()
	{
		
		OpponentAbilitySO selectedAbility = GetRandomAbility();
		if(selectedAbility == null)			
		{
			LeanTween.delayedCall(2f,()=>
			{				
				TurnBasedManager.Instance.EndTurn();
			});
			return;
		}
		
		LeanTween.delayedCall(1f, ()=>
		{			
			SoundManager.Instance.PlaySound("OpponentAttack");
		});
		
		LeanTween.delayedCall(2f,()=>
		{								
			SpriteOriginPoint.DOLocalMoveX(-0.8f,0.01f).OnComplete(()=>
			{
				PerformAbility(selectedAbility);
				SpriteOriginPoint.DOLocalMoveX(0.8f,0.4f).OnComplete(()=>
				{
					LeanTween.delayedCall(2f,()=>
					{				
						
						TurnBasedManager.Instance.EndTurn();
					});
				});
			});
		});
	}
	
	
	public OpponentAbilitySO GetRandomAbility()
	{
		if(Health <= (OpponentData.Health * ConfigManager.Instance.ConfigObject.OpponentHealThreshold))
		{
			return OpponentData.OpponentAbilities[UnityEngine.Random.Range(0,OpponentData.OpponentAbilities.Count)];
		}
		else
		{
			List<OpponentAbilitySO> availableAbilities = new List<OpponentAbilitySO>();
			availableAbilities = OpponentData.OpponentAbilities.Where(x=> x.BroadAbilityType != Enums.OpponentAbilityType.Heal).ToList();
			if(availableAbilities == null || availableAbilities.Count == 0 )
				return null;
			return availableAbilities[UnityEngine.Random.Range(0,availableAbilities.Count)];
		}
		
		
		
	}
	
	
	public void PerformAbility(OpponentAbilitySO ability)
	{
		switch(ability.OpponentAbility)
		{
			case Enums.OpponentAbility.BasicAttack:				
				GameManager.Instance.PlayerController.TakeDamage(ability.PowerModifier);
				break;
			case Enums.OpponentAbility.Heal:
				Heal(ability.PowerModifier);
				break;
			default:
				return;

		}
	}

	public void Die()
	{
		SoundManager.Instance.PlaySound("OpponentDie");
		
		if(OpponentData.FinalBoss)
			TurnBasedManager.Instance.StartTurn(Enums.TurnStates.OpponentSpawnTurn,false,false);
		else
			TurnBasedManager.Instance.StartTurn(Enums.TurnStates.OpponentSpawnTurn,false,true);
		// animationHelper.OnHit(transform);
		SpriteOriginPoint.transform.DOScaleY(0,0.2f).OnComplete(()=>
		{
			LeanTween.delayedCall(2f,()=>
			{				
				OnOpponentDeath?.Invoke();
			});
		});
	}

	public Opponent Clone()
	{
		return (Opponent)MemberwiseClone();
	}

	public Opponent()
	{
		GUID = System.Guid.NewGuid().ToString();
	}
	public Opponent(OpponentDataSO opponenentData)
	{
		GUID = System.Guid.NewGuid().ToString();
		OpponentData = opponenentData;
	}
	
	public void Heal(int amount)
	{
		SoundManager.Instance.PlaySound("OpponentHeal");
		if(Health + amount > OpponentData.Health)
		{
			Health = OpponentData.Health;
		}
		else
		{
			Health += amount;
		}
		
		healthModifierText.ShowHeal(amount);
		OnHealthUpdated?.Invoke(Health);
	}
	
	public void TakeDamage(int damage)
	{
		int BuffedDamage = 0;
		
		if(MutatorList.Instance.ContainsAttackBuff() && damage > 0)
		{
			BuffedDamage = MutatorList.Instance.GetTotalAttackbuff(out List<Mutator> mutators);
			
			if(mutators != null && mutators.Count > 0)
			{
				MutatorList.Instance.Remove(mutators);
			}
		}		
			
		damage += BuffedDamage;
			
			
		SoundManager.Instance.PlaySound("OpponentTakeDamage");
		healthModifierText.ShowDamage(damage, BuffedDamage > 0);
		
		if(Health - damage <= 0)
		{
			Health = 0;			
			OnHealthUpdated?.Invoke(Health);
			animationHelper.OnHit(SpriteOriginPoint.transform, OpponentSpriteRenderer);
			Die();
			return;
		}
		Health -= damage;
		animationHelper.OnHit(SpriteOriginPoint.transform, OpponentSpriteRenderer);
		OnHealthUpdated?.Invoke(Health);
	}
	
	public void SpawnNewOpponent(OpponentDataSO newOpponentData)
	{
		
		OpponentData = newOpponentData;
		Health = OpponentData.Health;
		OpponentSpriteRenderer.sprite = OpponentData.Image;
		SpriteOriginPoint.transform.DOKill();
		
		SoundManager.Instance.PlaySound("OpponentGrowl");
		SpriteOriginPoint.transform.DOScaleY(_opponentOriginalScaleY,1f).OnComplete(()=>{			
			SpriteOriginPoint.transform.DOShakePosition(1f,0.5f).OnComplete(()=>{				
		 		OpponentManager.OnOpponentReadyForFight?.Invoke();		
				SpriteOriginPoint.transform.DOMoveY(0.5f, 1.5f).OnComplete(()=>{SpriteOriginPoint.transform.DOScaleY(0.9f,0.3f);}).SetLoops(-1,LoopType.Yoyo);
			});			
		});
		OnHealthInitialised?.Invoke(Health);
	
		
		// OpponentManager.OnOpponentReadyForFight?.Invoke();
	}
	
}


