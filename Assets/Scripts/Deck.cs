using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public List<Card> Cards;

    private void Start()
    {
        Cards = new List<Card>();

        DeckGenerator(Suit.Diamond);
        DeckGenerator(Suit.Club);
        DeckGenerator(Suit.Heart);
        DeckGenerator(Suit.Spade);

        JokerGenerator();

        System.Random r = new System.Random();
        Cards = Cards.Select(x => new { value = x, order = r.Next() })
            .OrderBy(x => x.order).Select(x => x.value).ToList();
    }

    private void JokerGenerator()
    {
        for (int i = 0; i < 2; i++)
        {
            Card card = new Card(Suit.Joker, new List<CardValue>() { CardValue.Any }, new List<CardValue>() { CardValue.Any }, CardValue.Joker);
            Cards.Add(card);
        }
    }

    private void DeckGenerator(Suit suit)
    {
        for (int i = 0; i < 13; i++)
        {
            List<CardValue> previousCard = new List<CardValue>();
            List<CardValue> nextCard = new List<CardValue>();

            switch(i)
            {
                case 0: //ACE
                    previousCard = new List<CardValue>() { CardValue.None, CardValue.King };
                    nextCard = new List<CardValue>() { CardValue.Two };
                break;
                case 1: //TWO
                    previousCard = new List<CardValue>() { CardValue.Any };
                    nextCard = new List<CardValue>() { CardValue.Any };
                break;
                case 2: //THREE
                    previousCard = new List<CardValue>() { CardValue.Two };
                    nextCard = new List<CardValue>() { CardValue.Four };
                break;
                case 3: //FOUR
                    previousCard = new List<CardValue>() { CardValue.Three };
                    nextCard = new List<CardValue>() { CardValue.Five };
                break;
                case 4: //FIVE
                    previousCard = new List<CardValue>() { CardValue.Four };
                    nextCard = new List<CardValue>() { CardValue.Six };
                break;
                case 5: //SIX
                    previousCard = new List<CardValue>() { CardValue.Five };
                    nextCard = new List<CardValue>() { CardValue.Seven };
                break;
                case 6: //SEVEN
                    previousCard = new List<CardValue>() { CardValue.Six };
                    nextCard = new List<CardValue>() { CardValue.Eight };
                break;
                case 7: //EIGHT
                    previousCard = new List<CardValue>() { CardValue.Seven };
                    nextCard = new List<CardValue>() { CardValue.Nine };
                break;
                case 8: //NINE
                    previousCard = new List<CardValue>() { CardValue.Eight };
                    nextCard = new List<CardValue>() { CardValue.Ten };
                break;
                case 9: //TEN
                    previousCard = new List<CardValue>() { CardValue.Nine };
                    nextCard = new List<CardValue>() { CardValue.Jack };
                break;
                case 10: //JACK
                    previousCard = new List<CardValue>() { CardValue.Ten };
                    nextCard = new List<CardValue>() { CardValue.Queen };
                break;
                case 11: //QUEEN
                    previousCard = new List<CardValue>() { CardValue.Jack };
                    nextCard = new List<CardValue>() { CardValue.King };
                break;
                case 12: //KING
                    previousCard = new List<CardValue>() { CardValue.Queen };
                    nextCard = new List<CardValue>() { CardValue.Ace };
                break;
            }

            Card card = new Card(suit, previousCard, nextCard, (CardValue)i);
            Cards.Add(card);
        }
    }
}
