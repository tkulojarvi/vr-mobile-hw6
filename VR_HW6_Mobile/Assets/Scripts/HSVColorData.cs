using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewHSVColor", menuName = "Custom/HSVColor")]
public class HSVColorData : ScriptableObject
{
    // HSV components of the color
    public float hue = 0f;            // Range 0 to 1
    public float saturation = 1f;     // Range 0 to 1
    public float value = 1f;          // Range 0 to 1

    // Factory method to create new instance
    public static HSVColorData Create(float h, float s, float v)
    {
        HSVColorData instance = ScriptableObject.CreateInstance<HSVColorData>();
        instance.hue = h;
        instance.saturation = s;
        instance.value = v;
        return instance;
    }
}

