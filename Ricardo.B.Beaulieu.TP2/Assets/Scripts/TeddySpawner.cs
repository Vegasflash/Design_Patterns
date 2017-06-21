using UnityEngine;
using System.Collections;

public class TeddySpawner : MonoBehaviour
{
    public GameObject _gTeddy;
    public GameObject _bTeddy;

    // Here i use my Singleton instance to spawn teddies
    void Update()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0;
        if (!Input.GetKey("space") && Input.GetMouseButtonDown(0))
        {
            Debug.Log("sup");
            GameZone.instance.RecycleGoodTeddy(_gTeddy, mouseWorldPos, Quaternion.identity);
        }
        else if (Input.GetKey("space") && Input.GetMouseButtonDown(0))
        {
            GameZone.instance.RecycleBadTeddy(_bTeddy, mouseWorldPos, Quaternion.identity);
        }
    }
}
