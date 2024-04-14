using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
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
	
	public TextMeshProUGUI NameText;
	public TextMeshProUGUI DescriptionText;
	public TextMeshProUGUI ManaText;
	public Image CardImage;

	//for animation
	public CanvasGroup TextCanvasGroup;
	
	
	public void Start()
	{
		GetRandomCard();
	}
	
	public void SetCard(Card card)
	{
		CurrentCard = card;
		NameText.text = card.CardData.Name;
		DescriptionText.text = card.CardData.Description;
		ManaText.text = card.CardData.Mana.ToString();
		CardImage.sprite = card.CardData.Image;
	}
	
	
	public void GetRandomCard()
	{
		Card card = GameManager.Instance.CardDatabase.GetRandomCard();
		CurrentCard = card;
		NameText.text = card.CardData.Name;
		DescriptionText.text = card.CardData.Description;
		ManaText.text = card.CardData.Mana.ToString();
		CardImage.sprite = card.CardData.Image;
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

	public IEnumerator AnimateUseCard(bool startingAnimation)
	{
		TextCanvasGroup.DOFade(0f, 1f);
        yield return null;
	}
	
	
	public void UseCard()
	{
		StartCoroutine(AnimateUseCard(true));
		CurrentCard.PlayCard();
	}
}