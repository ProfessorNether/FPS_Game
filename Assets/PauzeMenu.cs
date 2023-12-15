using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauzeMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Tab))
        {
            if (isPaused)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                ResumeGame();
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f; // Stop time (pause the game)
        isPaused = true;
        // Add code to pause sounds if necessary
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f; // Resume time (unpause the game)
        isPaused = false;
        // Add code to resume sounds if necessary
    }

    public void GoToMainMenu()
    {
        // Add any necessary code for pausing or cleaning up before going to the main menu
        Time.timeScale = 1f; // Reset time scale
        SceneManager.LoadScene("MainMenu"); // Replace main menu scene
        isPaused = false;
    }

    public void RestartLevel()
    {
        // Add any necessary code for pausing or cleaning up before going to the main menu
        Time.timeScale = 1f; // Reset time scale
        SceneManager.LoadScene("Controls"); // Replace main menu scene
        isPaused = false;
    }
}
