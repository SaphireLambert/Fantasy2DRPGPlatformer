using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newEnemyAttackData", menuName = "Data/Enemy Data/Attack Data")]
public class D_MeleeAttackState : ScriptableObject
{
    public float attackRadius = 0.5f;
    public float attackDamage = 10;

    public LayerMask playerLayerMask;
}
