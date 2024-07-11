using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ValuePicker : MonoBehaviour
{
    private Quaternion gyroRotation; // Current rotation
    private Quaternion adjustedRotation; // Adjusted rotation for Unity
    
    // Color object
    public HSVColorVisualiser hSVColorScript;
    private float v;


    //public TextMeshProUGUI gyroTextX;
    //public TextMeshProUGUI gyroTextY; 
    //public TextMeshProUGUI gyroTextZ; 

    void Start()
    {
        // Enable the gyroscope
        Input.gyro.enabled = true;
    }

    void Update()
    {
        // WORKS!
        
        // NOISE FILTERING NEEDED?

        // Get the current rotation of the device
        gyroRotation = Input.gyro.attitude;

        // Adjust the rotation to match Unity's coordinate system
        adjustedRotation = new Quaternion(
            gyroRotation.x,
            gyroRotation.y,
            -gyroRotation.z,
            -gyroRotation.w);

        // Map adjustedRotation to range from 0 to 1 for variable v
        v = Mathf.Clamp01(Mathf.InverseLerp(-0.5f, 0.5f, adjustedRotation.x));

        // Set color value
        hSVColorScript.SetValue(v);

        // debug
        //gyroTextX.text = "x: " + (adjustedRotation.x).ToString("F2");
        //gyroTextY.text = "y: " + (adjustedRotation.y).ToString("F2");
        //gyroTextZ.text = "z: " + (adjustedRotation.z).ToString("F2");
    }
}
