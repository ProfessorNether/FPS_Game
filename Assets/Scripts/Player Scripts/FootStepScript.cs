using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepScript : MonoBehaviour
{
    public GameObject footstep;
    public PauzeMenu menu;
    public CharacterController characterController;

    void Start()
    {
        footstep.SetActive(false);
        menu = FindObjectOfType<PauzeMenu>();
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (!PauzeMenu.isPaused && characterController.isGrounded)
        {
            if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
            {
                footsteps();
            }
            else
            {
                StopFootsteps();
            }
        }
        else
        {
            StopFootsteps();
        }
    }

    void footsteps()
    {
        if (!footstep.activeSelf)
        {
            footstep.SetActive(true);
        }
    }

    void StopFootsteps()
    {
        if (footstep.activeSelf)
        {
            footstep.SetActive(false);
        }
    }
}
