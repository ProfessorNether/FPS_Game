using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlagueWood()
    {
        SceneManager.LoadScene("Controls");
    }

    public void Main_Menu()
    {
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

    public void Quit_Game()
    {
        Application.Quit();
    }
}
