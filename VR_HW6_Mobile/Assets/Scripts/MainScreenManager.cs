using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MainScreenManager : MonoBehaviour
{
    public static MainScreenManager instance;

    // Control bools for setting the visual state of the canvas in main
    private bool[] scenesPlayed = new bool[6];
    private bool tutorialplayed = false;

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

    void Awake()
    {
        // If an instance already exists and it's not this one, destroy this one
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // Set the instance to this one if it's the first time it is being created
        instance = this;

        // Mark this GameObject to not be destroyed when loading new scenes
        DontDestroyOnLoad(gameObject);

        // Register method to be called when scene is loaded
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Start()
    {
        // At start, no scene has been played
        for (int i = 0; i < scenesPlayed.Length; i++)
        {
            scenesPlayed[i] = false;
        }
    }

    // Method called when a new scene has been loaded
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Main")
        {
            Debug.Log("Scene changed!"); // Optional debug log
            SetActiveState();
        }
    }

    void SetActiveState()
    {
        // Set the active state based on scenesPlayed
        for (int i = 0; i < 6; i++)
        {
            resultPapers[i].SetActive(scenesPlayed[i]);
            resultCanvases[i].SetActive(scenesPlayed[i]);
        }
    }

    public void UpdateBool(string scenename)
    {
        switch (scenename)
        {
            case "CANVAS_2":
                // Enable paper 1 and canvas 1
                scenesPlayed[0] = true;
                break;
            
            case "CANVAS_3":
                // Enable paper 2 and canvas 2
                scenesPlayed[1] = true;
                break;
            
            case "CANVAS_4":
                // Enable paper 3 and canvas 3
                scenesPlayed[2] = true;
                break;
            
            case "CANVAS_5":
                // Enable paper 4 and canvas 4
                scenesPlayed[3] = true;
                break;
            
            case "CANVAS_6":
                // Enable paper 5 and canvas 5
                scenesPlayed[4] = true;
                break;
            
            case "CANVAS_7":
                // Enable paper 6 and canvas 6
                scenesPlayed[5] = true;
                break;

            default:
                //Debug.LogWarning("Unknown scene name: " + scenename);
                break;
        }

        for (int i = 0; i < scenesPlayed.Length; i++)
        {
            Debug.Log($"scenesPlayed[{i}] = {scenesPlayed[i]}");
        }
    }

    public void WriteHSVToPaper()
    {
        
    }

/*
    public void DisplayHSVValue(string scenename, int hue, int sat, int val)
    {

    // Display HSV Value on paper

        switch (scenename)
        {
            case "CANVAS_2":
                text1.text = hue.ToString() + "," + sat.ToString() + "," + val.ToString();
                break;
            
            case "CANVAS_3":
                text2.text = hue.ToString() + "," + sat.ToString() + "," + val.ToString();
                break;
            
            case "CANVAS_4":
                text3.text = hue.ToString() + "," + sat.ToString() + "," + val.ToString();
                break;
            
            case "CANVAS_5":
                text4.text = hue.ToString() + "," + sat.ToString() + "," + val.ToString();
                break;
            
            case "CANVAS_6":
                text5.text = hue.ToString() + "," + sat.ToString() + "," + val.ToString();
                break;
            
            case "CANVAS_7":
                text6.text = hue.ToString() + "," + sat.ToString() + "," + val.ToString();
                break;

            default:
                // Debug.LogWarning("Unknown scene name: " + scenename);
                break;
        }
    }


    public void DisplayColor(string scenename)
    {
        // Display chosen color on canvas

        switch (scenename)
        {
            case "CANVAS_2":
                
                break;
            
            case "CANVAS_3":
                
                break;
            
            case "CANVAS_4":
                
                break;
            
            case "CANVAS_5":
                
                break;
            
            case "CANVAS_6":
                
                break;
            
            case "CANVAS_7":
                
                break;

            default:
                //Debug.LogWarning("Unknown scene name: " + scenename);
                break;
        }
    }

    public void HideTutorialCanvas()
    {
        // Hide tutorial after exiting it

    }
*/
}
