using UnityEngine;

public class Attack : HP
{
    public static double damagePerClick = 1;



    public virtual void AttackBoss()
    {
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {

                    bossHP -= damagePerClick;
                    healthSlider.value = (int)bossHP;
        CoinText.text = "Coin = " + FormatNumber((int)coinAmount).ToString();
                    healthText.text = FormatNumber((int)bossHP).ToString() + "/" + FormatNumber((int)UiMaxHP).ToString();
                    Debug.Log("HP = " + (float)bossHP);


                }
            }
        }
    }




}
