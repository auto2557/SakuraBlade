using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : BossHP
{
    public static double Upcost = 100;
    public Button UpdmgButton;

    public virtual void Start()
    {
        UpdmgButton.onClick.AddListener(upgrade);
        GameObject Coinui = GameObject.FindWithTag("CoinUI");
        CoinText = Coinui.GetComponent<Text>();
    }

    public virtual void upgrade()
    {
        if (coinAmount >= Upcost)  
        {
            coinAmount -= Upcost;

            Upcost *= 2;

            CoinText.text = "Coin = " + ((int)coinAmount).ToString();
        }
    }
}
