using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class ControlVisuals : MonoBehaviour
{
    // Script to control the visuals (paintings etc,)
    // Takes bool values from MainScreenManager

    // Canvases
    public GameObject[] resultPapers;
    public GameObject[] resultCanvases;
    public GameObject tutorialCanvas;
    public GameObject[] sceneCanvases;

    // Text objects
    public TextMeshProUGUI[] texts;








    void Start()
    {
        /*
        if(MainScreenManager.instance.tutorialplayed == false)
        {
            DisableScenesAtBeginning();
        }
        

        if(MainScreenManager.instance.tutorialplayed == true)
        {
            DisableTutorial();
        }
        */

        SetActiveState();
        DisplayText();
        DisplayColor();
    }

    void DisableScenesAtBeginning()
    {
        for (int i = 0; i < 6; i++)
        {
            sceneCanvases[i].SetActive(false);
        }
    }
/*
    void DisableTutorial()
    {
        tutorialCanvas.SetActive(false);
    }
*/
    void SetActiveState()
    {
        // Set the active state based on scenesPlayed (saved bool in MainScreenManager)
        for (int i = 0; i < 6; i++)
        {
            resultPapers[i].SetActive(MainScreenManager.instance.scenesPlayed[i]);
            resultCanvases[i].SetActive(MainScreenManager.instance.scenesPlayed[i]);
        }

        
    }

    void DisplayText()
    {
        // Iterating through colors array
        for (int i = 0; i < 10; i++)
        {
            if (MainScreenManager.instance.colors[i] != null)
            {
                // Access HSVColor properties
                float hue = MainScreenManager.instance.colors[i].hue;
                float saturation = MainScreenManager.instance.colors[i].saturation;
                float value = MainScreenManager.instance.colors[i].value;

                Debug.Log("Color " + i + ": Hue = " + hue + ", Saturation = " + saturation + ", Value = " + value);

                // Convert to degrees
                int hueDegrees = Mathf.FloorToInt(hue * 360);
                int satDegrees = Mathf.FloorToInt(saturation * 100);
                int valDegrees = Mathf.FloorToInt(value * 100);

                // Convert time to whole seconds (no decimals)
                int timeInSeconds = Mathf.FloorToInt(MainScreenManager.instance.timeSpentInScenes[i]);

                // Update TextMeshPro or similar text component
                texts[i].text = "H:" + hueDegrees + "\n" + "S:" + satDegrees + "\n" + "V:" + valDegrees + "\n" + timeInSeconds + " s";
            }
        }
    }

    void DisplayColor()
    {
        // Iterating through colors array
        for (int i = 0; i < 10; i++)
        {
            if (MainScreenManager.instance.colors[i] != null)
            {
                // Access HSVColor properties
                float hue = MainScreenManager.instance.colors[i].hue;
                float saturation = MainScreenManager.instance.colors[i].saturation;
                float value = MainScreenManager.instance.colors[i].value;

                // Convert HSV to RGB
                Color newColor = Color.HSVToRGB(hue, saturation, value);

                // Ensure resultCanvases[i] exists before attempting to get a renderer
                if (resultCanvases[i] != null)
                {
                    // Check for Renderer in the child first
                    Renderer rend = resultCanvases[i].GetComponentInChildren<Renderer>();

                    // If no Renderer in child, check in the main (parent) object itself
                    if (rend == null)
                    {
                        rend = resultCanvases[i].GetComponent<Renderer>();
                    }

                    // If Renderer is found, apply the color
                    if (rend != null)
                    {
                        rend.material.color = newColor;
                    }
                    else
                    {
                        Debug.LogWarning("Renderer not found on resultCanvas or its child at index " + i);
                    }
                }
                else
                {
                    Debug.LogWarning("No resultCanvas found at index " + i);
                }
            }
        }
    }
}
