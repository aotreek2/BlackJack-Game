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
        instructionsPanel.SetActive(false);
        winPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnStartButtonClicked()
    {
        menuPanel.SetActive(false);

        deck = new Deck();
        player = new HumanPlayer();
        houseDealer = new House();

        DealInitialCards();
        
    }

    private void DealInitialCards()
    {
        player.PlayerHand.AddCard(deck.DealCard());
        houseDealer.PlayerHand.AddCard(deck.DealCard());
        player.PlayerHand.AddCard(deck.DealCard());
        

        int playerScore = player.PlayerHand.GetTotalValue();
        int dealerScore = houseDealer.PlayerHand.GetTotalValue();

        Debug.Log(player.PlayerHand);
        playerHandDisplay.text = "" + player.PlayerHand;
        Debug.Log(houseDealer.PlayerHand);
        houseHandDisplay.text = "" + houseDealer.PlayerHand + ", Hidden";

        Debug.Log(playerScore);
        playerHandValue.text = "Value: " + playerScore;

        Debug.Log(dealerScore);
        houseHandValue.text = "Value: " + dealerScore;
    }


    public void OnStandButtonClicked()
    {
        if (!player.PlayerHand.CheckIfBust())
        {
            Invoke("DealerRound", 1f);
            Invoke("DetermineWinner", 2f);
        }
    }

    private void DealerRound()
    {
        houseDealer.PlayTurn(deck);
        int dealerScore = houseDealer.PlayerHand.GetTotalValue();

        houseHandDisplay.text = "" + houseDealer.PlayerHand;
        houseHandValue.text = "Value: " + dealerScore;

        Debug.Log(houseDealer.PlayerHand);
        Debug.Log(dealerScore);

    }
    public void OnHitButtonClicked()
    {
        player.PlayerHand.AddCard(deck.DealCard());
        int playerScore = player.PlayerHand.GetTotalValue();

        Debug.Log(player.PlayerHand);
        playerHandDisplay.text = "" + player.PlayerHand;
        Debug.Log(playerScore);
        playerHandValue.text = "Value: " + playerScore;

        // Check if the player's hand is bust
        if (player.PlayerHand.CheckIfBust())
        {
            DetermineWinner();
        }
    }

    private void DetermineWinner()
    {
        int playerScore = player.PlayerHand.GetTotalValue();
        int dealerScore = houseDealer.PlayerHand.GetTotalValue();
        StartCoroutine(ShowWinPanel());

        if (playerScore > 21)
        {
            outcomeTxt.text = "Busted! Dealer wins!";
            Debug.Log("Busted! Dealer wins.");
        }
        else if (dealerScore > 21 || playerScore > dealerScore && playerScore < 22)
        {
            outcomeTxt.text = "You Won!";
            Debug.Log("You Won!");
        }
        else if (playerScore == dealerScore)
        {
            outcomeTxt.text = "Tied!";
            Debug.Log("Tied");
        }
        else
        {
            outcomeTxt.text = "Dealer wins!";
            Debug.Log("Dealer wins.");
        }
    }

    public void OnHelpButtonClicked()
    {
        menuPanel.SetActive(false);
        instructionsPanel.SetActive(true);
    }
    public void OnMenuButtonClicked()
    {
        menuPanel.SetActive(true);
        instructionsPanel.SetActive(false);
    }

    public void OnRestartButtonClicked()
    {
        deck = new Deck();
        player = new HumanPlayer();
        houseDealer = new House();

        winPanel.SetActive(false);

        OnStartButtonClicked();
    }

    public void OnQuitButtonClicked()
    {
        Application.Quit();
    }

    IEnumerator ShowWinPanel()
    {
        // Wait for 2 seconds
        yield return new WaitForSeconds(2f);

        // Activates the win panel 
        winPanel.SetActive(true);
    }
}
