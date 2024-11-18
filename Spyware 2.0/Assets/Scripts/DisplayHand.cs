using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class DisplayHand : MonoBehaviour
{
    int cardNumber;
    string cardPrefabName;
    GameObject playerCanvas;
    GameObject cardDeck;
    //GameObject comButton2;
    //GameObject comButton3;
    //GameObject comButton4;

    //GameObject dealCardsButton;
    //GameObject clearCardskButton;

    public TextMeshProUGUI IdCounter;
    int currentPlayerIdCounnter =  0;

    public static DisplayHand instance;
    void Awake()
    {
        instance = this;
    }
    public void DisplayPLayerHand(int[] playerHand, Dictionary<string, int> deck)
    {
        playerCanvas = GameObject.Find("PlayerScreen");
        cardDeck = GameObject.Find("Deck");
       // comButton2 = GameObject.Find("COMButton2");
        //comButton3 = GameObject.Find("COMButton3");
        //comButton4 = GameObject.Find("COMButton4");

        //clearCardskButton = GameObject.Find("ClearCardsButton");
       // dealCardsButton = GameObject.Find("DealCardsButton");


        //Checking to make sure there is the correct number of cards in the playerHand
        //if (playerHand.Length > 3) 
        //{
            //Debug.Log("*********************Too many cards in playerHand*******************************");
        //}

        //clearing cards 
        for (int i = 0; i < 3; i++)
        {
            foreach (Transform child in playerCanvas.transform)
            {
                //Debug.Log("----------------------------------number of children of canvas: " + playerCanvas.transform.childCount);
                //Debug.Log("----------------------------------child of canvas: " + child.name);
                if (child.name.Contains("card"))
                {
                    child.transform.SetParent(cardDeck.transform, true);
                }
            }
        }

        for (int i = 0; i < playerHand.Length; i++)
        {
            cardNumber = playerHand[i];

            //Debug.Log("inDisplayFunction: " + cardNumber);
            foreach (KeyValuePair<string, int> kvp in deck)
            {
                if (kvp.Value == cardNumber)
                {
                    cardPrefabName = kvp.Key;
                    GameObject cardPrefab = GameObject.Find(cardPrefabName);
                    cardPrefab.transform.SetParent(playerCanvas.transform, true);
                }
            }
        }

        if (currentPlayerIdCounnter == 4)
        {
            currentPlayerIdCounnter = 1;
        }
        else
        {
            currentPlayerIdCounnter++;
        }
        IdCounter.text = currentPlayerIdCounnter.ToString();
    }

    public void ClearCards()
    {
        //int deckCount = cardDeck.transform.childCount;

        for (int i = 0; i < 3; i++)
        {
            foreach (Transform child in playerCanvas.transform)
            {
                Debug.Log("----------------------------------number of children of canvas: " + playerCanvas.transform.childCount);
                Debug.Log("----------------------------------child of canvas: " + child.name);
                if (child.name.Contains("card"))
                {
                    child.transform.SetParent(cardDeck.transform, true);
                }
            }
        }

        //comButton2.transform.SetParent(playerCanvas.transform, true);
        //comButton3.transform.SetParent(playerCanvas.transform, true);
        //comButton4.transform.SetParent(playerCanvas.transform, true);
        //IdCounter.transform.SetParent(playerCanvas.transform, true);
        //dealCardsButton.transform.SetParent(playerCanvas.transform, true);
        //clearCardskButton.transform.SetParent(playerCanvas.transform, true);
    }

    public void RedealCards(int[] playerHand, Dictionary<string, int> deck)
    {

        for (int i = 0; i < playerHand.Length; i++)
        {
            cardNumber = playerHand[i];

            Debug.Log("inDisplayFunction: " + cardNumber);
            foreach (KeyValuePair<string, int> kvp in deck)
            {
                if (kvp.Value == cardNumber)
                {
                    cardPrefabName = kvp.Key;
                    GameObject cardPrefab = GameObject.Find(cardPrefabName);
                    cardPrefab.transform.SetParent(playerCanvas.transform, true);
                }
            }
        }
    }
}