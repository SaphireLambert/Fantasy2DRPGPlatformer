using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newEnemyChargeData", menuName = "Data/Enemy Data/Charge Data")]
public class D_EnemyChargeState : ScriptableObject
{
    public float chargeSpeed = 6f;

    public float chargeTime = 2f;
}
