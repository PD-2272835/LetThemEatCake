using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class StartMenuHandler : MonoBehaviour
{
    [SerializeField] private Scene gameScene;
    private GameObject parentCanvas;
    //private GameObject 
    
    void Start()
    {
        parentCanvas = gameObject.transform.parent.gameObject; //get a cool lil ol reference
    }

    public void StartGame()
    {
        SceneManager.LoadScene(gameScene.buildIndex);
    }

    public void OptionsMenu()
    {
        gameObject.SetActive(false);

    }

    public void CreditsMenu()
    {
        gameObject.SetActive(false);
    }
    
    public void ExitGame()
    {
        Application.Quit();
    }
}
