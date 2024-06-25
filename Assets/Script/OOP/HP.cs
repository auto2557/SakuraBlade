using System;
using UnityEngine;

public class HP : spawnrate
{
    public double bossHP;
    public double UiMaxHP;
    public double bossMaxHP = 10;
    public static double healthMultiplier = 1.75;

    public GameObject nextBoss;
    public Transform spawn;

    public virtual void BossDestroy()
    {

        if (bossHP <= 0)
        {
            healthSlider.value = healthSlider.maxValue;

            Destroy(gameObject);

            healthMultiplier *= 1.25;

            coinAmount += coin;
            CoinText.text = "Coin = " + ((int)coinAmount).ToString();

            SpawnPartofKaiju();

            Instantiate(nextBoss, spawn.position, spawn.rotation);

           
        }
    }

    }
