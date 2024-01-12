using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class SkipButton : MonoBehaviour
{
    // Reference to the sequence manager or the component controlling the sequence
    public YourSequenceManager sequenceManager;

    private void Start()
    {
        // Ensure the button has a reference to the attached onClick method
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(SkipSequence);
        }
        else
        {
            Debug.LogError("SkipButton script requires a Button component.");
        }
    }

    // Method called when the button is clicked
    private void SkipSequence()
    {
        // Check if the sequence manager is assigned
        if (sequenceManager != null)
        {
            // Call a method in your sequence manager to skip the sequence
            sequenceManager.SkipSequence();
        }
        else
        {
            Debug.LogError("Sequence manager not assigned to the SkipButton script.");
        }
    }
    public class YourSequenceManager : MonoBehaviour
    {
        // ... other variables and methods

        public void SkipSequence()
        {
            // Implement logic to skip or end the sequence
            // For example:
            StopCoroutine("YourSequenceCoroutine"); // Replace with your actual coroutine name
            EndSequence();
        }
        private void EndSequence()
        {
            // Implement logic to clean up or end the sequence
        }
    }
 





}