using DG.Tweening;
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
	
	public TextMeshProUGUI NameText;
	public TextMeshProUGUI DescriptionText;
	public TextMeshProUGUI ManaText;
	public Image CardImage;

    //for animation
    public CanvasGroup CardCanvasGroup;
    public Image CardFrameImage;
    public Image ItemImage;
	public RectTransform ImageRectTransform;

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
		//fade card
		CardCanvasGroup.DOFade(0f, 1f);

		float moveTime = 1f;
		float elapsedTime = 0f;



		while (elapsedTime < moveTime)
		{
			elapsedTime += Time.deltaTime;

			ImageRectTransform.DOLocalMoveY(ImageRectTransform.position.y + 0f, 2.2f);

			yield return null;
		}
		//LeanTween.delayedCall(1f, () => { ItemImage.DOFade(0f, 4f)};
		ItemImage.DOFade(0f, 4f);
    }
	
	
	public void UseCard()
	{
		StartCoroutine(AnimateUseCard(true));
		CurrentCard.PlayCard();
	}

    public void OnDestroy()
    {
		StartCoroutine(AnimateUseCard(false));
    }
}