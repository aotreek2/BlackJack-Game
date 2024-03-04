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
using System.Linq;

public class GenericHand
{
    private List<Cards> cards; //grabs the list of cards from the Cards script

    public GenericHand() //generic hand constructor
    {
        cards = new List<Cards>();
    }

    public void AddCard(Cards card)
    {
        cards.Add(card); //adds card to the card list
    }

    public int GetTotalValue() //method that gets the values of the card
    {
        int totalValue = 0;
        int aceCount = 0;

        foreach (var card in cards)
        {
            totalValue += card.GetValue(); //adds the total value from the  hand
            if (card.CardRank == Cards.Rank.Ace)
            {
                aceCount++; //Checks if theres an ace in the hand
            }
        }

        while (totalValue > 21 && aceCount > 0)
        {
            totalValue -= 10; // Makes the ace value change from 11 to 1 based on players score
            aceCount--;
        }

        return totalValue;
    }

    public bool CheckIfBust()
    {
        return GetTotalValue() > 21; //checks if the hand is busted
    }

    public override string ToString()
    {
        return string.Join(", ", cards.Select(card => card.ToString())); //displays the hand to a string
    }
}
