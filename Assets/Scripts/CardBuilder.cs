using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardBuilder : MonoBehaviour
{
    public Text TopText, BottomText;
    public Image TopSuit, BottomSuit, MiddleSuit;

    public void BuildCard(string cardValue, Sprite suitSprite)
    {
        TopText.text = cardValue;
        BottomText.text = cardValue;

        TopSuit.sprite = suitSprite;
        BottomSuit.sprite = suitSprite;
        MiddleSuit.sprite = suitSprite;
    }
}
