using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentDB : MonoBehaviour
{
    [HideInInspector]
    public List<Opponent> AvailableOpponents = new List<Opponent>();

    [SerializeField]
    private OpponentDatabase CurrentOpponent;

    // Generate opponents based on the opponent data in CurrentOpponent, adding them to AvailableOpponents.
    private void GenerateOpponents()
    {
        foreach(OpponentDataSO opponentData in CurrentOpponent.Opponents)
        {
            Opponent newOpponent = new Opponent(opponentData);
            AvailableOpponents.Add(newOpponent);
        }
    }

    // Awake function is responsible for initializing the object when it is created.
    public void Awake()
    {
        GenerateOpponents();
    }

    public Opponent GetRandomOpponent() => AvailableOpponents[Random.Range(0, AvailableOpponents.Count)].Clone();
}
