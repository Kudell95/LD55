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
	public Image CardFrameImage;
    public Image ItemImage;
    private Vector3 _startPos;
	private Vector3 _startScale;
	public RectTransform ImageRectTransform;
	
	
	public void Start()
	{
		GetRandomCard();

		//for animation
		_startPos = ImageRectTransform.anchoredPosition;
		_startScale = transform.localScale;
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
		//fade text
		TextCanvasGroup.DOFade(0f, 1f);

		float moveTime = 1f;
		float elapsedTime = 0f;
		float dissolveAmount = 0f;

		while (elapsedTime < moveTime)
		{
			elapsedTime += Time.deltaTime;
			dissolveAmount += Time.deltaTime;

			CardFrameImage.material.SetFloat("_DissolveAmount", dissolveAmount);
			ImageRectTransform.DOLocalMoveY(ImageRectTransform.position.y + 0.7f, 2.2f);

			yield return null;
		}

		ItemImage.DOFade(0f, 2f);
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