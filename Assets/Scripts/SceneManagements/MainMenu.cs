using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject optionsScreen;

    //public void Start()
    //{
    //    optionsScreen.SetActive(false);
    //}

    public void LoadingScreenWithDelay()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Loading Screen");
    }

    public void PlagueWood()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Controls");
    }

    public void Main_Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void LevelSelector()
    {
        SceneManager.LoadScene("levelSelect");
    }

    public void GameInfo()
    {
        SceneManager.LoadScene("GameInfo");
    }

    public void MountainLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Mountain Ruins");
    }

    public void Quit_Game()
    {
        Application.Quit();
    }

    //options settings
    public void OpenOptions()
    {
        optionsScreen.SetActive(true);
    }
    public void CloseOptions()
    {
        optionsScreen.SetActive(false);
    }
}
