using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.UI;
using TMPro;

public class CavalryMelee : Cavalry
{
    public AIPath path;
    public AIDestinationSetter dest;

    private List<Damageable> targets;
    public GameObject cbRenderer;
    public GameObject rbRenderer;

    private GameController gc;

    public Slider healthSlider;

    private void Start()
    {
        health = maxHealth = 120;
        damage = 15;
        range = 0.4f;
        atkRate = 0.75f;
        atkCooldown = atkRate;

        gc = FindObjectOfType<GameController>();

        targets = new List<Damageable>();

        if (myTeam)
        {
            rbRenderer.GetComponent<SpriteRenderer>().enabled = false;
            dest.target = gc.enemyBase.transform;
        }
        else
        {
            cbRenderer.GetComponent<SpriteRenderer>().enabled = false;
            dest.target = gc.playerBase.transform;
        }



    }

    public override void Death()
    {
        // explode
        Destroy(gameObject);
    }

    public void FixedUpdate()
    {
        healthSlider.value = (float)health / maxHealth;

        for (int i = 0; i < targets.Count; i++)
        {
            if (targets[i] == null)
            {
                targets.RemoveAt(i);
                i--;
            }
        }


        // Pick closest target
        targets.Sort(delegate (Damageable a, Damageable b)
        {
            return ((a.transform.position - gameObject.transform.position).magnitude.CompareTo((b.transform.position - gameObject.transform.position).magnitude));
        });

        if (targets.Count > 0)
        {
            dest.target = targets[0].transform;

            if ((targets[0].transform.position - gameObject.transform.position).magnitude <= range+0.25)
            {
                if (atkCooldown <= 0)
                {
                    atkCooldown = atkRate;
                    targets[0].TakeCavalryDamage(damage);
                }
            }
        }
        else
        {
            if (myTeam)
            {
                dest.target = gc.enemyBase.transform;
            }
            else
            {
                dest.target = gc.playerBase.transform;
            }
        }

        // Reset attack timer
        if (atkCooldown >= 0)
        {
            atkCooldown -= Time.fixedDeltaTime;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Detect");
        Damageable tmp = collision.gameObject.GetComponent<Damageable>();
        if (tmp != null && tmp.isEnemy(myTeam) && !targets.Contains(tmp)) { targets.Add(tmp); }
    }
}
