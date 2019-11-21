using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public bool enemyActive;
    public GameObject[] prefabs;

    public GameObject playerBase;
    public GameObject enemyBase;

    public int money;
    public GameObject goldUI;

    private  float nextEnemyTimer = 0;

    private float moneyTimer = 0;



    private void Start()
    {
        money = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        goldUI.GetComponent<TextMeshProUGUI>().text = money.ToString();


        if (nextEnemyTimer <= 0)
        {
            nextEnemyTimer = Random.Range(3.0f, 12.0f);
            GameObject u;
            u = Instantiate(prefabs[Random.Range(0,9)], enemyBase.transform);
            u.GetComponent<Damageable>().myTeam = false;
        } else
        {
            nextEnemyTimer -= Time.fixedDeltaTime;
        }

        if (moneyTimer <= 0)
        {
            moneyTimer = 1f;
            money += 1;
        } else
        {
            moneyTimer -= Time.fixedDeltaTime;
        }
    }


    public void SpawnUnit(int which)
    {
        int[] costs = { 10, 15, 25, 15, 25, 30, 12, 17, 30 };

        if (money >= costs[which])
        {
            InstantiateUnit(which);
            money -= costs[which];
        }
    }

    private void InstantiateUnit(int which)
    {
        GameObject u;
        if (enemyActive)
        {
            u = Instantiate(prefabs[which], enemyBase.transform);
            u.GetComponent<Damageable>().myTeam = false;
        }
        else
        {
            u = Instantiate(prefabs[which], playerBase.transform);
            u.GetComponent<Damageable>().myTeam = true;
        }
    }

}
