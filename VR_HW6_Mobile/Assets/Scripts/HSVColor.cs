using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class HSVColor : MonoBehaviour
{
    // HSV components of the color
    public float hue = 0f;            // Range 0 to 1
    public float saturation = 1f;     // Range 0 to 1
    public float value = 1f;          // Range 0 to 1

    // In degrees
    private int hueDegrees = 0;
    private int satDegrees = 0;
    private int valDegrees = 0;

    // Reference to the object's renderer
    private Renderer rend;

    // Debug
    public TextMeshProUGUI hueText;
    public TextMeshProUGUI saturationText;
    public TextMeshProUGUI valueText;      

    public void SetHue(float h)
    {
        hue = h;
    }

    public void SetSaturation(float s)
    {
        saturation = s;
    }

    public void SetValue(float v)
    {
        value = v;
    }

    void Start()
    {
        rend = GetComponent<Renderer>();  // Assuming the script is attached to the object with Renderer
    }

    void ToDegrees()
    {
        hueDegrees = Mathf.FloorToInt(hue * 360);
        satDegrees = Mathf.FloorToInt(saturation * 100);
        valDegrees = Mathf.FloorToInt(value * 100);
    }

    void Update()
    {
        // Convert HSV to RGB
        Color newColor = Color.HSVToRGB(hue, saturation, value);

        // Apply the color to the object
        rend.material.color = newColor;

        // Convert values to degrees
        ToDegrees();

        // Print the degree values
        hueText.text = "Hue: " + (hueDegrees).ToString();
        saturationText.text = "Sat: " + (satDegrees).ToString();
        valueText.text = "Val: " + (valDegrees).ToString();
    }
}
