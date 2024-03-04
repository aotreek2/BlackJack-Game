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

public class Cards 
{
    public enum Suit { Hearts, Diamonds, Clubs, Spades } //enum of the suit names
    public enum Rank { Two = 2, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace } //enum of the rank values 

    public Suit CardSuit { get; private set; } //property that grabs and sets the card suit
    public Rank CardRank { get; private set; } //property that grabs and sets the card rank

    public Cards(Suit suit, Rank rank) //cards constructor
    {
        CardSuit = suit; //sets the card suit to the suit variable
        CardRank = rank; //sets the card rank to the rank variable
    }

    public int GetValue()
    {
        if (CardRank <= Rank.Ten)
        {
            return (int)CardRank; //if the card rank is less then 10, then it must be a numbered card and not a face or an ace.
        }
        else if (CardRank == Rank.Ace)
        {
            return 11; // returns 11 for ace cards
        }
        else
        {
            return 10; // returns 10 for face cards
        }
    }

    public override string ToString()
    {
        return CardRank + " Of " + CardSuit; //brings the suit and the value of the cards together in a string
    }
}
