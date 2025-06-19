using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
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
            PauseGame();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && pauseMenu.activeSelf == true)
        {
            ResumeGame();
        }
    }


    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void PauseGame()
    {
        EventManager.GamePause(); // Trigger the Game Pause event
        pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        EventManager.GamePause(); // Trigger the Game Pause event to resume (if time scale is 0, set it to 1)
        pauseMenu.SetActive(false);
    }

    public void OptionsMenu()
    {
        // open options menu
    }
}
