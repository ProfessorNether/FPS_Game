using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting_Script : MonoBehaviour
{
    public Camera Cam;
    public GameObject panel;

    public bool panelOpened = false; // Add this line to declare the public bool

    private RaycastHit hit;
    private Ray ray;
    private int deathCount;
    public AudioSource clickSound;

    private CameraRotation cameraRotationScript;
    private playerMovement playerMovementScript;

    // Start is called before the first frame update
    void Start()
    {
        // Assuming the player movement script is on the same GameObject as this script
        playerMovementScript = GetComponent<playerMovement>();
        cameraRotationScript = GetComponentInChildren<CameraRotation>();
        clickSound = GameObject.Find("Crossbow Sound").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!panelOpened)
            {
                clickSound.Play();
            }
            ray = Cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag.Equals("NPC"))
                {
                    deathCount++;
                    Destroy(hit.collider.gameObject);
                    
                    if (deathCount >= 10)
                    {
                        if (panel != null)
                        {
                            panelOpened = true; // Set panelOpened to true when the panel opens
                            panel.SetActive(true);
                            // Disable player movement when the panel opens
                            playerMovementScript.SetPlayerMovementEnabled(false);

                            // Call OnPanelOpened method in CameraRotationScript
                            cameraRotationScript.OnPanelOpened();
                        }
                        
                    }
                }
            }
        }
    }

    // Call this method when the panel is closed
    public void ClosePanel()
    {
        panelOpened = false;  // Assuming you have a variable like this in your script
        cameraRotationScript.OnPanelClosed();
    }
}