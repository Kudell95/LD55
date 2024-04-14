using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHolderManager : MonoBehaviour
{
	public GameObject CardPrefab;
	
	private int cardsInHand;
	
	// Start is called before the first frame update
	void Start()
	{
		GameManager.Instance.OnCardsAdded += drawCards;
	}
	
	
	

	public void drawCards(int amount)
	{		
		StartCoroutine(Spawncards(amount));		
	}
	
	public IEnumerator Spawncards(int amount)
	{
		//for each card, instantiate a new card and populate initiate. wait for an animation to complete after each one.
		for(int i = 0; i < amount; i++)
		{
			if(cardsInHand + 1 > ConfigManager.Instance.ConfigObject.MaxCardsInHand)
				continue;
				
			//instantiate
			var card = Instantiate(CardPrefab, transform);
			
			Card cardData = GameManager.Instance.CardDatabase.GetRandomCard();
			
			card.GetComponent<CardController>().SetCard(cardData);
			
			yield return new WaitForSeconds(1);
		}
		
	}
}
