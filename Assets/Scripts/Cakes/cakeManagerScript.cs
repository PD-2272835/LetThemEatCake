using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cakeManagerScript : MonoBehaviour
{
    public int cakeBatter = 100;
    public int currentCake = 1;
    public int modifier = 1;
    public GameObject currentprefab;
    public GameObject[] cakeprefabs; //stores the prefabs

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //checks for an input and sets the current cake to it
        if (Input.GetKeyDown("1"))
        {
            currentCake = 1;
            Debug.Log("1");
        }
        else if (Input.GetKeyDown("2"))
        {
            currentCake = 2;
            Debug.Log("2");
        }
        else if (Input.GetKeyDown("3"))
        {
            currentCake = 3;
            Debug.Log("3");
        }

        currentprefab = cakeprefabs[currentCake-1];

    }

    public void addToBatter(int value) //adds to the cake batter when enemies die
    {
        cakeBatter += value * modifier;
    }
}
