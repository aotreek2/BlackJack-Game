//////////////////////////////////////////////
//Assignment/Lab/Project: Blackjack_Treek
//Name: Ahmed Treek
//Section: SGD.213.0021
//Instructor: Aurore Locklear
//Date: 2/22/2024
/////////////////////////////////////////////


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : Player
{
    public override bool Hit(Deck deck)
    {
        // if the value is less than or equal to 15, the house will hit again, afterwards it will stand.
        return PlayerHand.GetTotalValue() <= 15;
    }

    public override void PlayTurn(Deck deck)
    {
        while (Hit(deck))
        {
            PlayerHand.AddCard(deck.DealCard()); //the house draws a card
        }
    }
}
