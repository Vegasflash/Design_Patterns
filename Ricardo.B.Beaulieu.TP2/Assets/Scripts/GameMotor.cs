using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameMotor : MonoBehaviour
{
    public Text goodTeddyCount;
    public Text badTeddyCount;

    const int maxGoodTeddy = 5;
    const int maxBadTeddy = 5;

    int badTeddies;
    int goodTeddies;
    int counter;

    void Start()
    {
        goodTeddyCount.text = "Good Teddies: " + goodTeddies.ToString();
        badTeddyCount.text = "Bad Teddies: " + badTeddies.ToString();
    }

    public void AdjustGoodTeddyCounter()
    {
        goodTeddies = goodTeddies + 1;
        Debug.Log(goodTeddies);
        goodTeddyCount.text = "Good Teddies: " + goodTeddies;       
    }

    public void AdjustBadTeddyCounter()
    {
        badTeddies = badTeddies + 1;
        Debug.Log(badTeddies);
        badTeddyCount.text = "Bad Teddies: " + badTeddies;   
    }

    void OnTriggerEnter(Collider other)
    {
        GameObject teddy = other.gameObject;

        switch(teddy.tag)
        {
            case "GoodTeddy":
                Debug.Log("Good Teddy");
                AdjustGoodTeddyCounter();
                break;
            case "BadTeddy":
                Debug.Log("Bad Teddy");
                AdjustBadTeddyCounter();
                break;
            default:
                break;              
        }
        return;
    }
}

