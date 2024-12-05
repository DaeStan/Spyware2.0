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

    public GameObject winScreen;
    public GameObject loseScreen;

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
        //checks if players turn
        if (nextPlayer != currentPlayerId) { return; }
        

        string selectedCard = EventSystem.current.currentSelectedGameObject.name;
        currentPlayerHand = CardManager.instance.currentPlayerHands[1];

        //checks for first turn
        if (currentPlayerWinningCard == -1)
        {
            //checks if player
            if (currentPlayerId == 1)
            {
                winningCard = (int)Char.GetNumericValue(selectedCard[0]);

            }
            return;
        }

        //checks for winning card in hand
        for (int i = 0; i < currentPlayerHand.Length; i++)
        {
            if (currentPlayerHand[i] == currentPlayerWinningCard && currentPlayerWinCondtion == true)
            {
                Debug.Log("Player " + currentPlayerId + " has WON!!!!!!!!!!!!!!!!!!!!!!");
                //DisplayHand.instance.ClearCards();
                //add lose screen
                if (currentPlayerId != 1)
                {
                    loseScreen.SetActive(true);
                }
                //add win screen
                else
                {
                    winScreen.SetActive(true);
                }
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

        nextPlayer = CardManager.instance.PassCard(currentPlayerId, cardPlayed);
        currentPlayerId = nextPlayer;

        CheckForWinningCondition();
    }
}