using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Base : Damageable
{
    public Slider healthbar;
    void Start()
    {
        health = maxHealth = 1000;
    }
    public void FixedUpdate()
    {
        healthbar.value = (float)health / maxHealth;
    }
    public override void Death()
    {
        // Play explosion

        // Destroy all opposing units

        Invoke("EndGame", 2);
    }
    private void EndGame()
    {
        if (this.myTeam)
        {
            SceneManager.LoadScene("GameOverKendra");
        }
        else
        {
            SceneManager.LoadScene("GameWonKendra");
        }
    }
}
