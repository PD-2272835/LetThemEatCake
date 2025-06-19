using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlot : MonoBehaviour
{
    private CakeData heldCake;

    enum State
    {
        Locked,
        Unlocked,
        Selected
    }

    void Initialize(CakeData _cakeData)
    {
        heldCake = _cakeData;
    }

    void Unlock()
    {
        
    }
}
