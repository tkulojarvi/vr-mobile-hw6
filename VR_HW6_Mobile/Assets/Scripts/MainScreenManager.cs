using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MainScreenManager : MonoBehaviour
{

    // Persistent script that manages the state of variables
    // Used by other scripts to control objects

    public static MainScreenManager instance;

    // Control bools for setting the visual state of the canvas in main
    public bool[] scenesPlayed = new bool[6];
    public bool tutorialplayed = false;

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
    }

    void Start()
    {
        // At start, no scene has been played
        for (int i = 0; i < scenesPlayed.Length; i++)
        {
            scenesPlayed[i] = false;
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
}
