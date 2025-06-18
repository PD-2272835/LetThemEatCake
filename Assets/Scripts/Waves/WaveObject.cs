using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave Object", menuName = "Wave Object")]
public class WaveObject : ScriptableObject
{
    public List<Enemy_Parent> enemies;
    public int waveBatterReward;
    public int nextWaveDelayTimer;
}
