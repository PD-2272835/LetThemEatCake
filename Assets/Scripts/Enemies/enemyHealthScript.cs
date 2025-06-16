using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealthScript : MonoBehaviour
{
    public int health = 30;
    public int count = 0;
    public int value = 1;
    public cakeManagerScript cakemanagerscript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if the enemy dies
        if (health <= 0)
        {
            Debug.Log("dead");
            cakemanagerscript.addToBatter(value); //adds to the cake batter when enemies die
            Destroy(this.gameObject);
        }
    }

    public void startDOT() //to be called by the spicy cake
    {
        StartCoroutine(DOT());
    }

    IEnumerator DOT() //deals damage over time for 3 times
    {
        yield return new WaitForSeconds(3f); //every 3 seconds
        health -= 5;

        count++;
        if (count < 3)
        {
            StartCoroutine(DOT());
        }
        else
        {
            count = 0;
        }
    }
}
