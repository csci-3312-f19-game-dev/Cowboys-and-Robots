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
    public GameObject infoPanel;

    TMP_Text[] components;


    public void OnMouseDown()
    {

      /* GameObject clone = Instantiate(infoPanel, gameObject.transform);
        GameObject parent = GameObject.Find("GameMessages");
        clone.transform.parent = parent.transform;
        components = infoPanel.GetComponentsInChildren<TMP_Text>();
        Image[] background = infoPanel.GetComponentsInChildren<Image>();
        if (myTeam) { background[1].color = new Color(146, 152, 117); }
        else { background[1].color = new Color(0, 0, 0); }

        //NAME OF THE UNIT
        components[1].text = unitLabel;
        //MOVESPEED OF THE UNIT
        components[3].text = moveSpeed.ToString();
        //RANGE OF THE UNIT
        components[5].text = range.ToString();
        //DAMAGE OF THE UNIT
        components[7].text = damage.ToString();
        //ATTACK SPEED OF THE UNIT
        components[9].text = atkRate.ToString();
        //HEALTH OF THE UNIT
        components[11].text = health.ToString();
    }

    private void Update()
    {
        //components[11].text = health.ToString();
    */
    }

   

}
