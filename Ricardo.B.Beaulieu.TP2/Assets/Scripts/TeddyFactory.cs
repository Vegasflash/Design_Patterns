using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class TeddyFactory : MonoBehaviour
{
    // Teddy Creation is done via GameZone class, to keep a lid on their creation, 
    // ask permission for change.
    public GameObject goodTeddy;
    public GameObject badTeddy;

    public const int basicTeddyPoolSize = 5;

    enum PoolType { BadTeddyPool, GoodTeddyPool }

    void Start()
    {
        GoodTeddyPoolSend(SetGoodTeddyPoolSize(basicTeddyPoolSize));
        BadTeddyPoolSend(SetBadTeddyPoolSize(basicTeddyPoolSize));      
    }

    public int SetGoodTeddyPoolSize(int basicTeddyPoolSize)
    {
        int goodPoolSize;
        goodPoolSize = basicTeddyPoolSize;
        return goodPoolSize;    
    }
    public int SetBadTeddyPoolSize(int basicTeddyPoolSize)
    {
        int badPoolSize;
        badPoolSize = basicTeddyPoolSize;
        return badPoolSize;
    }

    public void GoodTeddyPoolSend(int goodPoolSize)
    {
        GameZone.instance.CreateGoodTeddyPool(goodTeddy, goodPoolSize);
    }
    public void BadTeddyPoolSend(int badPoolSize)
    {     
        GameZone.instance.CreateBadTeddyPool(badTeddy, badPoolSize);
    }
}
