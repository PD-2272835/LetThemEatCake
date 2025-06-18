using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class cakeManagerScript : MonoBehaviour
{
    public int cakeBatter = 100;
    public GameObject[] allCakes; //stores the cake projectile prefabs
    public GameObject currentCakePrefab; //current cake prefab
    
    private CakeData _currentCakeData;
    
    
    void Update()
    {
        //prevent hardcoding each input value to a specific cake, so that up to nine cakes can be implemented easily
        if (Input.anyKeyDown)
        {
            //TryParse() here evaluates to 0 if the string provided is not a number/contains other characters
            int.TryParse(Input.inputString, out int keyPressed);
            if (keyPressed == 0)
            {
                return;
            }
            //Check that the number returned by TryParse() is not larger than the number of implemented cakes, to prevent an out of range error,
            //then check that the player has enough batter to throw the cake, preventing them from switching to this cake if not
            else if (keyPressed > allCakes.Length && cakeBatter >= allCakes[keyPressed - 1].GetComponent<CakeProjectile>().type.cost)
            {
                currentCakePrefab = allCakes[keyPressed - 1];
                _currentCakeData = allCakes[keyPressed - 1].GetComponent<CakeProjectile>().type;
                Debug.Log(_currentCakeData.name);
            }
        }
    }

    public void AddBatter(int value) //adds to the cake batter when enemies die
    {
        cakeBatter += value;// * modifier;
    }

    //check that the player has enough batter to throw the current cake - if they do, decrease the batter
    public bool CheckAndDecreaseCakeBatter()
    {
        if (cakeBatter >= _currentCakeData.cost)
        {
            cakeBatter -= _currentCakeData.cost;
            return true;
        }
        return false;
    }
}
