using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject startMenu;
    public GameObject winScreen;
    public GameObject loseScreen;
    public GameObject ruleScreen;

    public int ruleCounter = 1;

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

        SceneManager.LoadScene("Game");
    }

    public void RulesButton()
    {
        ruleScreen.SetActive(true);
    }

    public void RulesOkButton()
    {
        foreach (Transform child in ruleScreen.transform)
        {
            if (child.name.Contains(ruleCounter.ToString()))
            {
                child.gameObject.SetActive(false);
                ++ruleCounter;
            }
        }

        if (ruleCounter == 8)
        {
            ruleScreen.SetActive(false);
            startMenu?.SetActive(true);

            foreach (Transform child in ruleScreen.transform)
            {
                child.gameObject.SetActive(true);
            }
            ruleCounter = 1;
        }
    }
}
