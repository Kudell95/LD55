using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mutator : MonoBehaviour
{
	[HideInInspector]
	public CardDataSO CardData;
	public Image IconImage;
	// Method that takes in
	
	public void Build(CardDataSO cardData) 
	{
		CardData = cardData;
		IconImage.sprite = cardData.Image;
	}
	
	
}
