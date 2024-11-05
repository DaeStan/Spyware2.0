using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public int id;
    public int cardindex;

    bool activePlayer = false;
    bool canWin = false;

    int cardPlayed;

    int currentWinningCard;

    int[] currentPlayerHand;

    void CheckForWinningCard()
    {

        if (CardManager.instance.winningcard == cardPlayed)
        {
            canWin = true;
        }
    }

    public void PlayerTurn()
    {
        currentPlayerHand = CardManager.instance.currentPlayerHansds[id];
        currentWinningCard = CardManager.instance.winningcard;

        if (id == 1 && canWin == false)
        {
            Debug.Log("this is the first turn player 1 may start...");
            activePlayer = true;
        }

        for (int i = 0; i < currentPlayerHand.Length; i++)
        {
            if (currentPlayerHand[i] == currentWinningCard && canWin == true)
            {
                Debug.Log("Player " + id + " has WON!!!!!!!!!!!!!!!!!!!!!!");
            }
        }
        if (activePlayer == true)
        {
            string selectedCard = EventSystem.current.currentSelectedGameObject.name;
            Debug.Log(id + ": " + selectedCard);
            if (currentWinningCard == -1)
            {
                currentWinningCard = (int)Char.GetNumericValue(selectedCard[0]);
                Debug.Log("Player " + id + " choose: " + currentWinningCard);
            }
            else
            {
                Debug.Log("in else");
                //pass card to next player
                cardPlayed = (int)Char.GetNumericValue(selectedCard[0]);
                CheckForWinningCard();
                Debug.Log("PlayerTurn Id: " + id);
                int nextPlayer = CardManager.instance.PassCard(id, cardPlayed);

                activePlayer = false;
                id = nextPlayer;
            }
        }
    }

    public void ComPlayers()
    {
        //will add code for ai (players 2-4) later
        if (id == 2 || id == 3 || id == 4)
        {
            cardindex = UnityEngine.Random.Range(0, 9);
            //add a way for the ai to pick the winning card
            CardManager.instance.ComTurn(id, cardindex);
        }
    }
}
