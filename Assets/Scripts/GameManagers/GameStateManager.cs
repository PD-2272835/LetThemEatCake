using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    
    public static GameStateManager Instance;

    public int startingBatter = 100;
    public int startingProgression = 1;
    public CakeData[] allCakes;
    
    private int _currentBatter;
    private CakeData _currentCake;

    private int _progressionModifier;
    [SerializeField]private int _progression;

    public GameObject gameOverUIPrefab;
    private GameObject _gameOverUIInstance;
    

    void Start()
    {
        //THIS IS A SINGLETON DO SINGLETON THING
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
            gameObject.tag = "GameStateManager";
        } else
        {
            Destroy(gameObject);
        }
        ResetGame();
    }

    //Bind Events in here
    public void OnEnable()
    {
        EventManager.OnUpdateCake += UpdateCurrentCake;
        EventManager.OnGameOver += GameOver;
        EventManager.OnGamePause += PauseGame;
        EventManager.OnUpgrade += ProgressionUpgrade;
        EventManager.OnUpdateBatterValue += UpdateBatter;
    }

    public void OnDisable()
    {
        EventManager.OnUpdateCake -= UpdateCurrentCake;
        EventManager.OnGameOver -= GameOver; 
        EventManager.OnGamePause -= PauseGame;
        EventManager.OnUpgrade -= ProgressionUpgrade;
    }

    
    void UpdateCurrentCake(CakeData newCake)
    {
        _currentCake = newCake;
    }
    
    public CakeData GetCurrentCake()
    {
        return _currentCake;
    }
    
    //check that the player has enough batter to throw the current cake
    public bool CheckBatter(int batterQuery)
    {
        if (_currentBatter >= batterQuery)
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
    
    public int GetBatter()
    {
        return _currentBatter;
    }
    
    public void ProgressionUpgrade()
    {
        _progression++;
        if (_progression <= allCakes.Length)
        {
            UpdateBatter(-allCakes[_progression].upgradeCost);
        }
    }

    public int GetProgression()
    {
        return _progression;
    }

    void ResetGame()
    {
        _currentBatter = startingBatter;
        _currentCake = allCakes[0];
        _progression = startingProgression;
    }
    
    void GameOver()
    {
        if (_gameOverUIInstance == null)
        {
            _gameOverUIInstance = Instantiate(gameOverUIPrefab);
        }
        else
        {
            _gameOverUIInstance.SetActive(true);
        }
    }

    void PauseGame()
    {
        if (Time.timeScale == 1f)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}
