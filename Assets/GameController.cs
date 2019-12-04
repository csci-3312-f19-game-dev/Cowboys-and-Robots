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
    public int enemyGold;
    public float enemyGps;

    private float gameTimer;

    public GameObject goldUI;

    private int nextEnemy = 0;

    private float moneyTimer = 0;

    public int playerGps;

    private float enemyStartGps = 3.5f;
    private float enemyMaxGps = 12;

    private float scaleStopTime;

    private int playerStartGps = 2;

    public int[] costs = { 10, 15, 25, 15, 25, 30, 12, 17, 30 };

    private void Start()
    {
        money = 30;
        enemyGold = 10;
        playerGps = playerStartGps;
        enemyGps = enemyStartGps;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        goldUI.GetComponent<TextMeshProUGUI>().text = money.ToString();


        if (enemyGold >= costs[nextEnemy])
        {
            enemyGold -= costs[nextEnemy];
            GameObject u//;
            /*u*/ = Instantiate(prefabs[nextEnemy], enemyBase.transform);
            u.GetComponent<Damageable>().myTeam = false;
            nextEnemy = Random.Range(0, 9);
        }

        if (moneyTimer <= 0)
        {
            moneyTimer = 1f;
            money += playerGps;
            enemyGold += (int)enemyGps;
        } else
        {
            moneyTimer -= Time.fixedDeltaTime;
        }
        if (gameTimer < 5 * 60)
        {
            enemyGps += (enemyMaxGps - enemyStartGps) / (5 * 60) * Time.fixedDeltaTime;
        }
        gameTimer += Time.fixedDeltaTime;
    }


    public void SpawnUnit(int which)
    {

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
