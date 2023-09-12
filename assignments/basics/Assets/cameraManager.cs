using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraManager : MonoBehaviour
{
    public Camera fpCam;
    public Camera worldCam;
    // Start is called before the first frame update
    // Sets first person camera as starting camera
    void Start()
    {
        fpCam.enabled = true;
        worldCam.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Camera changes to first person camera with key press 1
        if (Input.GetKey(KeyCode.Alpha1))
        {
            fpCam.enabled = true;
            worldCam.enabled = false;
        }

        // Camera changes to world camera with key press 2
        if (Input.GetKey(KeyCode.Alpha2))
        {
            worldCam.enabled = true;
            fpCam.enabled = false;
        }
    }
}
