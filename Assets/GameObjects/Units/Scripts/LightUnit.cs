using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LightUnit : Unit
{
    public override void TakeCavalryDamage(float amt)
    {
        TakeDamage(amt * 0.6f);
    }
    public override void TakeLightDamage(float amt)
    {
        TakeDamage(amt);
    }
    public override void TakeHeavyDamage(float amt)
    {
        TakeDamage(amt * 1.2f);
    }
}
