using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Tower : Damageable
{
    protected float range;
    protected float damage;
    protected float atkRate;
    protected float atkCooldown;
}
