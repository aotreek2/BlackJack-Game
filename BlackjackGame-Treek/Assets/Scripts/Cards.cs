using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cards 
{
    public enum Suit { Hearts, Diamonds, Clubs, Spades }
    public enum Rank { Two = 2, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace }

    public Suit CardSuit { get; private set; }
    public Rank CardRank { get; private set; }

    public Cards(Suit suit, Rank rank)
    {
        CardSuit = suit;
        CardRank = rank;
    }

    public int GetValue()
    {
        if (CardRank <= Rank.Ten)
        {
            return (int)CardRank;
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
        return CardRank + " Of " + CardSuit;
    }
}
