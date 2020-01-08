using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Turn
{
    Team1,
    Team2
}

public class MatchController : MonoBehaviour
{
    public static MatchController Instance;

    [SerializeField]
    private Turn turn;

    private void Awake()
    {
        Instance = this;
    }

    public void ChangeTurn()
    {
        switch(turn)
        {
            case Turn.Team1:
                turn = Turn.Team2;
            break;
            case Turn.Team2:
                turn = Turn.Team1;
            break;
        }
    }
}
