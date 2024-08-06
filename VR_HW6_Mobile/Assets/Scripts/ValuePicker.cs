using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValuePicker : MonoBehaviour
{
    private Quaternion gyroRotation; // Current rotation
    private Quaternion adjustedRotation; // Adjusted rotation for Unity
    
    // Color object
    public HSVColorVisualiser hSVColorScript;
    private float v;

    void Start()
    {
        // Enable the gyroscope
        Input.gyro.enabled = true;
    }

    void Update()
    {
        // Get the current rotation of the device
        gyroRotation = Input.gyro.attitude;

        // Adjust the rotation to match Unity's coordinate system
        adjustedRotation = new Quaternion(
            gyroRotation.x,
            0f,  // Ignore rotation around y-axis
            0f,  // Ignore rotation around z-axis
            0f); // Ignore rotation around w-axis

        // Map adjustedRotation to range from 0 to 1 for variable v
        v = Mathf.Clamp01(Mathf.InverseLerp(-0.25f, 0.25f, adjustedRotation.x));

        // Set color value
        hSVColorScript.SetValue(v);
    }
}
