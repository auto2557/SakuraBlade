using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UpDmg : BossHP
{
    public double Updmgcost = 100;
    public Button UpdmgButton;

    private void Start()
    {
        UpdmgButton.onClick.AddListener(Upgrade);
        GameObject Coinui = GameObject.FindWithTag("CoinUI");
        CoinText = Coinui.GetComponent<Text>();
    }

    public void Upgrade()
    {
        if (coinAmount >= 100) 
        {
            coinAmount -= Updmgcost;
            CoinText.text = "Coin = " + ((int)coinAmount).ToString();
        }
    }
}
