using UnityEngine;
using System.Collections;

public class BadTeddyMotor : PoolTeddy
{
    float spinSpeed = 5.0f;
    float moveSpeed = 1.0f;
    float negGravity = 1f;
    float increment = 0.1f;

    // BadTeddy Script to give life to the Bad teddy prefabs.
    void Update()
    {
        BadTeddyForce();
        BadTeddyTwist();
    }

    void FixedUpdate()
    {
        BadTeddyGravity();
    }

    void BadTeddyTwist()
    {
        transform.Rotate(Vector3.up * spinSpeed);
    }

    void BadTeddyForce()
    {
        transform.position += Vector3.up * Time.deltaTime * moveSpeed;
    }

    void BadTeddyGravity()
    {
        negGravity = negGravity + increment;
        //Debug.Log(gravity);
        transform.position += Vector3.up * Time.deltaTime * negGravity;
    }

    public override void OnGoodTeddyRecycle()
    {
        // reset the gravity of the good teddy, so that once he's recycled, he doesn't maintain
        // his previous activation's gravity value
        negGravity = 1f;
    }
}
