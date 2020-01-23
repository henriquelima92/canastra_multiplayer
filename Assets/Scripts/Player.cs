using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Possession
{
    None,
    Player1,
    Player2,
    Table
}

public class Player : MonoBehaviour
{
    public Team MyTeam;
    public Possession MyPossession;
    public int UserId;
    public List<CardHolder> InHandDeck;
    public List<CardHolder> SelectedDeck;

    [SerializeField]
    private Transform handHolder;

    private void Start()
    {
        InHandDeck = new List<CardHolder>();
        SelectedDeck = new List<CardHolder>();
    }

    public void AddCardToHand()
    {
        CardHolder cardHolder = new CardHolder();//Deck.Instance.CurrentStackCard; FIX THIS
        cardHolder.Possession = MyPossession;
        SetMineCard(cardHolder);

        InHandDeck.Add(cardHolder);
        cardHolder.GetComponent<Button>().onClick.RemoveAllListeners();
        cardHolder.GetComponent<Button>().onClick.AddListener(delegate { SetSelected(cardHolder.gameObject); });
    }

    public void PutCardInTable(CardHolder cardHolder)
    {
        cardHolder.Possession = Possession.Table;
    }

    public void SetSelected(GameObject gameobject)
    {
        gameobject.GetComponent<Image>().color = new Color(0.75f, 0.75f, 0.75f, 1);
    }

    private void SetMineCard(CardHolder cardHolder)
    {
        cardHolder.transform.SetParent(handHolder);
        cardHolder.transform.position = Vector3.zero;
    }
}
