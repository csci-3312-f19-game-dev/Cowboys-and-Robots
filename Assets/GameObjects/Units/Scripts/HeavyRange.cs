using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.UI;

public class HeavyRange : Heavy
{
    public GameObject projectile;

    public AIPath path;
    public AIDestinationSetter dest;

    private List<GameObject> targets;
    public GameObject cbRenderer;
    public GameObject rbRenderer;

    private GameController gc;

    public Slider healthSlider;

    private void Start()
    {
        Debug.Log(infoPanel);
        health = maxHealth = 75;
        damage = 20;
        range = 2.5f;
        atkRate = 1f;
        atkCooldown = atkRate;

        gc = FindObjectOfType<GameController>();

        targets = new List<GameObject>();

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



        Debug.Log(targets.Count);


        for (int i = 0; i < targets.Count; i++)
        {
            if (targets[i] == null)
            {
                targets.RemoveAt(i);
                i--;
            }
        }

        Debug.Log(targets.Count);


        // Pick closest target
        targets.Sort(delegate (GameObject a, GameObject b)
        {
            return (a.transform.position - gameObject.transform.position).magnitude.CompareTo((b.transform.position - gameObject.transform.position).magnitude);
        });

        if (targets.Count > 0)
        {
            dest.target = targets[0].transform;


            Debug.Log((targets[0].transform.position - gameObject.transform.position).magnitude);
            if ((targets[0].transform.position - gameObject.transform.position).magnitude <= range + 0.3)
            {
                if (atkCooldown <= 0)
                {
                    atkCooldown = atkRate;
                    targets[0].GetComponent<Damageable>().TakeDamage(damage);
                    Projectile b = Instantiate(projectile, gameObject.transform).GetComponent<Projectile>();
                    b.to = targets[0].transform;
                    b.from = gameObject.transform;
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
        GameObject tmp = collision.gameObject;
        Debug.Log(tmp.GetComponent<Damageable>());
        if (tmp.GetComponent<Damageable>() != null && tmp.GetComponent<Damageable>().isEnemy(myTeam) && !targets.Contains(tmp)) { targets.Add(tmp); Debug.Log("Detect"); }
    }
}
