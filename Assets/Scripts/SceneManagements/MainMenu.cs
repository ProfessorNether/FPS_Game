using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartLoadingScreenWithDelay()
    {
        // Start the LoadingScreen coroutine after 3 seconds
        StartCoroutine(LoadingScreenWithDelay(1.0f));
    }

    public IEnumerator LoadingScreenWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Loading Screen");
    }

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
