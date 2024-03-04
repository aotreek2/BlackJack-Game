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

public abstract class Player //abstract class that the human player and the house inherits from
{
    public GenericHand PlayerHand { get; private set; } //gets and sets the list of cards from the generic hand script.

    protected Player() //protected constructor so that the derived classes can access.
    {
        PlayerHand = new GenericHand(); //sets the player hand to the generic hand instance
    }

    public abstract bool Hit(Deck deck); // Returns true if player hits, false if stands
    public abstract void PlayTurn(Deck deck); // Method that allows the house to draw a card
}
