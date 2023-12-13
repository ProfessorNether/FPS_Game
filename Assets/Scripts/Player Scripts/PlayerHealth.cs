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


    void Start()
    {
        
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
      
}
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            TakeDamage(10);
        
        }

        if (currentHealth <= 0.01f && !panelOpened)
        {
            Debug.Log("IT FUCKING FUCKING WORKS!");
            if (panel != null)
            {
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
