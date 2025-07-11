using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CakeSelectionManager : MonoBehaviour
{
    private CakeData _prospectedCake;

    public ThrowCake checkState;

    void Awake()
    {
        checkState = gameObject.GetComponent<ThrowCake>();
    }

    
    void Update()
    {
        if (checkState.intstate == 1)
        {
            //prevent hardcoding each input value to a specific cake, so that up to nine cakes can be implemented easily
            if (Input.anyKeyDown)
            {
                //TryParse() here evaluates to 0 if the string provided is not a number/contains other characters
                int.TryParse(Input.inputString, out int keyPressed);

                //Check that the number returned by TryParse() is not larger than the number of implemented cakes, to prevent an out of range error,
                //then check that the player has enough batter to throw the cake, preventing them from switching to this cake if not
                if (keyPressed != 0 && keyPressed <= GameStateManager.Instance.allCakes.Length)
                {
                    _prospectedCake = GameStateManager.Instance.allCakes[keyPressed - 1];
                    
                    //if the cake selected is equal to the next progression value, and we have enough batter, upgrade
                    if (keyPressed == GameStateManager.Instance.GetProgression() + 1)
                    {
                        if(GameStateManager.Instance.CheckBatter(_prospectedCake.upgradeCost))
                        {
                            EventManager.Upgrade();
                            EventManager.UpdateCake(_prospectedCake);
                        }
                        else
                        {
                            _prospectedCake = GameStateManager.Instance.allCakes[0];
                        }
                    }
                    else if (keyPressed >= GameStateManager.Instance.GetProgression() + 1)
                    {
                        _prospectedCake = GameStateManager.Instance.allCakes[0];
                    }

                    EventManager.UpdateCake(_prospectedCake);
                    Debug.Log(GameStateManager.Instance.GetCurrentCake().name + " selected");
                }
            }
        }
    }
}
