using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newAgressiveWeaponData", menuName = "Data/Weapon Data/Agressive Weapon")]
public class SO_AgressiveWeaponData : SO_WeaponData
{
    [SerializeField] private AttackDetails[] attackDetails;

    public AttackDetails[] AttackDetails { get =>  attackDetails; private set => attackDetails = value;  }

    private void OnEnable()
    {
        amountOfAttacks = attackDetails.Length;

        movementSpeed = new float[amountOfAttacks];

        for (int i = 0; i < amountOfAttacks; i++)
        {
            movementSpeed[i] = attackDetails[i].movementSpeed;
        }
    }
}
