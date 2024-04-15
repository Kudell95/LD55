using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardHolderManager : MonoBehaviour
{
	public GameObject CardPrefab;
	
	private int cardsInHand;
	
	// Start is called before the first frame update
	void Awake()
	{
		GameManager.OnCardsAdded += drawCards;
		GameManager.OnCardUsed += onCardUsed;
	}
	

	public void drawCards(int amount)
	{		
		StartCoroutine(Spawncards(amount));		
	}
	
	public IEnumerator Spawncards(int amount)
	{
		Debug.Log($"Spawning {amount} cards");
		//for each card, instantiate a new card and populate initiate. wait for an animation to complete after each one.
		for(int i = 0; i < amount; i++)
		{
			if(cardsInHand + 1 > ConfigManager.Instance.ConfigObject.MaxCardsInHand)
				continue;
				
			//instantiate
			var card = Instantiate(CardPrefab, transform);
			
			Card cardData = GameManager.Instance.CardDatabase.GetRandomCard();
			CardController controller = card.GetComponent<CardController>();
			controller.SetCard(cardData);
			cardsInHand++;		
			yield return new WaitForSeconds(.5f);
		}
		
		
		GameManager.OnCardAddComplete?.Invoke();
	}
	
	
	public void ClearCards()
	{
		cardsInHand = 0;
		int childCount = transform.childCount;
		for(int i = 0; i < childCount; i++)
		{
			Destroy(transform.GetChild(i).gameObject);
		}
	}
	
	public void onCardUsed()
	{
		cardsInHand--;
	}
	
	private void OnDestroy() {
		GameManager.OnCardsAdded -= drawCards;
		GameManager.OnCardUsed -= onCardUsed;
	}
}
