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

    private float enemyStartGps = 1f;
    private float enemyMaxGps = 30f;

    private float scaleStopTime;

    private int playerStartGps = 2;

    private int[] costs = { 10, 15, 25, 10, 25, 30, 12, 17, 30 };

    private int[] economyCosts = { 30, 35, 40, 50, 60, 70, 100, 110, 120, 130, 140, 500 };
    private int[] economyUpgrades = { 1, 1, 1, 1, 1, 1, 2, 3, 4, 4, 4, 100 };
    private int economyIndex = 0;

    public TextMeshProUGUI costButtonText;
    public TextMeshProUGUI incomeText;

    public TextMeshProUGUI gps;

    private bool spawnedFirstDefense = false;
    private bool spawnedSecondDefense = false;

    public AudioSource asc;

    private void Start()
    {
        money = 30;
        enemyGold = 10;
        playerGps = playerStartGps;
        enemyGps = enemyStartGps;

        incomeText.text = economyUpgrades[0].ToString() + " gps";
        costButtonText.text = economyCosts[0].ToString() + " gold";
        gps.text = playerStartGps.ToString();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        goldUI.GetComponent<TextMeshProUGUI>().text = money.ToString();


        if (enemyGold >= costs[nextEnemy])
        {
            enemyGold -= costs[nextEnemy];
            GameObject u = Instantiate(prefabs[nextEnemy], enemyBase.transform);
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
            enemyGps += (enemyMaxGps - enemyStartGps) / (10 * 60) * Time.fixedDeltaTime;
        }

        if (enemyBase.GetComponent<Base>().healthbar.value <= 0.5 && !spawnedFirstDefense)
        {
            enemyBase.GetComponent<Animator>().SetBool("HalfHealth", true);
            for (int i = 0; i < 15; i++)
            {
                Instantiate(prefabs[Random.Range(0, 9)], enemyBase.transform);
            }
            spawnedFirstDefense = true;
        }

        if (enemyBase.GetComponent<Base>().healthbar.value <= 0.25 && !spawnedSecondDefense)
        {
            enemyBase.GetComponent<Animator>().SetBool("QuarterHealth", true);
            for (int i = 0; i < 20; i++)
            {
                Instantiate(prefabs[Random.Range(0, 9)], enemyBase.transform);
            }

            spawnedSecondDefense = true;
        }


        gameTimer += Time.fixedDeltaTime;

    }


    public void SpawnUnit(int which)
    {

        if (money >= costs[which])
        {
            InstantiateUnit(which);
            money -= costs[which];
            asc.Play();
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

    public void upgradeEconomy()
    {
        if (money >= economyCosts[economyIndex])
        {
            playerGps += economyUpgrades[economyIndex];
            money -= economyCosts[economyIndex];
            economyIndex++;

            incomeText.text = economyUpgrades[economyIndex].ToString() + " gps";
            costButtonText.text = economyCosts[economyIndex].ToString() + " gold";
            gps.text = playerGps.ToString();
        }
    }

}
