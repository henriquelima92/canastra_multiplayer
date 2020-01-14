using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardHolder : MonoBehaviour
{
    public Card Card;

    public Text TopText, BottomText;
    public Image TopSuit, BottomSuit, MiddleSuit;

    public bool Selected = false;
    public Possession Possession = Possession.None;

    public void BuildCard(string cardValue, Sprite suitSprite, Card card)
    {
        TopText.text = cardValue;
        BottomText.text = cardValue;

        TopSuit.sprite = suitSprite;
        BottomSuit.sprite = suitSprite;
        MiddleSuit.sprite = suitSprite;

        Card = card;
    }
}
