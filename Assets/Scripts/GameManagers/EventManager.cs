using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventManager
{
    public static event Action<Enemy_Parent> OnEnemyDied;
    public static void EnemyDied(Enemy_Parent enemy)
    {
        OnEnemyDied?.Invoke(enemy);
    }

    
    public static event Action<bool> OnSetMovementState;
    public static void SetMovementState(bool state)
    {
        OnSetMovementState?.Invoke(state);
    }
    
    
    public static event Action<CakeData> OnUpdateCake;
    public static void UpdateCake(CakeData cake)
    {
        OnUpdateCake?.Invoke(cake);
    }

    
    public static event Action isProtectorAlive;
    public static void CheckForIfProtectorAlive()
    {
        isProtectorAlive?.Invoke();
    }

    
    public static event Action<bool> UpdateProtectorInEnemy;
    public static void UpdateProtectorInEnemyFunction(bool state)
    {
        UpdateProtectorInEnemy?.Invoke(state);
    }
    
    
    public static event Action OnUpgrade;
    public static void Upgrade()
    {
        OnUpgrade?.Invoke();
    }

    
    public static event Action OnGameOver;
    public static void GameOver()
    {
        OnGameOver?.Invoke();
    }
    
    
    public static event Action OnGamePause;
    public static void GamePause()
    {
        OnGamePause?.Invoke();
    }

    public static event Action OnGameRestart;
    public static void RestartGame()
    {
        OnGameRestart?.Invoke();
    }

    public static event Action<int> OnUpdateBatterValue;

    public static void UpdateBatterValue(int value)
    {
        OnUpdateBatterValue?.Invoke(value);
    }
    
    public static event Action OnBustKilled;
    public static void BustKilled()
    {
        OnBustKilled?.Invoke();
    }

}
