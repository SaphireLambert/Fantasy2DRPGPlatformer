using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
/// <summary>
/// This is a scriptable object containing the data needed for the Detect player state for the enemies. 
/// </summary>

[CreateAssetMenu(fileName = "newEnemyDetectPlayerData", menuName = "Data/Enemy Data/Detect Player Data")]
public class D_EnemyDetectPlayer : ScriptableObject
{
    public float longRangeActionTime = 1.5f;
}
