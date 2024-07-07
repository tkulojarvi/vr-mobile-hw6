//-----------------------------------------------------------------------
// <copyright file="ObjectController.cs" company="Google LLC">
// Copyright 2020 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections;
using UnityEngine;

//added
using UnityEngine.SceneManagement;

/// <summary>
/// Controls target objects behaviour.
/// </summary>
public class ObjectController : MonoBehaviour
{
    /// <summary>
    /// The material to use when this object is inactive (not being gazed at).
    /// </summary>
    //public Material InactiveMaterial;

    /// <summary>
    /// The material to use when this object is active (gazed at).
    /// </summary>
    //public Material GazedAtMaterial;

    // The objects are about 1 meter in radius, so the min/max target distance are
    // set so that the objects are always within the room (which is about 5 meters
    // across).
    /*
    private const float _minObjectDistance = 2.5f;
    private const float _maxObjectDistance = 3.5f;
    private const float _minObjectHeight = 0.5f;
    private const float _maxObjectHeight = 3.5f;
    */

    private Renderer _myRenderer;

    /// <summary>
    /// Start is called before the first frame update.
    /// </summary>
    public void Start()
    {
        _myRenderer = GetComponent<Renderer>();

        // added
         // Store the initial scale of the object
        baseScale = transform.localScale;

        SetMaterial(false);
    }

    /*
    /// <summary>
    /// Teleports this instance randomly when triggered by a pointer click.
    /// </summary>
    public void TeleportRandomly()
    {
        // Picks a random sibling, activates it and deactivates itself.
        int sibIdx = transform.GetSiblingIndex();
        int numSibs = transform.parent.childCount;
        sibIdx = (sibIdx + Random.Range(1, numSibs)) % numSibs;
        GameObject randomSib = transform.parent.GetChild(sibIdx).gameObject;

        // Computes new object's location.
        float angle = Random.Range(-Mathf.PI, Mathf.PI);
        float distance = Random.Range(_minObjectDistance, _maxObjectDistance);
        float height = Random.Range(_minObjectHeight, _maxObjectHeight);
        Vector3 newPos = new Vector3(Mathf.Cos(angle) * distance, height,
                                     Mathf.Sin(angle) * distance);

        // Moves the parent to the new position (siblings relative distance from their parent is 0).
        transform.parent.localPosition = newPos;

        randomSib.SetActive(true);
        gameObject.SetActive(false);
        SetMaterial(false);
    }
    */

    /// <summary>
    /// This method is called by the Main Camera when it starts gazing at this GameObject.
    /// </summary>
    public void OnPointerEnter()
    {
        //timer
        StartTimer();
    }

    /// <summary>
    /// This method is called by the Main Camera when it stops gazing at this GameObject.
    /// </summary>
    public void OnPointerExit()
    {
        // stop timer
        StopTimer();
        
    }

    /*
    /// <summary>
    /// This method is called by the Main Camera when it is gazing at this GameObject and the screen
    /// is touched.
    /// </summary>
    public void OnPointerClick()
    {
        TeleportRandomly();
    }
    */

    /// <summary>
    /// Sets this instance's material according to gazedAt status.
    /// </summary>
    ///
    /// <param name="gazedAt">
    /// Value `true` if this object is being gazed at, `false` otherwise.
    /// </param>
    private void SetMaterial(bool gazedAt)
    {
        /*
        if (InactiveMaterial != null && GazedAtMaterial != null)
        {
            _myRenderer.material = gazedAt ? GazedAtMaterial : InactiveMaterial;
        }
        */

        /*
        if (gazedAt)
        {
            _myRenderer.material.color = GazedAtColor; // Set the material's color to GazedAtColor
        }
        else
        {
            _myRenderer.material.color = InactiveColor; // Set the material's color to InactiveColor
        }
        */
        
        
        if (gazedAt)
        {
            //emissionOn = !emissionOn; // Set the material's color to GazedAtColor
            //ToggleEmission(true);
        }
        else
        {
            //emissionOn = !emissionOn; // Set the material's color to InactiveColor
            //ToggleEmission(false);
        }
        
    }


    // custom 

    private float timeRemaining = 3f;
    private float originalTimeRemaining = 3f;
    private bool timerIsRunning = false;


    //public Color emissionColor = Color.blue; // Set the color you want for emission
    //private float emissionIntensity = 1f; // Set the intensity of emission when it's turned on
    //private bool emissionOn = false;


    private float pulseSpeed = 1.0f; // Adjust the speed of the pulse
    private float minScale = 0.98f; // Minimum scale of the object
    private float maxScale = 1.02f; // Maximum scale of the object
    private Vector3 baseScale;

    public void SwitchScene()
    {
        // check the tag of the GameObject this script is attached 
        /*
        if (gameObject.tag == "MAIN")
        {
            // Load the scene by its name
            SceneManager.LoadScene("Main");
        }
        */

        if (gameObject.tag == "CANVAS_1")
        {
            // Load the scene by its name
            SceneManager.LoadScene("CANVAS_1");
        }

        else if (gameObject.tag == "CANVAS_2")
        {
            // Load the scene by its name
            SceneManager.LoadScene("CANVAS_2");
        }

        else if (gameObject.tag == "CANVAS_3")
        {
            // Load the scene by its name
            SceneManager.LoadScene("CANVAS_3");
        }

        else if (gameObject.tag == "CANVAS_4")
        {
            // Load the scene by its name
            SceneManager.LoadScene("CANVAS_4");
        }

        else if (gameObject.tag == "CANVAS_5")
        {
            // Load the scene by its name
            SceneManager.LoadScene("CANVAS_5");
        }

        else if (gameObject.tag == "CANVAS_6")
        {
            // Load the scene by its name
            SceneManager.LoadScene("CANVAS_6");
        }

        else if (gameObject.tag == "CANVAS_7")
        {
            // Load the scene by its name
            SceneManager.LoadScene("CANVAS_7");
        }
    }

    void FixedUpdate()
    {
        // PULSE
        if(timerIsRunning)
        {
            // Calculate the new scale using a sine wave to create the pulsing effect
            float scale = Mathf.Lerp(minScale, maxScale, Mathf.PingPong(Time.time * pulseSpeed, 1.0f));

            transform.localScale = baseScale * scale; // Apply the new scale to the object
        }
    }

    
    void Update()
    {
        // TIMER
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                //Debug.Log(timeRemaining);
            }

            else
            {
                // timer complete
                // stop timer
                timerIsRunning = false;

                // switch scene
                SwitchScene();
            }
        }
    }

    public void StartTimer()
    {
        // start timer
        timerIsRunning = true;

        //colorchange
        SetMaterial(true);
    }

    public void StopTimer()
    {
        // stop timer
        timerIsRunning = false;

        // reset timer
        timeRemaining = originalTimeRemaining;

        // reset size
        transform.localScale = baseScale;

        // color change back
        SetMaterial(false);
    }

/*
    void ToggleEmission(bool enable)
    {
        if (enable)
        {
             _myRenderer.material.EnableKeyword("_EMISSION");
             _myRenderer.material.SetColor("_EmissionColor", emissionColor * emissionIntensity);
        }
        else
        {
             _myRenderer.material.DisableKeyword("_EMISSION");
        }
    }
*/
}

