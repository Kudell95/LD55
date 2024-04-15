using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The controller for individual cards that are used in UI, updates UI and handles interactions
/// with the card
/// </summary>
public class CardController : MonoBehaviour
{
	public ICard CurrentCard;
	public CardDataSO CardData;
	
	public TextMeshProUGUI NameText;
	public TextMeshProUGUI DescriptionText;
	public TextMeshProUGUI ManaText;
	public Image CardImage;

	//for animation
	public CanvasGroup CardCanvasGroup;
	public Image CardFrameImage;
	public Image ItemImage;
	public RectTransform ImageRectTransform;
	
	public TextMeshProUGUI CardTypeText;
	public Sprite CommonFrame;
	public Sprite RareFrame;
	public Sprite EpicFrame;
	public Sprite LegendaryFrame;
	
	

	
	
	public void SetCard(Card card)
	{
		CurrentCard = card;
		CardData = card.CardData;
		NameText.text = card.CardData.Name;
		DescriptionText.text = card.CardData.Description;
		ManaText.text = card.CardData.Mana.ToString();
		CardImage.sprite = card.CardData.Image;
		CardFrameImage.sprite = GetFrameByRarity(card.CardData.CardRarity);
		CardTypeText.text = card.CardData.BroadAbilityType.ToString();
	}
	
	Sprite GetFrameByRarity(Enums.Rarity rarity)
	{
		switch(rarity)
		{
			case Enums.Rarity.Common:
				return CommonFrame;
			case Enums.Rarity.Rare:
				return RareFrame;
			case Enums.Rarity.Epic:
				return EpicFrame;
			case Enums.Rarity.Legendary:
				return LegendaryFrame;
			default:
				return CommonFrame;
		}
	}
	
	
	public void GetRandomCard()
	{
		Card card = GameManager.Instance.CardDatabase.GetRandomCard();		
		SetCard(card);
	}
	
	public void Update()
	{
		#if UNITY_EDITOR
		if(Input.GetKeyDown(KeyCode.J))
		{
			GetRandomCard();
		}
		#endif
	}

	public void AnimateUseCard()
	{
		
		
		
		
		//fade card
		CardCanvasGroup.DOFade(0f, 1f).OnComplete(()=>
		{
			transform.SetParent(transform.parent.parent);
		});
		// move item up.
		ImageRectTransform.DOLocalMoveY(ImageRectTransform.position.y + 0f, 2.2f).OnComplete(()=>
		{
			
			ItemImage.DOFade(0f, 1f);
		
		});
		
		
		//LeanTween.delayedCall(1f, () => { ItemImage.DOFade(0f, 4f)};
		
	}
	
	public void UnableToUseCard()
	{
		CardFrameImage.transform.DOLocalRotate(new Vector3(0f, 0f, 5f), 0.1f).SetEase(Ease.InOutQuad).SetLoops(4,LoopType.Yoyo).OnComplete(()=> 
		{
			CardFrameImage.transform.DOLocalRotate(new Vector3(0f, 0f, 0f), 0.1f);
		});
	}
	
	public void UseCard()
	{
		if(CardData.Mana > GameManager.Instance.PlayerController.Mana)
		{
			ThoughtBubble.Instance.OnNoManaMessage();
			UnableToUseCard();
			return;
		}
		
		GameManager.Instance.InputBlockers.Push("CardController");
		AnimateUseCard();
		CurrentCard.PlayCard();
		GameManager.OnCardUsed?.Invoke();	
		
		Destroy(this.gameObject,2f);	
	}

	public void OnDestroy()
	{
		ItemImage.DOKill();
		CardCanvasGroup.DOKill();
		ImageRectTransform.DOKill();
	}
}