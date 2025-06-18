using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class cakeManagerScript : MonoBehaviour
{
    public int cakeBatter = 100;
    [SerializeField] private CakeData[] _allCakes; //stores all the cakes
    private CakeData _currentCake;
    
    void Update()
    {
        //prevent hardcoding each input value to a specific cake, so that up to nine cakes can be implemented easily
        if (Input.anyKeyDown)
        {
            //TryParse() here evaluates to 0 if the string provided is not a number/contains other characters
            int.TryParse(Input.inputString, out int keyPressed);

            //Check that the number returned by TryParse() is not larger than the number of implemented cakes, to prevent an out of range error,
            //then check that the player has enough batter to throw the cake, preventing them from switching to this cake if not
            if (keyPressed != 0 && keyPressed < _allCakes.Length && cakeBatter >= _allCakes[keyPressed - 1].cost)
            {
                _currentCake = _allCakes[keyPressed - 1];
                EventManager.UpdateCake(_currentCake);
                Debug.Log(_currentCake.name + "selected");
            }
        }
    }
}
