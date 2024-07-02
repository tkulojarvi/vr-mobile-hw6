using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public Quaternion shadowSpinner;

    void FixedUpdate()
    {
        // Save value
        shadowSpinner = transform.rotation;

        // Rotation
        transform.Rotate(-Vector3.forward, 45f * Time.deltaTime);
    }

    // Public method to retrieve the value of shadowSpinner
    public Quaternion GetShadowSpinner()
    {
        return shadowSpinner;
    }
}
