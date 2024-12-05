using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class DisplayHand : MonoBehaviour
{
    int cardNumber;
    string cardPrefabName;
    GameObject playerCanvas;
    GameObject cardDeck;

    int currentPlayerIdCounnter =  0;

    public Image com1Image;
    public Sprite com1GlitchSprite;
    public Sprite com1BaseSprite;

    public Image com2Image;
    public Sprite com2GlitchSprite;
    public Sprite com2BaseSprite;

    public Image com3Image;
    public Sprite com3GlitchSprite;
    public Sprite com3BaseSprite;

    public static DisplayHand instance;
    void Awake()
    {
        instance = this;
    }
    public void DisplayPLayerHand(int[] playerHand, Dictionary<string, int> deck)
    {
        playerCanvas = GameObject.Find("PlayerScreen");
        cardDeck = GameObject.Find("Deck");

        //clearing cards 
        for (int i = 0; i < 3; i++)
        {
            foreach (Transform child in playerCanvas.transform)
            {
                if (child.name.Contains("card"))
                {
                    child.transform.SetParent(cardDeck.transform, true);
                }
            }
        }

        for (int i = 0; i < playerHand.Length; i++)
        {
            cardNumber = playerHand[i];
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

        ActiveComTurnSpriteChange();
    }

    void ActiveComTurnSpriteChange()
    {
        if (currentPlayerIdCounnter == 1)
        {
            com3Image.sprite = com3BaseSprite;
        }
        if (currentPlayerIdCounnter == 2)
        {
            com1Image.sprite = com1GlitchSprite;
        }
        if (currentPlayerIdCounnter == 3)
        {
            com1Image.sprite = com1BaseSprite;
            com2Image.sprite = com2GlitchSprite;
        }
        if (currentPlayerIdCounnter == 4)
        {
            com2Image.sprite = com2BaseSprite;
            com3Image.sprite = com3GlitchSprite;
        }
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