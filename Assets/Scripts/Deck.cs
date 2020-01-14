using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Deck : MonoBehaviour
{
    public static Deck Instance;
    public List<Card> Cards;
    public List<Sprite> Suits;
    public GameObject CardReference;
    public Transform DeckHolder;

    public List<Transform> PlayersCardHolder;
    public CardHolder CurrentStackCard;

    private void Awake()
    {
        Instance = this;

        InitializeFullDeck();
        ShuffleDeck();

        InitializeUserDeck();

        SetCardFromStack();
    }

    public CardHolder SetCardFromStack()
    {
        Card c = Cards.Last();
        GameObject card = GameObject.Instantiate(CardReference, DeckHolder);
        CardHolder cardHolder = card.GetComponent<CardHolder>();

        string cardValue = "";
        switch (c.CurrentCardValue)
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
                cardValue = ((int)c.CurrentCardValue + 1).ToString();
                break;
        }
        cardHolder.BuildCard(cardValue, Suits[(int)c.CurrentSuit], c);
        this.Cards.Remove(c);

        CurrentStackCard = cardHolder;
        return cardHolder;
    }

    private void InitializeFullDeck()
    {
        Cards = new List<Card>();

        CardsGenerator(Suit.Diamond);
        CardsGenerator(Suit.Club);
        CardsGenerator(Suit.Heart);
        CardsGenerator(Suit.Spade);

        JokerGenerator();
    }

    private void ShuffleDeck()
    {
        System.Random r = new System.Random();
        Cards = Cards.Select(x => new { value = x, order = r.Next() })
            .OrderBy(x => x.order).Select(x => x.value).ToList();
    }

    private void InitializeUserDeck()
    {
        for (int i = 0; i < PlayersCardHolder.Count; i++)
        {
            UserDeckCreator(Cards.Take(11).ToList(), PlayersCardHolder[i]);
        }
    }


    private void UserDeckCreator(List<Card> Cards, Transform Holder)
    {
        for(int i=0; i< Cards.Count; i++)
        {
            GameObject card = GameObject.Instantiate(CardReference, Holder);
            CardHolder cardHolder = card.GetComponent<CardHolder>();

            string cardValue = "";
            switch (Cards[i].CurrentCardValue)
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
                    cardValue = ((int)Cards[i].CurrentCardValue + 1).ToString();
                    break;
            }
            cardHolder.BuildCard(cardValue, Suits[(int)Cards[i].CurrentSuit], Cards[i]);
            this.Cards.RemoveAt(i);
        }
    }

    private void JokerGenerator()
    {
        for (int i = 0; i < 2; i++)
        {
            Card card = new Card(Suit.Joker, new List<CardValue>() { CardValue.Any }, new List<CardValue>() { CardValue.Any }, CardValue.Joker);
            Cards.Add(card);
        }
    }

    private void CardsGenerator(Suit suit)
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
