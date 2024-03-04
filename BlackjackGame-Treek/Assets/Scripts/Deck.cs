//////////////////////////////////////////////
//Assignment/Lab/Project: Blackjack_Treek
//Name: Ahmed Treek
//Section: SGD.213.0021
//Instructor: Aurore Locklear
//Date: 2/22/2024
/////////////////////////////////////////////


using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Deck
{
    private List<Cards> cards; //grabs the list of cards from the card script

    public Deck() //deck constructor
    {
        cards = new List<Cards>();
        AddCardsToDeck(); //adds cards to the deck
    }

    private void AddCardsToDeck()
    {
        foreach (Cards.Suit suit in Enum.GetValues(typeof(Cards.Suit)))
        {
            foreach (Cards.Rank rank in Enum.GetValues(typeof(Cards.Rank)))
            {
                cards.Add(new Cards(suit, rank)); //for each suit and rank in the enum of suit and rank, it adds the card to the cards list.
            }
        }
    }

    public Cards DealCard()
    {
        if (cards.Count > 0)
        {
            int randomNum = UnityEngine.Random.Range(0, cards.Count); //gets a random number from 0 to the cards length
            Cards randomCardToDeal = cards[randomNum]; //grabs a random card from the list 
            cards.RemoveAt(randomNum); //removes the card from the deck
            return randomCardToDeal; //return the card 
        }
        else
        {
            Debug.Log("The deck is empty");
            return null; //return nothing if the list is empty
        }
    }

}

