using UnityEngine;
using System.Collections;
using System.Threading;

public class GoodTeddyMotor : PoolTeddy
 {
    float moveSpeed = 1f;
    float spinSpeed = 1f;
    float gravity = 1f;
    float increment = 0.07f;

    // GoodTeddy Script to give life to the Good Teddy prefabs.
    void Update()
    {
        GoodTeddyForce();
        RotateGoodTeddy();
	}

    void FixedUpdate()
    {
        GoodTeddyGravity();
    }

    void GoodTeddyForce()
    {
        // positive force downwards
        transform.position += Vector3.down * Time.deltaTime * moveSpeed;
    }

    void RotateGoodTeddy()
    {
        transform.Rotate(Vector3.forward * spinSpeed);
    }

    void GoodTeddyGravity()
    {
        gravity = gravity + increment;
        //Debug.Log(negGravity);
        transform.position += Vector3.down * Time.deltaTime * gravity;
    }

    public override void OnGoodTeddyRecycle()
    {
        // reset the negative gravity of the good teddy, so that once he's recycled, he doesn't maintain
        // his previous activation's gravity value
        gravity = 1f;
    }
}
