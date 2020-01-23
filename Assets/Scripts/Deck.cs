using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public static Deck Instance; //SINGLETON

    public List<Card> Cards; //RUNTIME CREATED CARD LIST
    public List<Sprite> Suits; // INSPECTOR SPRITE LIST
    public List<Transform> CardHolder; // INSPECTOR PLAYERS HOLDER

    public GameObject CardReference; // INSPECTOR CARD REFERENCE
    public Transform DeckHolder; // INSPECTOR STACKPILE HOLDER

    //MODULES
    private Generator generator; // CARD GENERATOR MODULE
    private DeckController deckController; 

    private void Awake()
    {
        GenerateSingleton();

        Cards = new List<Card>();
        generator = new Generator(Cards, CardHolder, Suits, CardReference);
        deckController = new DeckController(generator, DeckHolder);

        SetStackPileCard();
    }

    private void GenerateSingleton()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetStackPileCard()
    {
        deckController.SetStackPileCard();
    }
}

