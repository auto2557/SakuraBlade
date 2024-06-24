using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class UPDAMAGE : Attack
{
    
    [SerializeField] public static double Upcost = 100;
    [SerializeField] public Button UpdmgButton;


    private void Start()
    {
        UpdmgButton.onClick.AddListener(upgrade);
        GameObject Coinui = GameObject.FindWithTag("CoinUI");
        CoinText = Coinui.GetComponent<Text>();

    }
    private void upgrade()
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