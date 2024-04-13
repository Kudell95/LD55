using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentDB : MonoBehaviour
{
    [HideInInspector]
    public List<Opponent> AvailableOpponents = new List<Opponent>();

    [SerializeField]
    private OpponentSO CurrentOpponent;

    private void GenerateOpponents()
    {
        foreach(OpponentDataSO opponentData in CurrentOpponent.Opponents)
        {
            Opponent newOpponent = new Opponent(opponentData);
            AvailableOpponents.Add(newOpponent);
        }
    }

    public void Awake()
    {
        GenerateOpponents();
    }

    public Opponent GetRandomOpponent() => AvailableOpponents[Random.Range(0, AvailableOpponents.Count)].Clone();
}
