using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newEnemyLookForPlayerData", menuName = "Data/Enemy Data/Look For Player Data")]
public class D_EnemyLookForPlayer : ScriptableObject
{
    public int amountOfTurns = 2;
    public float timeBetweenTurns = 0.6f;
}
