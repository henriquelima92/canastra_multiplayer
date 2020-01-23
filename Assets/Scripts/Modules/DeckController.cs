using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DeckController
{
    private List<Card> cards;
    private List<Sprite> suits;
    private List<Transform> userCardHolder;
    private GameObject cardReference;
    private Transform stackPileHolder;

    public CardHolder CurrentStackPileCard { get => currentStackPileCard; }
    private CardHolder currentStackPileCard;

    private Generator generator;

    public DeckController(Generator generator, Transform stackPileHolder)
    {
        this.generator = generator;
        this.cards = generator.Cards;
        this.suits = generator.Suits;
        this.userCardHolder = generator.UserCardHolder;
        this.cardReference = generator.CardReference;
        this.stackPileHolder = stackPileHolder;

        Shuffle();
        InitializeDecks();
        SetStackPileCard();
    }

    private void InitializeDecks()
    {
        for (int i = 0; i < userCardHolder.Count; i++)
        {
            generator.DeckGenerator(cards.Take(11).ToList(), userCardHolder[i]);
        }
        
    }

    private void Shuffle()
    {
        System.Random r = new System.Random();
        cards = cards.Select(x => new { value = x, order = r.Next() })
        .OrderBy(x => x.order).Select(x => x.value).ToList();
    }

    public CardHolder SetStackPileCard()
    {

        Card c = cards.Last();
        GameObject card = GameObject.Instantiate(cardReference, stackPileHolder);
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
        cardHolder.BuildCard(cardValue, suits[(int)c.CurrentSuit], c);
        cards.Remove(c);

        currentStackPileCard = cardHolder;
        return cardHolder;
    }
}

