using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class MutatorList : MonoBehaviour
{
	public static MutatorList Instance;
	public GameObject MutatorPrefab;
	public Transform MutatorContainer;
	public List<Mutator> Mutators = new List<Mutator>();
	private void Awake() {
		if(Instance == null){
			Instance = this;
		}else{
			Destroy(this);
		}
	}
	
	public void Add(CardDataSO cardData)
	{
		var GO = Instantiate(MutatorPrefab, MutatorContainer);
		Mutator mutator = GO.GetComponent<Mutator>();
		
		mutator.Build(cardData);
		Mutators.Add(mutator);
	}
	
	public void Remove(Mutator mutator)
	{
		Mutators.Remove(mutator);
		Destroy(mutator.gameObject);
	}
	
	public bool ContainsSkipTurnMutator(out Mutator mutator)
	{
		mutator = null;
		foreach(Mutator m in Mutators)
		{
			if(m.CardData.CardAbilities.Any(x=>x.SkipTurn))
			{
				mutator = m;
				return true;
			}
		}
		return false;
	}
	
	/// <summary>
	/// Removes first card with matching cardData.
	/// </summary>
	/// <param name="cardData"></param>
	public void Remove(CardDataSO cardData)
	{
		foreach(Mutator mutator in Mutators)
		{
			if(mutator.CardData == cardData)
			{
				GameObject go = mutator.gameObject;
				Remove(mutator);
				Destroy(go);
				return;
			}
		}
	}
	
	public void RemoveAtEndOfRound()
	{
		for(int i = Mutators.Count-1; i >= 0; i--)
		{
			if(Mutators[i].CardData.ActiveTillEndOfRound)
			{
				GameObject go = Mutators[i].gameObject;
				Mutators.RemoveAt(i);
				Destroy(go);
			}
		}
	}
}
