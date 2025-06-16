using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartMenuHandler : MonoBehaviour
{
    [SerializeField] private Scene gameScene;
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private GameObject creditsMenu;

    public void StartGame()
    {
        SceneManager.LoadScene(gameScene.buildIndex);
    }

    public void OptionsMenu()
    {
        optionsMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    public void CreditsMenu()
    {
        creditsMenu.SetActive(true);
        gameObject.SetActive(false);
    }
    
    public void ExitGame()
    {
        Application.Quit();
    }
}
