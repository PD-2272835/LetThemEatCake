using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//A collection of public methods that can be configured in the inspector
public class MainMenuHandler : MonoBehaviour
{
    [SerializeField] private GameObject _currentPage; //make sure to pass in the first page before runtime otherwise there will be a nullreference exception
    
    //Pass in the top level canvas panel for the menu page you want to open
    public void SwapPage(GameObject newPage)
    {
        newPage.SetActive(true);
        _currentPage.SetActive(false);
        _currentPage = newPage;
    }
    
    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    
    public void ExitGame()
    {
        Application.Quit();
    }
}
