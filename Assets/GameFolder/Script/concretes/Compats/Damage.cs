using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    // zararı verecek script
    [SerializeField] int damage;
    public int HitDamage => damage;
    public void HitTarget(Health health)
    {
        health.TakeHit(this);
    }
}
