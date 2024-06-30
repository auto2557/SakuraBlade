using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Boss : SaveLoad
{
    public static int CountBoss = 1;

    private void Start()
    {
       
        double randomCoin = Random.Range(50, 100);
        coin = randomCoin;



        int rate = Random.Range(1, 100);
        ratedrop = rate;
        int tailrate = Random.Range(1, 2);
        tailspawn = tailrate;
        int hornrate = Random.Range(1, 3);
        hornspawn = hornrate;
        int clawrate = Random.Range(3, 20);
        clawspawn = clawrate;


        //For find UI//
        GameObject healthSliderObj = GameObject.FindWithTag("HPbar");
        healthSlider = healthSliderObj.GetComponent<Slider>();

        GameObject textHeal = GameObject.FindWithTag("hpCOUNT");
        healthText = textHeal.GetComponent<Text>();

        GameObject Coinui = GameObject.FindWithTag("CoinUI");
        CoinText = Coinui.GetComponent<Text>();

        GameObject countBoss = GameObject.FindWithTag("BossCount");
        CountUI = countBoss.GetComponent<Text>();

        GameObject PopupDamage = GameObject.FindWithTag("PopUPDMG");
        pfUIDmg = PopupDamage.GetComponent<TextMeshPro>();



        CoinText.text = "Coin = " + FormatNumber((int)coinAmount).ToString();

        //LoadGame();
        BigBoss();

        //Boss HP//
        bossHP = bossMaxHP * healthMultiplier;
        UiMaxHP = bossMaxHP * healthMultiplier;

       

        if (CountBoss >= 8 && CountBoss < 9)
        {
            bossMaxHP *= 3;
            healthText.text = FormatNumber((int)bossHP).ToString() + "/" + FormatNumber((int)UiMaxHP).ToString();
        }
        else if (CountBoss >= 8 && bossHP <= 0)
        {
            bossMaxHP /= 3;
        }
        else
        {
            healthText.text = FormatNumber((int)bossHP).ToString() + "/" + FormatNumber((int)UiMaxHP).ToString();
        }
        BigBoss();


        healthSlider.maxValue = (int)(bossHP);
        healthSlider.value = (int)(bossHP);
        


        //UI//
        healthText.text = FormatNumber((int)bossHP).ToString() + "/" + FormatNumber((int)UiMaxHP).ToString();
        CoinText.text = "Coin = " + FormatNumber((int)coinAmount).ToString();
        CountUI.text = "Boss" + CountBoss.ToString() + "/8";

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
            CountBoss++;

            healthMultiplier *= 1.25;

            coinAmount += coin;
            CoinText.text = "Coin = " + FormatNumber((int)coinAmount).ToString();

            SpawnPartofKaiju();

            Instantiate(nextBoss, spawn.position, spawn.rotation);

  
            SaveGame();
        }
    }

    private void BigBoss()
    {
        if (CountBoss >= 8 && CountBoss < 9)
        {
            bossMaxHP *= 3;
        }
        else if (CountBoss > 8 && bossHP <= 0)
        {
            CountBoss -= 8;
            bossMaxHP /= 3;
            coinAmount *= 10;
        }

    }

}
