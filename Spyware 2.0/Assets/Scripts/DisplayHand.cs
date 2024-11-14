using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayHand : MonoBehaviour
{
    int cardNumber;
    string cardPrefabName;
    GameObject playerCanvas;
    GameObject cardDeck;
    GameObject comButton2;
    GameObject comButton3;
    GameObject comButton4;

    public static DisplayHand instance;
    void Awake()
    {
        instance = this;
    }
    public void DisplayPLayerHand(int[] playerHand, Dictionary<string, int> deck)
    {
        playerCanvas = GameObject.Find("PlayerScreen");
        cardDeck = GameObject.Find("Deck");
        comButton2 = GameObject.Find("COMButton2");
        comButton3 = GameObject.Find("COMButton3");
        comButton4 = GameObject.Find("COMButton4");

        //clearing cards 
        foreach (Transform child in playerCanvas.transform)
        {
            //Debug.Log("child of canvas:" + child.name);
            child.transform.SetParent(cardDeck.transform, true);
        }

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
        comButton2.transform.SetParent(playerCanvas.transform, true);
        comButton3.transform.SetParent(playerCanvas.transform, true);
        comButton4.transform.SetParent(playerCanvas.transform, true);
    }
}