using UnityEngine;
using System;
using System.Collections.Generic;

public class GameZone : MonoBehaviour
{
    Dictionary<int, Queue<TeddyInstance>> poolDictionary = new Dictionary<int, Queue<TeddyInstance>>();

    // Singleton
    /**/
    static GameZone _instance;

    public static GameZone instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameZone>();
            }
            return _instance;
        }
    }
    /**/

    // OBSERVER
    // Watches out for calls from Teddy Vanish Class
    /**/
    void OnEnable()
    {
        TeddyVanish._onTeddyExit += _storeTeddy;
    }

    private void _storeTeddy(GameObject teddy, bool isGood)
    {
        switch (isGood)
        {
            case true:
                Debug.Log("Stored Good Teddy ID back in list");
                //store the teddy back in the object pool
                RecycleGoodTeddy(teddy, Vector3.zero, Quaternion.identity);              
                break;
            case false:
                Debug.Log(" Stored Bad Teddy ID back in list");
                //store the teddy back in the object pool
                RecycleBadTeddy(teddy, Vector3.zero, Quaternion.identity);
                break;
            default:
                Debug.Log(" I don't know who you are or how you got here, but when i find you, i will debug you ");
                break;
        }
    }
    /**/
   
    // Object Pools
    // Good Teddy Pool is stored here
    /**/ 
    public void CreateGoodTeddyPool(GameObject goodTeddy, int poolSize)
    {
        int poolKey = goodTeddy.GetInstanceID();
        GameObject poolHolder = new GameObject(goodTeddy.name + "pool");

        if (!poolDictionary.ContainsKey(poolKey))
        {
            poolDictionary.Add(poolKey, new Queue<TeddyInstance>());
            // Good Teddy Factory
            for (int count = 0; count < poolSize; count++)
            {
                TeddyInstance newGoodTeddy = new TeddyInstance(Instantiate(goodTeddy) as GameObject);
                poolDictionary[poolKey].Enqueue(newGoodTeddy);
                newGoodTeddy.SetParent(poolHolder.transform);
            }
        }
    }

    // Bad Teddy Pool is stored here
    public void CreateBadTeddyPool(GameObject badTeddy, int poolSize)
    {
        int poolKey = badTeddy.GetInstanceID();
        GameObject poolHolder = new GameObject(badTeddy.name + "pool");

        if (!poolDictionary.ContainsKey(poolKey))
        {
            poolDictionary.Add(poolKey, new Queue<TeddyInstance>());
            // Bad Teddy Factory
            for (int count = 0; count < poolSize; count++)
            {
                TeddyInstance newBadTeddy = new TeddyInstance(Instantiate(badTeddy) as GameObject);
                poolDictionary[poolKey].Enqueue(newBadTeddy);
                newBadTeddy.SetParent(poolHolder.transform);
            }
        }
    }
    /**/

    // Recycles in order the Good Teddies when called in TeddySpawner script
    public void RecycleGoodTeddy(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        int poolKey = prefab.GetInstanceID();
        // Recycle the queued Good Teddy which take the first deactivated Good teddy and reactivates it as a priority
        if (poolDictionary.ContainsKey(poolKey))
        {           
            TeddyInstance goodTeddyToRecycle = poolDictionary[poolKey].Dequeue();
            poolDictionary[poolKey].Enqueue(goodTeddyToRecycle);
            goodTeddyToRecycle.Recycle(position, rotation);
        }
    }

    // Recycles in order the Bad Teddies when called in TeddySpawner script
    public void RecycleBadTeddy(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        int poolKey = prefab.GetInstanceID();
        // Recycle the queued Good Teddy which take the first deactivated Bad teddy and reactivates it as a priority
        if (poolDictionary.ContainsKey(poolKey))
        {         
            TeddyInstance badTeddyToRecycle = poolDictionary[poolKey].Dequeue();
            poolDictionary[poolKey].Enqueue(badTeddyToRecycle);
            badTeddyToRecycle.Recycle(position, rotation);
        }
    }
    // New Instance of GameObject teddy
    // Use as my new GameObject
    public class TeddyInstance
    {
        public TeddyInstance(GameObject teddyInstance)
        {
            teddy = teddyInstance;
            transform = teddy.transform;
            teddy.SetActive(false);
      
            if (teddy.GetComponent<PoolTeddy>())
            {
                hasPoolComponent = true;
                poolTeddyScript = teddy.GetComponent<PoolTeddy>();
            }
        }

        GameObject teddy;
        Transform transform;

        bool hasPoolComponent;
        PoolTeddy poolTeddyScript;

        int teddyCounter;

        public void Recycle(Vector3 position, Quaternion rotation)
        {
            if (hasPoolComponent)
            {
                poolTeddyScript.OnGoodTeddyRecycle();
                poolTeddyScript.OnBadTeddyRecycle();
            }
            teddy.SetActive(true);
            transform.position = position;
            transform.rotation = rotation;
        }

        public void SetParent(Transform parent)
        {
            transform.parent = parent;
        }
    }
}


