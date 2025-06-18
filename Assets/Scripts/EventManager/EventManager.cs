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
}
