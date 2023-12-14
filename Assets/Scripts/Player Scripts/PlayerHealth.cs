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

    void Start()
    {
        
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
        cameraRotationScript = GetComponentInChildren<CameraRotation>();

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
                cameraRotationScript.OnPanelOpened();
                panelOpened = true;  // Set the flag to true to prevent repeated opening
                panel.SetActive(true);
                playerMovementScript.SetPlayerMovementEnabled(false);
                
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
