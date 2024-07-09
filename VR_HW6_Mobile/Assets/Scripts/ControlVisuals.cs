using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class ControlVisuals : MonoBehaviour
{
    // Script to control the visuals (paintings etc,)
    // Takes bool values from MainScreenManager

    // Gameobjects
    public GameObject[] resultPapers;
    public GameObject[] resultCanvases;
    public GameObject tutorialCanvas;

    // Text objects
    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;
    public TextMeshProUGUI text3;   
    public TextMeshProUGUI text4;
    public TextMeshProUGUI text5;
    public TextMeshProUGUI text6; 

    void Start()
    {
        SetActiveState();
    }

    void SetActiveState()
    {
        // Set the active state based on scenesPlayed (saved bool in MainScreenManager)
        for (int i = 0; i < 6; i++)
        {
            resultPapers[i].SetActive(MainScreenManager.instance.scenesPlayed[i]);
            resultCanvases[i].SetActive(MainScreenManager.instance.scenesPlayed[i]);
        }
    }
}
