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
using TMPro;

public class BlackJack : MonoBehaviour
{
    public GameObject menuPanel, instructionsPanel, winPanel;
    public TMP_Text playerHandDisplay, houseHandDisplay, playerHandValue, houseHandValue, outcomeTxt;
    private Deck deck;
    private HumanPlayer player;
    private House houseDealer;
    void Start()
    {
        instructionsPanel.SetActive(false); //sets panels to false
        winPanel.SetActive(false);
    }

    public void OnStartButtonClicked()
    {
        //when the start button is clicked

        menuPanel.SetActive(false);

        deck = new Deck(); //create instances, accesses the deck, humanplayer, and the house constructors 
        player = new HumanPlayer();
        houseDealer = new House();

        DealStartingCards(); //calls the deal starting cards method
        
    }

    private void DealStartingCards()
    {
        player.PlayerHand.AddCard(deck.DealCard()); //draws 2 random cards and gives it to the player to start off with
        player.PlayerHand.AddCard(deck.DealCard());

        houseDealer.PlayerHand.AddCard(deck.DealCard()); //draws 1 card for the house while the other card is "hidden"
        
        int playerScore = player.PlayerHand.GetTotalValue(); //sets the player score from the GetTotalValue from the human player script
        int dealerScore = houseDealer.PlayerHand.GetTotalValue(); //sets the house dealer's score from the GetTotalValue from the house script

        Debug.Log(player.PlayerHand);
        playerHandDisplay.text = "" + player.PlayerHand; //displays the players hand
        Debug.Log(houseDealer.PlayerHand);
        houseHandDisplay.text = "" + houseDealer.PlayerHand + ", Hidden"; //displays the house hand

        Debug.Log(playerScore);
        playerHandValue.text = "Value: " + playerScore; //displays the value of the player score

        Debug.Log(dealerScore);
        houseHandValue.text = "Value: " + dealerScore; //displays the value of the house score
    }


    public void OnStandButtonClicked()
    {
        if (!player.PlayerHand.CheckIfBust()) //if the player stands, check if the player isn't busted
        {
            Invoke("DealerRound", 1f); //invoke the house dealer's turn method
            Invoke("DetermineWinner", 2f); //invoke the determine winner method
        }
    }

    private void DealerRound()
    {
        houseDealer.PlayTurn(deck); //the house draws from the deck
        int dealerScore = houseDealer.PlayerHand.GetTotalValue(); //sets the house dealer's score from the GetTotalValue from the house script

        houseHandDisplay.text = "" + houseDealer.PlayerHand; //displays the house hand
        houseHandValue.text = "Value: " + dealerScore; //displays the value of the house score

        Debug.Log(houseDealer.PlayerHand);
        Debug.Log(dealerScore);

    }
    public void OnHitButtonClicked()
    {
        player.PlayerHand.AddCard(deck.DealCard()); //if the player hits, draw a card from the deck
        int playerScore = player.PlayerHand.GetTotalValue(); //sets the player score from the GetTotalValue from the human player script

        Debug.Log(player.PlayerHand);
        playerHandDisplay.text = "" + player.PlayerHand; //displays players hand
        Debug.Log(playerScore);
        playerHandValue.text = "Value: " + playerScore; //displays players score

        if (player.PlayerHand.CheckIfBust())  // Check if the player's hand is bust
        {
            DetermineWinner(); //call the determine winner method to display the players loss
        }
    }

    private void DetermineWinner()
    {
        int playerScore = player.PlayerHand.GetTotalValue(); //players score
        int dealerScore = houseDealer.PlayerHand.GetTotalValue(); //house dealers score
        StartCoroutine(ShowWinPanel()); //start the coroutine for the show win panel method

        if (playerScore > 21)
        {
            outcomeTxt.text = "Busted! Dealer wins!"; //the player busted and the house wins
            Debug.Log("Busted! Dealer wins.");
        }
        else if (dealerScore > 21 || playerScore > dealerScore && playerScore < 22)
        {
            outcomeTxt.text = "You Won!"; //if the dealer busted, or the player has a higher score than the house, the player wins
            Debug.Log("You Won!");
        }
        else if (playerScore == dealerScore)
        {
            outcomeTxt.text = "Tied!"; //if player and house hands have equal value, its a tie
            Debug.Log("Tied");
        }
        else
        {
            outcomeTxt.text = "Dealer wins!"; //the dealer wins, if they have a higher score than the player.
            Debug.Log("Dealer wins.");
        }
    }

    public void OnHelpButtonClicked()
    {
        menuPanel.SetActive(false); //hides the main menu
        instructionsPanel.SetActive(true); //displays instructions
    }
    public void OnMenuButtonClicked()
    {
        menuPanel.SetActive(true); //re activates the main menu and hides the instructions
        instructionsPanel.SetActive(false);
    }

    public void OnRestartButtonClicked()
    {
        deck = new Deck(); //creates the new instance, resets the deck, player hand, and house hand
        player = new HumanPlayer();
        houseDealer = new House();

        winPanel.SetActive(false); //hide win panel

        OnStartButtonClicked(); // recall the start button method 
    }

    public void OnQuitButtonClicked()
    {
        Application.Quit(); //quit the application
    }

    IEnumerator ShowWinPanel()
    {
        //waits for 2 seconds
        yield return new WaitForSeconds(2f);

        //displays win panel
        winPanel.SetActive(true);
    }
}
