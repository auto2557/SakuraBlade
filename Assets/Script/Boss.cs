using UnityEngine;
using UnityEngine.UI;

public class Boss : SaveLoad
{

    private void Start()
    {
       
        double randomCoin = Random.Range(50, 100);
        coin = randomCoin;


        //For find UI//
        GameObject healthSliderObj = GameObject.FindWithTag("HPbar");
        healthSlider = healthSliderObj.GetComponent<Slider>();

        GameObject textHeal = GameObject.FindWithTag("hpCOUNT");
        healthText = textHeal.GetComponent<Text>();

        GameObject Coinui = GameObject.FindWithTag("CoinUI");
        CoinText = Coinui.GetComponent<Text>();

       
        CoinText.text = "Coin = " + ((int)coinAmount).ToString();

        //LoadGame();

        //Boss HP//
        bossHP = bossMaxHP * healthMultiplier;
        UiMaxHP = bossMaxHP * healthMultiplier;

        healthSlider.maxValue = (int)(bossHP);
        healthSlider.value = (int)(bossHP);

      

        //UI//
        healthText.text = ((int)bossHP).ToString() + "/" + ((int)UiMaxHP).ToString();
        CoinText.text = "Coin = " + ((int)coinAmount).ToString();



    }

    private void Update()
    {
        AttackBoss();
        BossDestroy();
    }

    public override void AttackBoss()
    {
        base.AttackBoss();
        SaveGame();
    }

    public override void BossDestroy()
    {
        if (bossHP <= 0)
        {
            healthSlider.value = healthSlider.maxValue;

            Destroy(gameObject);

            healthMultiplier *= 1.25;

            coinAmount += coin;
            CoinText.text = "Coin = " + ((int)coinAmount).ToString();

            Instantiate(nextBoss, spawn.position, spawn.rotation);

  
            SaveGame();
        }
    }

}
