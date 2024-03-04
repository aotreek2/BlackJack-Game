using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanPlayer : Player
{
    public override bool Hit(Deck deck)
    {
        return true;
    }

    public override void PlayTurn(Deck deck)
    {
        if (Hit(deck))
        {
            PlayerHand.AddCard(deck.DealCard());
        }
    }
}

