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

public class HumanPlayer : Player
{
    public override bool Hit(Deck deck)
    {
        return true; //return true if the player presses hit
    }

    public override void PlayTurn(Deck deck)
    {
        if (Hit(deck))
        {
            PlayerHand.AddCard(deck.DealCard()); //adds a card to the players hand if they hit
        }
    }
}

