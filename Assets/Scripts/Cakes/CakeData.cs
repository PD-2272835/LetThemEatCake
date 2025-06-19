using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CakeData", menuName = "CakeData")]
public class CakeData : ScriptableObject
{
    public string typeName;
    public int useCost;
    public int upgradeCost;
    public Sprite sprite;
    
    //hit data
    [SerializeField] private int damage;
    [SerializeField] private float tickPeriod;
    [SerializeField] private int tickDamage;
    [SerializeField] private int tickCount;

    public float[] GetHitData()
    {
        if (tickPeriod > 0f)
        {
            return new float[] { damage, tickPeriod, tickDamage, tickCount };
        } else
        {
            return new float[] { damage };
        }
    }
}
