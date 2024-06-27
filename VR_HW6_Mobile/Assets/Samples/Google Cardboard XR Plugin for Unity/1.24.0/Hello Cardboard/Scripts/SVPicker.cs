using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls Saturation and Value via rotation of the headset.
/// </summary>
public class SVPicker : MonoBehaviour
{
    private Quaternion initialRotation; // Initial rotation of the phone/mobile VR headset
    private Quaternion gyroRotation; // Current rotation

    public GameObject testObject;

    void Start()
    {
        // Enable the gyroscope
        Input.gyro.enabled = true;

        // Get the initial rotation of the device
        initialRotation = Input.gyro.attitude;

        // Optionally, log the initial rotation to the console
        Debug.Log("Initial Device Rotation: " + initialRotation.eulerAngles);
    }

    void Update()
    {
        // Get the current rotation of the device
        gyroRotation = Input.gyro.attitude;

        // Adjust the rotation to match Unity's coordinate system
        Quaternion adjustedRotation = new Quaternion(
            gyroRotation.x,
            gyroRotation.y,
            -gyroRotation.z,
            -gyroRotation.w);

        // Apply the adjusted rotation to the GameObject
        testObject.transform.localRotation = adjustedRotation;
    }
}
