using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : Damageable
{
    protected int moveSpeed;
    protected float range;
    protected float damage;
    protected float atkRate;
    protected float atkCooldown;
}
