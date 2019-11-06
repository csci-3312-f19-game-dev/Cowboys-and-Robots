using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Damageable : MonoBehaviour
{
    protected float maxHealth;
    protected float health;
    public bool myTeam;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Death();
        }
    }
    public abstract void Death();
    public bool isEnemy(bool team) { return myTeam != team; }

    public virtual void TakeCavalryDamage(float amt) { TakeDamage(amt); }
    public virtual void TakeLightDamage(float amt) { TakeDamage(amt); }
    public virtual void TakeHeavyDamage(float amt) { TakeDamage(amt); }
}
