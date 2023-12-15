using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoading : MonoBehaviour
{
    [SerializeField]
    private Image progressbar;
    // Start is called before the first frame update
    void Start()
    {
        //start Async operation
        StartCoroutine(LoadAsyncOperation());   

    }

    IEnumerator LoadAsyncOperation() 
    {
        //create an Async operation
        AsyncOperation gamelevel = SceneManager.LoadSceneAsync("Controls");

        while (gamelevel.progress < 1)
        {
            // take the progress bar = Async operation progress
            progressbar.fillAmount = gamelevel.progress;
            yield return new WaitForEndOfFrame();
        }



        //when finished load gamescene
        
    }
}
