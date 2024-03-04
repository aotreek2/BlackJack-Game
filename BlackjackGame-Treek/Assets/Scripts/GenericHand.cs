using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GenericHand
{
    private List<Cards> cards;

    public GenericHand()
    {
        cards = new List<Cards>();
    }

    public void AddCard(Cards card)
    {
        cards.Add(card);
    }

    public int GetTotalValue()
    {
        int totalValue = 0;
        int aceCount = 0;

        foreach (var card in cards)
        {
            totalValue += card.GetValue();
            if (card.CardRank == Cards.Rank.Ace)
            {
                aceCount++;
            }
        }

        while (totalValue > 21 && aceCount > 0)
        {
            totalValue -= 10; // Makes the ace value change from 11 to 1 based on players score.
            aceCount--;
        }

        return totalValue;
    }

    public bool CheckIfBust()
    {
        return GetTotalValue() > 21;
    }

    public override string ToString()
    {
        return string.Join(", ", cards.Select(card => card.ToString()));
    }
}
