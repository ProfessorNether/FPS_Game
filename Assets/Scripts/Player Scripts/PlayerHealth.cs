using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 100;
    public float currentHealth;

    public GameObject panel;
    public HealthBar healthBar;

    public bool panelOpened = false;
    public playerMovement playerMovementScript;
    private CameraRotation cameraRotationScript;
    public AudioSource FailSound;

    void Start()
    {
        
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
        cameraRotationScript = GetComponentInChildren<CameraRotation>();
        FailSound = GameObject.Find("Losing Sound").GetComponent<AudioSource>();

    }
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space)) 
        //{
        //    TakeDamage(10);
        
        //}

        //if the player is on 0 HP open the panel if it is already not openened
        if (currentHealth <= 0.01f && !panelOpened)
        {
            
            if (panel != null)
            {
                Time.timeScale = 0f;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                FailSound.Play();
                if (cameraRotationScript != null)
                {
                    cameraRotationScript.OnPanelOpened();
                }
                
                panelOpened = true;  // Set the flag to true to prevent repeated opening
                panel.SetActive(true);
                playerMovementScript.SetPlayerMovementEnabled(false);

                Shooting_Script shootingScript = GetComponent<Shooting_Script>();
                if (shootingScript != null && !shootingScript.IsPanelOpened())
                {
                    shootingScript.DisableClickSound();
                }
            }
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);

        if (currentHealth > 0.01f)  // Reset the flag when health increases
        {
            panelOpened = false;
        }
    }
}
