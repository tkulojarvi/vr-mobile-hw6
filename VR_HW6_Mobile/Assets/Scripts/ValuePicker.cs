using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValuePicker : MonoBehaviour
{
    private Quaternion gyroRotation; // Current rotation
    private Quaternion adjustedRotation; // Adjusted rotation for Unity
    Transform cam;
    
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
        if (!cam && Camera.main)
            cam = Camera.main.transform;
        if (!cam)
            return;

        adjustedRotation = cam.rotation;

        float closest180 = Mathf.Round(adjustedRotation.eulerAngles.z / 180) * 180;

        // Adjust the range to make v = 1 when there is no rotation deviation
        v = Mathf.InverseLerp(-25f, 0f, closest180 - adjustedRotation.eulerAngles.z);

        // Set color value
        hSVColorScript.SetValue(v);
    }

}
