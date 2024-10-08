using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct AttackDetails
{
    public string attackName;
    public float movementSpeed;
    public float damageAmount;

    public float knockBackStrength;
    public Vector2 knockBackAngle;
}
