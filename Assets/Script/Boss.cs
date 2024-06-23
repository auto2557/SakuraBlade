using UnityEngine;
using UnityEngine.UI;

public class Boss : Attack
{

    private void Start()
    {
        //Boss HP//
        bossHP = bossMaxHP * healthMultiplier;
        UiMaxHP = bossMaxHP * healthMultiplier;

        double randomCoin = Random.Range(50, 100);
        coin = randomCoin;

        //For find UI//
        GameObject healthSliderObj = GameObject.FindWithTag("HPbar");
        healthSlider = healthSliderObj.GetComponent<Slider>();

        GameObject textHeal = GameObject.FindWithTag("hpCOUNT");
        healthText = textHeal.GetComponent<Text>();

        GameObject Coinui = GameObject.FindWithTag("CoinUI");
        CoinText = Coinui.GetComponent<Text>();

        healthSlider.maxValue = (int)(bossHP);
        healthSlider.value = (int)(bossHP);

        //UI//
        healthText.text = ((int)bossHP).ToString() + "/" + ((int)UiMaxHP).ToString();
    }

    private void Update()
    {
        AttackBoss();
        BossDestroy();
    }

}
