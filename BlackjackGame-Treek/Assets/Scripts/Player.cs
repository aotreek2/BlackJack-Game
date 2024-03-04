using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player
{
    public GenericHand PlayerHand { get; private set; }

    protected Player()
    {
        PlayerHand = new GenericHand();
    }

    public abstract bool Hit(Deck deck); // Returns true if player hits, false if stands
    public abstract void PlayTurn(Deck deck); // Implement the logic for the player's turn
}
