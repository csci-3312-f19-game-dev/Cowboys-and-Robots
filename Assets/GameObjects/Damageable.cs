using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Damageable : MonoBehaviour
{
    protected int health;
    bool isCowboy;

    public abstract void TakeDamage(int amount);
}
