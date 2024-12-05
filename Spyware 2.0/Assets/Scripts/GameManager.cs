using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject startMenu;
    public GameObject winScreen;
    public GameObject loseScreen;

    public void StartButton()
    {
        CardManager.instance.ShuffleDeck();
        CardManager.instance.DealCards(1);

        startMenu.SetActive(false);
    }

    public void OkButton()
    {
        winScreen.SetActive(false);
        loseScreen.SetActive(false);

        startMenu.SetActive(true);
    }
}
