using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newEnemyIdleData", menuName = "Data/Enemy Data/Idle Data")]
public class D_EnemyIdleState : ScriptableObject
{
    public float minIdleTime;
    public float maxIdleTime;
}
