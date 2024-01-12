using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Hide the cursor when the cutscene starts
        Cursor.visible = false;
        // Lock the cursor to the center of the screen to prevent it from moving
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // Your cutscene logic goes here

        // Example: If the cutscene is finished, show the cursor again
        
    }

    // Function to show the cursor
    
}