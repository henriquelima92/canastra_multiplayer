using System.Collections.Generic;

public enum Suit
{
    Diamond,
    Club,
    Heart,
    Spade,
    Joker
}

public enum CardValue
{
    Ace,
    Two,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
    Nine,
    Ten, 
    Jack,
    Queen,
    King,
    Joker,
    None,
    Any
}

[System.Serializable]
public class Card
{
    public Suit CurrentSuit;

    public List<CardValue> PreviousCard;
    public List<CardValue> NextCard;

    public CardValue CurrentCardValue;

    public Card(Suit CurrentSuit, List<CardValue> PreviousCard, List<CardValue> NextCard, CardValue CurrentCardValue)
    {
        this.CurrentSuit = CurrentSuit;
        this.PreviousCard = PreviousCard;
        this.NextCard = NextCard;
        this.CurrentCardValue = CurrentCardValue;
    }
}
