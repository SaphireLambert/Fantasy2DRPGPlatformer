using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newEntityData", menuName = "Data/Entity Data/Base Data")]
public class D_Entity : ScriptableObject
{
    public float maxAgroDistance = 4;
    public float minAgroDistance = 2;

    public float closeRangeActionDistance = 1;

    public LayerMask playerLayerMask; //In series he calls this whatIsPlayer
}
