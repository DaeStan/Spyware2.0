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
        if (id == 2 || id == 4)
        {
            cardindex = UnityEngine.Random.Range(0, 2);

            currentComHand = CardManager.instance.currentPlayerHands[id];
            passCard = currentComHand[cardindex];
        }
        if (id == 3)
        {
            cardindex = UnityEngine.Random.Range(1, 2);

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
    }

    public void ComTurn()
    {
        if (winningCard == -1)
        {
            PickWinningCard();
        }

        PickCard();

        playerController = FindAnyObjectByType<PlayerController>();
        playerController.PlayerTurn(id, winningCard, comCanWin, passCard);
    }

 }
