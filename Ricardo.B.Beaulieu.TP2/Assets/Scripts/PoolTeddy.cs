using UnityEngine;
using System.Collections;

public class PoolTeddy : MonoBehaviour
{
    public virtual void OnGoodTeddyRecycle()
     {
        // Use me to reset values on the Good Teddy please! :D
     }
    public virtual void OnBadTeddyRecycle()
    {
        // Use me to reset the values on the Bad Teddy please! ;D
    }

    // TODO sortof gimicky, maybe of use in the future if i need to destroy my teddies
    protected void Destroy()
    {
        /**
        gameObject.SetActive(false);
        /**/
    }
}
