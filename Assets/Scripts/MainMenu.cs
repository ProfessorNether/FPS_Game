using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Level1()
    {
        SceneManager.LoadScene("Controls");
    }

    public void Main_Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit_Game()
    {
        Application.Quit();
    }
}
