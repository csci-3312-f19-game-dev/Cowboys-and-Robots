using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class Unit : Damageable
{
    protected string unitLabel;
    protected int moveSpeed;
    protected float range;
    protected float damage;
    protected float atkRate;
    protected float atkCooldown;
    //public GameObject infoPanel;

    TMP_Text[] components;

   

}
