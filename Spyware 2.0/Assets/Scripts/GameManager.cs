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
    public GameObject blueScreen;

    public int ruleCounter = 1;

    public AudioSource source;
    public AudioClip error;
    public AudioClip fans;

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

    public void CancelButton()
    {
        source.clip = fans;
        source.Play();

        loseScreen.SetActive(false);
        blueScreen.SetActive(true);
    }

    public void RestartButton()
    {
        OkButton();
    }

    public void RulesButton()
    {
        ruleScreen.SetActive(true);
        source.clip = error;

        source.Play();
    }

    public void RulesOkButton()
    {
        startMenu.SetActive(false);

        foreach (Transform child in ruleScreen.transform)
        {
            if (child.name.Contains(ruleCounter.ToString()))
            {
                child.gameObject.SetActive(false);
                ++ruleCounter;
            }
        }

        if (ruleCounter == 9)
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
