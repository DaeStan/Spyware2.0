using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private void Start()
    {

        CardManager.instance.ShuffleDeck();
        CardManager.instance.DealCards(1);
    }

    //track id 
    //find game object
    //call function on thatg com object
}
