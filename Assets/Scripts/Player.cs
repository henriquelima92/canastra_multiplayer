using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int UserId;
    public List<CardBuilder> InHandDeck;
    public List<CardBuilder> SelectedDeck;

    private void Start()
    {
        InHandDeck = new List<CardBuilder>();
        SelectedDeck = new List<CardBuilder>();
    }

    public void AddCardToHand()
    {
        CardBuilder card = Deck.Instance.CurrentCard;
    }

    public void PutCardInTable() { }
}
