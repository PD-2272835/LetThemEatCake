using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    
    public static GameStateManager instance;

    public int startingBatter = 100;
    public int startingProgressionModifier;
    
    
    private int _currentBatter;
    private CakeData _currentCake;
    private int _progressionModifier;
    
    void Start()
    {
        //THIS IS A SINGLETON DO SINGLETON THING
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        } else
        {
            Destroy(gameObject);
        }
    }

    //Bind Events in here
    public void OnEnable()
    {
        EventManager.OnUpdateCake += UpdateCurrentCake;
        EventManager.OnGameOver += GameOver;
        EventManager.OnGamePause += PauseGame;
    }

    public void OnDisable()
    {
        EventManager.OnUpdateCake -= UpdateCurrentCake;
        EventManager.OnGameOver -= GameOver; 
        EventManager.OnGamePause -= PauseGame;
    }

    
    
    
    void UpdateCurrentCake(CakeData newCake)
    {
        _currentCake = newCake;
    }
    
    //check that the player has enough batter to throw the current cake
    public bool CheckBatter()
    {
        if (_currentBatter >= _currentCake.cost)
        {
            return true;
        }
        return false;
    }
    
    //pass positive to increase batter, pass negative to decrease
    public void UpdateBatter(int batter)
    {
        _currentBatter += batter;
    }
    
    void GameOver()
    {
        throw new NotImplementedException();
    }

    void PauseGame()
    {
        throw new NotImplementedException();
    }
    
    
}
