using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class OpponentDB : MonoBehaviour
{
	[SerializeField]
	private OpponentDatabase AvailableOpponents;

	// Generate opponents based on the opponent data in CurrentOpponent, adding them to AvailableOpponents.
	//COMMENTED OUT: this is likely not needed for opponents.
	// private void GenerateOpponents()
	// {
	// 	// foreach(OpponentDataSO opponentData in CurrentOpponent.Opponents)
	// 	// {
	// 	//     Opponent newOpponent = new Opponent(opponentData);
	// 	//     AvailableOpponents.Add(newOpponent);
	// 	// }
	// }
	
	


	public OpponentDataSO GetRandomOpponent() => AvailableOpponents.Opponents[Random.Range(0, AvailableOpponents.Opponents.Count)];
	
	public OpponentDataSO GetRandomOpponent(Enums.OpponentDifficulty difficulty)
	{
		if(AvailableOpponents == null   || AvailableOpponents.Opponents == null || AvailableOpponents.Opponents.Count == 0)
			return null;
		
		List<OpponentDataSO> opponents = AvailableOpponents.Opponents.Where(x=> x.OpponentDifficulty == difficulty)?.ToList();
		
		if(opponents == null || opponents.Count == 0)
			return null;
		
		return opponents[Random.Range(0, opponents.Count)];
	}
	
	public OpponentDataSO GetRandomOpponent(Enums.OpponentDifficulty difficulty, bool boss)
	{
		if(AvailableOpponents == null   || AvailableOpponents.Opponents == null || AvailableOpponents.Opponents.Count == 0)
			return null;
		
		List<OpponentDataSO> opponents = AvailableOpponents.Opponents.Where(x=> x.OpponentDifficulty == difficulty && x.Boss == boss)?.ToList();
		
		if(opponents == null || opponents.Count == 0)
			return null;
		
		return opponents[Random.Range(0, opponents.Count)];
	}
	
}
