using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuHandler : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    
    public void SwapPage(GameObject newPage, GameObject previousPage)
    {
        newPage.SetActive(true);
        previousPage.SetActive(false);
    }
}
