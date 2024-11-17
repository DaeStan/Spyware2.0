using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class PlayerController : MonoBehaviour
{
    public int id;

    bool canWin = false;

    int cardPlayed;

    int[] currentPlayerHand;

    int winningCard = -1;

    int nextPlayer = 1;

    int comCard = 0;

    void CheckForWinningCondition()
    {

        if (winningCard == cardPlayed)
        {
            canWin = true;
        }
    }

    public void ClickedCard()
    {
        PlayerTurn(id, winningCard, canWin, comCard);
    }

    public void PlayerTurn(int currentPlayerId, int currentPlayerWinningCard, bool currentPlayerWinCondtion, int comPassCard)
    {
        Debug.Log("-----------------------------------------------Current Player Id: " + currentPlayerId);
        Debug.Log("-----------------------------------------------Next Player Id: " + nextPlayer);

        //checks if players turn
        if (nextPlayer != currentPlayerId) { return; }
        

        string selectedCard = EventSystem.current.currentSelectedGameObject.name;
        currentPlayerHand = CardManager.instance.currentPlayerHands[1];

        //Debug.Log("Click Worked");
        //Debug.Log("Current Player ID: " + currentPlayerId);
        Debug.Log(currentPlayerId + ": " + selectedCard);


        //checks for first turn
        if (currentPlayerWinningCard == -1)
        {
            //checks if player
            if (currentPlayerId == 1)
            {
                winningCard = (int)Char.GetNumericValue(selectedCard[0]);

            }

            Debug.Log("this is the first turn player 1 may start...");
            Debug.Log("Player " + currentPlayerId + " choose as winning card: " + winningCard);
            return;
        }

        //checks for winning card in hand
        for (int i = 0; i < currentPlayerHand.Length; i++)
        {
            if (currentPlayerHand[i] == currentPlayerWinningCard && currentPlayerWinCondtion == true)
            {
                Debug.Log("Player " + currentPlayerId + " has WON!!!!!!!!!!!!!!!!!!!!!!");
            }
        }

        //passes card to next player
        //checks if player
        if (currentPlayerId == 1)
        {
            cardPlayed = (int)Char.GetNumericValue(selectedCard[0]);
        }
        else
        {
            cardPlayed = comPassCard;
        }

        Debug.Log("PlayerTurn Id: " + currentPlayerId);
        nextPlayer = CardManager.instance.PassCard(currentPlayerId, cardPlayed);
        currentPlayerId = nextPlayer;
        Debug.Log("Next Player id: " + currentPlayerId);


        CheckForWinningCondition();
    }
}