using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Team
{
    Team1,
    Team2
}

public class MatchController : MonoBehaviour
{
    //public Team Turn;
    //public List<Player> ListPlayers;

    //private void Start()
    //{
    //    Turn = (Random.Range(0, 100) < 50 ? Team.Team1 : Team.Team2);
    //    TurnSetup();
    //}

    //private void Update()
    //{
    //    if(Input.GetKeyDown(KeyCode.H))
    //    {
    //        ChangeTurn();
    //    }
    //}


    //private void TurnSetup()
    //{
    //    CardHolder cardHolder = Deck.Instance.CurrentStackCard;
    //    for (int i = 0; i < ListPlayers.Count; i++)
    //    {
    //        if (ListPlayers[i].MyTeam == Turn)
    //        {
    //            cardHolder.GetComponent<Button>().onClick.AddListener(ListPlayers[i].AddCardToHand);
    //            break;
    //        }
    //    }
    //}

    //private void ChangeTurn()
    //{
    //    Deck.Instance.SetCardFromStack();
    //    Turn = Turn == Team.Team1 ? Team.Team2 : Team.Team1;
    //    TurnSetup();
    //}
}
