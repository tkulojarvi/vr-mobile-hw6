using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Controls Saturation and Value via rotation of the headset.
/// </summary>
public class SVPicker : MonoBehaviour
{
    //private Quaternion initialRotation; // Initial rotation
    private Quaternion gyroRotation; // Current rotation
    private Quaternion adjustedRotation; // Adjusted rotation for Unity

    //public GameObject testObject;
    public HSVColor hSVColorScript;
    private float s;
    private float v;

    // TEST
    //public TextMeshProUGUI gyroText;
    public TextMeshProUGUI saturationText;
    

    void Start()
    {
        // Enable the gyroscope
        Input.gyro.enabled = true;

        // Get the initial rotation of the device
        //initialRotation = Input.gyro.attitude;
    }

    void Update()
    {

        // WORKS ON A BASE LEVEL!
        // NEEDS FINE TUNING

        // ARE VALUE VALUES FROM 0-1 OR 0-2?



        // Get the current rotation of the device
        gyroRotation = Input.gyro.attitude;

        // Adjust the rotation to match Unity's coordinate system
        adjustedRotation = new Quaternion(
            gyroRotation.x,
            gyroRotation.y,
            -gyroRotation.z,
            -gyroRotation.w);

        // Map adjustedRotation.x to range from 0 to 1 for variable s
        s = Mathf.Clamp01(Mathf.InverseLerp(-1f, 1f, adjustedRotation.x));

        // Now s will vary from 0 to 1 based on adjustedRotation.x
        // You can use the value of s to control whatever you need
        // For example, you might want to change the color or scale of an object based on s
        // For SaturationTestObject, you can set its saturation based on s
        //Saturation(s);

        // X IS ROLL
        //gyroText.text = "S: " + (adjustedRotation.x).ToString("F2");
        saturationText.text = "Sat: " + (s).ToString("F2");
    }

    void Saturation(float s)
    {
        hSVColorScript.SetSaturation(s);
    }

    void Value(float v)
    {
        hSVColorScript.SetValue(v);
    }
}
