using System.Collections.Generic;
using UnityEngine;

public class Generator
{
    public List<Card> Cards { get => cards; }
    private List<Card> cards;

    public List<Transform> UserCardHolder { get => userCardHolder; }
    private List<Transform> userCardHolder;

    public List<Sprite> Suits { get => suits; }
    private List<Sprite> suits;

    public GameObject CardReference { get => cardReference; }
    private GameObject cardReference;

    public Generator(List<Card> cards, List<Transform> cardHolder, List<Sprite> suits, GameObject cardReference)
    {
        this.cards = cards;
        this.userCardHolder = cardHolder;
        this.suits = suits;
        this.cardReference = cardReference;

        CardsGenerator(Suit.Diamond);
        CardsGenerator(Suit.Club);
        CardsGenerator(Suit.Heart);
        CardsGenerator(Suit.Spade);

        JokerGenerator();
    }

    private void CardsGenerator(Suit suit)
    {
        for (int i = 0; i < 13; i++)
        {
            List<CardValue> previousCard = new List<CardValue>();
            List<CardValue> nextCard = new List<CardValue>();

            switch (i)
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
            cards.Add(card);
        }
    }

    private void JokerGenerator()
    {
        for (int i = 0; i < 2; i++)
        {
            Card card = new Card(Suit.Joker, new List<CardValue>() { CardValue.Any }, new List<CardValue>() { CardValue.Any }, CardValue.Joker);
            cards.Add(card);
        }
    }

    public void DeckGenerator(List<Card> selectedCards, Transform holder)
    {
        for (int i = 0; i < selectedCards.Count; i++)
        {
            GameObject card = GameObject.Instantiate(cardReference, holder);
            CardHolder cardHolder = card.GetComponent<CardHolder>();

            string cardValue = "";
            switch (selectedCards[i].CurrentCardValue)
            {
                case CardValue.Ace:
                    cardValue = "A";
                    break;
                case CardValue.Jack:
                    cardValue = "J";
                    break;
                case CardValue.Queen:
                    cardValue = "Q";
                    break;
                case CardValue.King:
                    cardValue = "K";
                    break;
                case CardValue.Joker:
                    cardValue = "Joker";
                    break;
                default:
                    cardValue = ((int)selectedCards[i].CurrentCardValue + 1).ToString();
                    break;
            }
            cardHolder.BuildCard(cardValue, suits[(int)selectedCards[i].CurrentSuit], selectedCards[i]);
            cards.RemoveAt(i);
        }
    }
}

