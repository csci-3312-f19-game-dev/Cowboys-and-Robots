using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{

    public bool enemyActive;
    public GameObject[] prefabs;

    public GameObject playerBase;
    public GameObject enemyBase;

    public int money;
    public GameObject goldUI;

    private void Start()
    {
        money = 999999;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("f"))
        {
            enemyActive = !enemyActive;
        }
        goldUI.GetComponent<TextMeshProUGUI>().text = money.ToString();
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
