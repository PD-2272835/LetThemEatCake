using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class SlotHandler : MonoBehaviour
{
    private GameStateManager _gameStateManager;
    [SerializeField] private GameObject slotPrefab;

    public List<ItemSlot> slots;
    
    void OnEnable()
    {
        EventManager.OnUpgrade += OnUpgrade;
    }

    void OnDisable()
    {
        EventManager.OnUpgrade -= OnUpgrade;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        _gameStateManager = GameObject.FindGameObjectsWithTag("GameStateManager")[0].GetComponent<GameStateManager>();
        
        for (int i = 0; i < _gameStateManager.allCakes.Length; i++)
        {
            slots.Add(Instantiate(slotPrefab, transform).GetComponent<ItemSlot>());
            slots[i].Initialize(_gameStateManager.allCakes[i]);
        }
        
        slots[0].Unlock();
        Debug.Log(slots[1]._heldCake.name);
        slots[1].NextToUnlock();
    }


    
    //Shitty Stupid Fucking Race Condition Hack Fix
    void OnUpgrade()
    {
        StartCoroutine(RaceConditionFix(0.1f));
    }

    IEnumerator RaceConditionFix(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        if (_gameStateManager.GetProgression() < slots.Count)
        {
            slots[_gameStateManager.GetProgression() - 1].Unlock();
            slots[_gameStateManager.GetProgression()].NextToUnlock();
        }
        else
        {
            slots[_gameStateManager.GetProgression() - 1].Unlock();
        }
    }
}
