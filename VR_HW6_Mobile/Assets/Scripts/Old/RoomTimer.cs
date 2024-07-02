using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class RoomTimer : MonoBehaviour
{
    public float timeRemaining = 60; // Initial time in seconds
    private Flow flowScript;    // Flow script reference so we can modify speed
    private Scene activeScene;
    private string sceneName;

    private AudioSource audioSource1;
    private AudioSource audioSource2;

    // Boolean flags for each condition
    private bool hasSetSpeed1 = false;
    private bool hasSetSpeed2 = false;
    private bool hasSetSpeed3 = false;
    private bool hasSetSpeed4 = false;
    private bool hasSetSpeed5 = false;
    private bool hasSetSpeed6 = false;

    void Start()
    {
        // Get the active scene
        activeScene = SceneManager.GetActiveScene();
        // Get the name of the active scene
        sceneName = activeScene.name;

        // Find the GameObject named "PlayerTape"
        GameObject playerObj = GameObject.Find("PlayerTape");

        // Get the Flow script reference
        flowScript = playerObj.GetComponent<Flow>();

        // Get Audio Sources
        //GameObject audioObj1 = GameObject.Find("PlayerTape");
        GameObject audioObj2 = GameObject.Find("AudioObj2");
        //audioSource1 = audioObj1.GetComponent<AudioSource>();
        audioSource2 = audioObj2.GetComponent<AudioSource>();

        // Set initial speed
        if(sceneName == "TAPE_1" || sceneName == "TAPE_2" || sceneName == "TAPE_3")
        {
            flowScript.gap = 1;
            flowScript.speed = 1;
            hasSetSpeed1 = true;
        }
        if(sceneName == "TAPE_4" || sceneName == "TAPE_5" || sceneName == "TAPE_6")
        {
            flowScript.rotation = 10;
            hasSetSpeed1 = true;
        }
        
        // Play AUDIO NOTE 1: BEGIN

    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            // Decrease timeRemaining by the time since last frame
            timeRemaining -= Time.deltaTime; 
        }
        else
        {
            // Timer has reached 0
            SceneManager.LoadScene("Main");
        }

        // UPDATE SPEED VALUE FOR 1-3
        if(sceneName == "TAPE_1" || sceneName == "TAPE_2" || sceneName == "TAPE_3")
        {
            SpeedUpdater();
        }

        // UPDATE ROT VALUE FOR 4-6
        if(sceneName == "TAPE_4" || sceneName == "TAPE_5" || sceneName == "TAPE_6")
        {
            RotationUpdater();
        }

        // Scenes 7 and 8 should not have the feature.
    }

    void SpeedUpdater()
    {
        if(timeRemaining > 40 && timeRemaining < 50 && !hasSetSpeed2) // if between 50 and 40 seconds
        {
            // Play AUDIO NOTE 2: SPEEDUP
            audioSource2.Play();

            // SPEED UP 2
            flowScript.gap = 2;
            flowScript.speed = 2;
            hasSetSpeed2 = true;
        }

        else if(timeRemaining > 30 && timeRemaining < 40 && !hasSetSpeed3) // if between 40 and 30 seconds
        {
            // Play AUDIO NOTE 2: SPEEDUP
            audioSource2.Play();

            // SPEED UP 3
            flowScript.gap = 3;
            flowScript.speed = 3;
            hasSetSpeed3 = true;
        }

        else if(timeRemaining > 20 && timeRemaining < 30 && !hasSetSpeed4) // if between 30 and 20 seconds
        {
            // Play AUDIO NOTE 2: SPEEDUP
            audioSource2.Play();

            // SPEED UP 4
            flowScript.gap = 4;
            flowScript.speed = 4;
            hasSetSpeed4 = true;
        }
        
        else if(timeRemaining > 10 && timeRemaining < 20 && !hasSetSpeed5) // if between 20 and 10 seconds
        {
            // Play AUDIO NOTE 2: SPEEDUP
            audioSource2.Play();

            // SPEED UP 5
            flowScript.gap = 5;
            flowScript.speed = 5;
            hasSetSpeed5 = true;
        }
        
        else if(timeRemaining > 0 && timeRemaining < 10 && !hasSetSpeed6)  // if between 10 and 0 seconds
        {
            // Play AUDIO NOTE 2: SPEEDUP
            audioSource2.Play();

            // SPEED UP 6
            flowScript.gap = 6;
            flowScript.speed = 6;
            hasSetSpeed6 = true;
        }
    }

    void RotationUpdater()
    {
        if(timeRemaining > 40 && timeRemaining < 50  && !hasSetSpeed2) // if between 50 and 40 seconds
        {
            // Play AUDIO NOTE 2: SPEEDUP
            audioSource2.Play();

            // SPEED UP 2
            flowScript.rotation = 20;
            hasSetSpeed2 = true;
        }

        else if(timeRemaining > 30 && timeRemaining < 40  && !hasSetSpeed3) // if between 40 and 30 seconds
        {
            // Play AUDIO NOTE 2: SPEEDUP
            audioSource2.Play();

            // SPEED UP 3
            flowScript.rotation = 30;
            hasSetSpeed3 = true;
        }

        else if(timeRemaining > 20 && timeRemaining < 30 && !hasSetSpeed4) // if between 30 and 20 seconds
        {
            // Play AUDIO NOTE 2: SPEEDUP
            audioSource2.Play();

            // SPEED UP 4
            flowScript.rotation = 40;
            hasSetSpeed4 = true;
        }
        
        else if(timeRemaining > 10 && timeRemaining < 20 && !hasSetSpeed5) // if between 20 and 10 seconds
        {
            // Play AUDIO NOTE 2: SPEEDUP
            audioSource2.Play();

            // SPEED UP 5
            flowScript.rotation = 50;
            hasSetSpeed5 = true;
        }
        
        else if(timeRemaining > 0 && timeRemaining < 10 && !hasSetSpeed6)  // if between 10 and 0 seconds
        {
            // Play AUDIO NOTE 2: SPEEDUP
            audioSource2.Play();

            // SPEED UP 6
            flowScript.rotation = 60;
            hasSetSpeed6 = true;
        }
    }
}
