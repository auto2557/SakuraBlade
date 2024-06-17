using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Updmg : Upgrade
{

    public override void Start()
    {
        UpdmgButton.onClick.AddListener(upgrade);
        GameObject Coinui = GameObject.FindWithTag("CoinUI");
        CoinText = Coinui.GetComponent<Text>();
    }

    public override void upgrade()
    {
        if (coinAmount >= Upcost)
        {
            coinAmount -= Upcost;

            Upcost *= 2;
            damagePerClick *= 2;

            CoinText.text = "Coin = " + ((int)coinAmount).ToString();
        }
    }
}
