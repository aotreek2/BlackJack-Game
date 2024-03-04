using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Deck
{
    private List<Cards> cards;

    public Deck()
    {
        cards = new List<Cards>();
        AddCardsToDeck();
    }

    private void AddCardsToDeck()
    {
        foreach (Cards.Suit suit in Enum.GetValues(typeof(Cards.Suit)))
        {
            foreach (Cards.Rank rank in Enum.GetValues(typeof(Cards.Rank)))
            {
                cards.Add(new Cards(suit, rank));
            }
        }
    }

    public Cards DealCard()
    {
        if (cards.Count > 0)
        {
            int randomIndex = UnityEngine.Random.Range(0, cards.Count);
            Cards randomCardToDeal = cards[randomIndex];
            cards.RemoveAt(randomIndex); 
            return randomCardToDeal;
        }
        else
        {
            Debug.Log("The deck is empty");
            return null;
        }
    }

}

