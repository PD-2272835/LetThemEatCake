using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawning : MonoBehaviour
{
    public delegate void OnEnemyDeath(Enemy_Parent enemy);

    private OnEnemyDeath _enemyDeath;
    
    private Vector2 _originPoint;
    public int width;
    public int height;
    private float _maxHorizontalBounds;
    private float _maxVerticalBounds;
    
    [SerializeField] private List<WaveObject> waves;
    private List<Enemy_Parent> _enemiesAlive;
    private int _currentWaveIndex;
    private int _wavesCount;
    private float _currentWaveTimer;

    private void OnEnable()
    {
        EventManager.OnEnemyDied += EventManagerEnemyDeath;
    }

    private void OnDisable()
    {
        EventManager.OnEnemyDied -= EventManagerEnemyDeath;
    }

    private void EventManagerEnemyDeath(Enemy_Parent enemy)
    {
        _enemiesAlive.Remove(enemy);
        print(enemy.name);
        print("Enemy has died event fired");
    }
    
    void Start()
    {
        _wavesCount = waves.Count;
        InitialiseSpawnArea();
        DrawDebugBox(10);
        SpawnNextWave();
    }

    private void Update()
    {
       CheckNextWaveConditions();
    }


    private List<Vector2> GetSpawnPoints(int enemyCount)
    {
        List<Vector2> spawnPoints = new List<Vector2>();
        //loop through giving a spawn point for each enemy
        for (int i = 0; i < enemyCount; i++)
        {
            //uses random range with the previous bounds established to pick a point within the box
            spawnPoints.Add(new Vector2(Random.Range(_originPoint.x , _maxHorizontalBounds), Random.Range(_originPoint.y , _maxVerticalBounds)));
        }
        return spawnPoints;
    }

    private void SpawnNextWave()
    {
            Debug.Log("Spawning wave" + _currentWaveIndex);
            WaveObject currentWave = waves[_currentWaveIndex];
            int enemyCount = currentWave.enemies.Count;
            List<Vector2> spawnPoints = GetSpawnPoints(enemyCount);
            for (int i = 0; i < enemyCount; i++)
            {
                Instantiate(currentWave.enemies[i], spawnPoints[i], Quaternion.identity);
                _enemiesAlive.Add(currentWave.enemies[i]);
                print(spawnPoints[i]);
                Debug.DrawLine(new Vector3(spawnPoints[i].x , spawnPoints[i].y, 0), new Vector3(spawnPoints[i].x + .2f, spawnPoints[i].y, 0), Color.green, 3f);
            }
            _currentWaveTimer = currentWave.nextWaveDelayTimer;
    }

    private void CheckNextWaveConditions()
    {
        _currentWaveTimer -= Time.deltaTime;
        if (_currentWaveTimer <= 0 || _enemiesAlive.Count == 0)
        {
            if (_currentWaveIndex != _wavesCount)
            {
                _currentWaveIndex++;
                SpawnNextWave();
            }
        }
    }

    public bool CheckForProtector()
    {
        foreach (var enemy in _enemiesAlive)
        {
            if (enemy.name == "Protector")
            {
                return true;
            }
        }
        return false;
    }

   

    private void DrawDebugBox(int drawDuration)
    {
        //DRAW DEBUG BOX :3c
        //Bottom Left to Bottom Right
        Debug.DrawLine(new Vector3(_originPoint.x, _originPoint.y, 0), new Vector3(_maxHorizontalBounds, _originPoint.y, 0), Color.red, drawDuration);
        //Top Left to Top Right
        Debug.DrawLine(new Vector3(_originPoint.x, _maxVerticalBounds, 0), new Vector3(_maxHorizontalBounds, _maxVerticalBounds, 0), Color.red, drawDuration);
        //Bottom Left to Top Left
        Debug.DrawLine(new Vector3(_originPoint.x, _originPoint.y, 0), new Vector3(_originPoint.x, _maxVerticalBounds, 0), Color.red, drawDuration);
        //Bottom Right to Top Right
        Debug.DrawLine(new Vector3(_maxHorizontalBounds, _originPoint.y, 0), new Vector3(_maxHorizontalBounds, _maxVerticalBounds, 0), Color.red, drawDuration);
    }

    private void InitialiseSpawnArea()
    {
        //Declare Origin Point
        _originPoint = transform.position;
        //Establish the bounds of the spawn box
        _maxHorizontalBounds = _originPoint.x + width;
        _maxVerticalBounds = _originPoint.y + height;
    }
}
