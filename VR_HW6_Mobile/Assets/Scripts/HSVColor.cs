using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HSVColor : MonoBehaviour
{
    // HSV components of the color
    public float hue = 0f;            // Range 0 to 1
    public float saturation = 1f;     // Range 0 to 1
    public float value = 1f;          // Range 0 to 1

    // Reference to the object's renderer
    private Renderer rend;      

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

    void Update()
    {
        // Convert HSV to RGB
        Color newColor = Color.HSVToRGB(hue, saturation, value);

        // Apply the color to the object
        rend.material.color = newColor;

        // Print the color values to the console
        //Debug.Log("New Color: " + newColor);
    }
}
