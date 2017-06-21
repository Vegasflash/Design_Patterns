using UnityEngine;
using System.Collections;

public class TeddyVanish : MonoBehaviour
{
    public delegate void OnTeddyExit(GameObject teddy,bool isGood);
    public static event OnTeddyExit _onTeddyExit;
    public GameObject goodTeddy;
    public GameObject badTeddy;

    //Trigger to Detect which teddy was stored via Tags and shouts out to the Observer
    void OnTriggerEnter(Collider collider)
    {
        GameObject teddy = collider.gameObject;
        bool isGood;
        switch (collider.tag)
        {
            case "GoodTeddy":
                isGood = true;              
                //Debug.Log("Good TEDDY WENT THROUGH");
                teddy.SetActive(false);
                if (_onTeddyExit != null)
                {
                    _onTeddyExit(teddy,isGood);
                }
                break;

            case "BadTeddy":
                isGood = false;
                //Debug.Log("Bad TEDDY WENT THROUGH");
                teddy.SetActive(false);
                if (_onTeddyExit != null)
                {
                    _onTeddyExit(teddy, isGood);
                }
                break;
            default:
                //Debug.Log(" WTF just went through...");
                break;
        }      
    }

}
