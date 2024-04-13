using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opponent : MonoBehaviour, IOpponent
{
	public OpponentDataSO OpponentData;
	public string GUID;
	
	public void Attack()
	{
		throw new System.NotImplementedException();
	}

	public void Die()
	{
		throw new System.NotImplementedException();
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
	
	
	public void SpawnNewOpponent(OpponentDataSO newOpponentData)
	{
		//TODO: flesh this out a bit more with some animations etc...
		//How do we wait to continue. events???
		OpponentData = newOpponentData;
	}
}


