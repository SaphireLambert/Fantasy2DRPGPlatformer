using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class SpikeTrap : CoreComponent
{
    protected Combat Combat { get => combat ??= core.GetCoreComponent<Combat>(); }
    private Combat combat;
    private List<IDamageable> detectedDamageable = new List<IDamageable>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (IDamageable item in detectedDamageable.ToList())
        {
            item.Damage(1000000000f);
        }
    }
    public void AddToDetected(Collider2D collision)
    {
        IDamageable damageable = collision.GetComponent<IDamageable>();

        if (damageable != null)
        {
            detectedDamageable.Add(damageable);
        }
    }
}
