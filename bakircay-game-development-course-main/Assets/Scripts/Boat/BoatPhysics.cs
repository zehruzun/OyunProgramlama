using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatPhysics : MonoBehaviour
{
    public float waterLevel = 2.5f;
    public float floatHeight = 2f;
    public float bounceDamp = 0.05f;

    void Update()
    {
        float forceFactor = 1f - ((transform.position.y - waterLevel) / floatHeight);

        if (forceFactor > 0f)
        {
            Vector3 uplift = -Physics.gravity * (forceFactor - GetComponent<Rigidbody>().velocity.y * bounceDamp);
            GetComponent<Rigidbody>().AddForce(uplift);
        }
    }
}
