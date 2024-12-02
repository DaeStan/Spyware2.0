using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public static int maxCardsForHand = 3;
    public static int maxNumberOfPlayers = 4;
    int numberOfCardsInDeck;
    int shufflingDeck;
    int[] currentPlayerHand;
    int[] nextPlayerHand;
    int nextPlayerId;
    List<int> passingCard;
    private int numberOfPlayers;

    HashSet<int> cardsDelt = new HashSet<int>();

    public static CardManager instance;

    void Awake()
    {
        instance = this;
    }

    public Dictionary<string, int> cards =
        new Dictionary<string, int>() {
        {"1card", 1 }, {"2card", 2} , {"3card", 3} , {"4card", 4} , {"5card", 5},
        {"6card", 6}, {"7card", 7}, {"8card", 8}, {"9card", 9}
        };

    public Dictionary<int, int[]> currentPlayerHands =
    new Dictionary<int, int[]>();

    //Shuffling deck and putting them into the currentPlayerHands Dictionary
    public void ShuffleDeck()
    {
        numberOfCardsInDeck = cards.Count;

        for (int j = 1; j <= maxNumberOfPlayers; j++)
        {
            int[] playerHand = new int[maxCardsForHand];

            for (int i = 0; i < maxCardsForHand - 1; i++)
            {
                do
                {
                    shufflingDeck = Random.Range(1, numberOfCardsInDeck + 1);
                } while (cardsDelt.Contains(shufflingDeck));

                playerHand[i] = shufflingDeck;
                cardsDelt.Add(shufflingDeck);
            }
            if (j == 1)
            {
                do
                {
                    shufflingDeck = Random.Range(1, numberOfCardsInDeck + 1);
                } while (cardsDelt.Contains(shufflingDeck));

                playerHand[maxCardsForHand - 1] = shufflingDeck;
                cardsDelt.Add(shufflingDeck);
                currentPlayerHands.Add(j, playerHand);
            }
            else
            {
                playerHand[maxCardsForHand - 1] = 0;
                currentPlayerHands.Add(j, playerHand);
            }
        }
    }

    //Deal Cards
    public void DealCards(int playerid)
    {
        DisplayHand.instance.DisplayPLayerHand(currentPlayerHands[playerid], cards);
    }

    //Passing Cards
    public int PassCard(int currentPlayerId, int passedCard)
    {
        numberOfPlayers = 4; //might move this outside of functions later

        //Debug.Log("passCard playerID: " + currentPlayerId);
        currentPlayerHand = currentPlayerHands[currentPlayerId];

        //finds next players id
        if (currentPlayerId + 1 == numberOfPlayers + 1)
        {
            nextPlayerHand = currentPlayerHands[1];
            nextPlayerId = 1;
        }
        else
        {
            nextPlayerHand = currentPlayerHands[currentPlayerId + 1];
            nextPlayerId = currentPlayerId + 1;
        }

        //convert array to list to remove card and replace it with 0
        passingCard = new List<int>(currentPlayerHand);
        passingCard.Remove(passedCard);
        passingCard.Add(0);
        //DisplayList(passingCard);
        currentPlayerHand = passingCard.ToArray();
        currentPlayerHands[currentPlayerId] = currentPlayerHand; //may have to update this array for the id

        //adding card to next players hand
        passingCard = new List<int>(nextPlayerHand);
        if (passingCard.Contains(0))
        {
            passingCard.Remove(0);
        }
        passingCard.Add(passedCard);
        //DisplayList(passingCard);
        nextPlayerHand = passingCard.ToArray();
        currentPlayerHands[nextPlayerId] = nextPlayerHand;
        DisplayHand.instance.DisplayPLayerHand(nextPlayerHand, cards);

        return nextPlayerId;
    }

    public void RedealCardsButton()
    {
        DisplayHand.instance.RedealCards(nextPlayerHand, cards);
    }

    //Displaying lists
    void DisplayList(List<int> passingCard)
    {
        Debug.Log("displaying List:   ");
        foreach (int card in passingCard)
        {
            Debug.Log(card);
        }
    }
}
