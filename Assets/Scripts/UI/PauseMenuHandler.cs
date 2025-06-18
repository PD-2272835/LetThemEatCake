using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;


public class PauseMenuHandler : MonoBehaviour
{
    public GameObject pauseMenu;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && pauseMenu.activeSelf == false)
        {
            //print("Escape key pressed, toggling pause menu.");
            PauseGame();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && pauseMenu.activeSelf == true)
        {
            //print("Return key pressed, resuming game.");
            ResumeGame();
        }
    }


    public void LoadScene(string sceneName)
    {
        //print("Loading Scene: " + sceneName);
        SceneManager.LoadScene(sceneName);
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void OptionsMenu()
    {
        // open options menu
    }

}
