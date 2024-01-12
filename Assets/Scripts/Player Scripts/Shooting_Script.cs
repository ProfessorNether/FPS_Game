using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shooting_Script : MonoBehaviour
{
    public Camera Cam;
    public GameObject panel;
    public bool panelOpened = false;

    private RaycastHit hit;
    private Ray ray;
    private int deathCount;
    private int remainingEnemies = 20;

    public AudioSource clickSound;
    public AudioSource VictorySound;
    public AudioSource[] npcHitSounds;
    public PauzeMenu menu;
    public TextMeshProUGUI enemyCounterText;

    private CameraRotation cameraRotationScript;
    private playerMovement playerMovementScript;

    void Start()
    {
        playerMovementScript = GetComponent<playerMovement>();
        cameraRotationScript = GetComponentInChildren<CameraRotation>();

        // You don't need to find the audio sources if they are assigned in the inspector.
        // Remove the following lines if audio sources are assigned in the inspector.
        clickSound = GameObject.Find("Crossbow Sound").GetComponent<AudioSource>();
        VictorySound = GameObject.Find("Winning Sound").GetComponent<AudioSource>();
        npcHitSounds = new AudioSource[3];
        for (int i = 0; i < 3; i++)
        {
            npcHitSounds[i] = GameObject.Find("NPC Hit Sound " + (i + 1)).GetComponent<AudioSource>();
        }
    }

    void Update()
    {
        if (!PauzeMenu.isPaused)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (!panelOpened && clickSound != null && clickSound.enabled)
                {
                    clickSound.Play();
                }
                ray = Cam.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.CompareTag("NPC")) // Use CompareTag for performance
                    {
                        remainingEnemies--;
                        UpdateEnemyCounter();
                        deathCount++;
                        Destroy(hit.collider.gameObject);

                        int randomIndex = Random.Range(0, npcHitSounds.Length);
                        if (npcHitSounds[randomIndex] != null)
                        {
                            npcHitSounds[randomIndex].Play();
                        }

                        if (remainingEnemies <= 0)
                        {
                            HandleGameWin();
                        }
                    }
                }
            }
        }
    }

    void HandleGameWin()
    {
        if (panel != null)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0f;
            VictorySound.Play();
            panelOpened = true;
            panel.SetActive(true);
            playerMovementScript.SetPlayerMovementEnabled(false);
            //cameraRotationScript.OnPanelOpened();
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void ClosePanel()
    {
        panelOpened = false;
        cameraRotationScript.OnPanelClosed();
    }

    void UpdateEnemyCounter()
    {
        if (enemyCounterText != null)
        {
            enemyCounterText.text = "Enemies Remaining: " + remainingEnemies;
        }
    }

    public bool IsPanelOpened()
    {
        return panelOpened;
    }

    public void DisableClickSound()
    {
        if (clickSound != null)
        {
            clickSound.enabled = false;
        }
    }
}
