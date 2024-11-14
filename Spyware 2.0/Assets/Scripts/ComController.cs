using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComController : MonoBehaviour
{
    PlayerController playerController;

    public int id;
    public int cardindex;

    bool comCanWin = false;
    int comCardPlayed;
    int[] currentComHand;

    int passCard;

    public int winningCard = -1;

    public void PickCard()
    {
        if (id == 2 || id == 3 || id == 4)
        {
            Debug.Log("pickCard function...");
            cardindex = UnityEngine.Random.Range(0, 2);

            currentComHand = CardManager.instance.currentPlayerHands[id];
            passCard = currentComHand[cardindex];
        }
    }

    //ai to pick the winning card
    public void PickWinningCard()
    {
        cardindex = UnityEngine.Random.Range(0, 1);
        currentComHand = CardManager.instance.currentPlayerHands[id];

        winningCard = currentComHand[cardindex];
        Debug.Log("Com: " + id + "Chose winning card to: " + winningCard);
    }

    public void ComTurn()
    {
        Debug.Log("in ComTurn...");
        if (winningCard == -1)
        {
            PickWinningCard();
        }

        PickCard();

        Debug.Log("Random picked card number: " + cardindex);

        playerController = FindAnyObjectByType<PlayerController>();
        playerController.PlayerTurn(id, winningCard, comCanWin, passCard);
    }
 }
