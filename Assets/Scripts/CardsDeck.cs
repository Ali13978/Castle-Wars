using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsDeck : MonoBehaviour
{
    [SerializeField] public List<Card> cards;
    
    private void Start()
    {
        ShuffleDeck();
    }

    public Card GiveCard()
    {
        Card card = cards[0];
        cards.Remove(cards[0]);
        return card;
    }

    private void ShuffleDeck()
    {
        int Lastindex = cards.Count - 1;

        while(Lastindex > 0)
        {
            Card TempValue = cards[Lastindex];
            int randomIndex = new System.Random().Next(0, Lastindex);
            cards[Lastindex] = cards[randomIndex];
            cards[randomIndex] = TempValue;

            Lastindex--;
        }
    }
}
