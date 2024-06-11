using System.Buffers.Text;
using UnityEngine;
using UnityEngine.UI;

public class BossHP : BossSystem
{
    public double newHP = 10;
    public double MaxHP;
    private Slider healthSlider;
    private Text healthText;

    private void Start()
    {
        GameObject healthSliderObj = GameObject.FindWithTag("HPbar");
        healthSlider = healthSliderObj.GetComponent<Slider>();
        GameObject textHeal = GameObject.FindWithTag("hpCOUNT");
        healthText = textHeal.GetComponent<Text>();

        HP = newHP * healthMultiplier;
        MaxHP = newHP * healthMultiplier;
        healthSlider.maxValue = (int)(newHP* healthMultiplier);
        healthSlider.value = (int)(newHP* healthMultiplier);

        healthText.text = ((int)HP).ToString() + "/" + ((int)MaxHP).ToString();
    }

    public override void AttackBoss()
    {
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {

                    HP -= damagePerClick;

                    Debug.Log("HP = " + (float)HP);
                    healthSlider.value = (int)HP;
                    healthText.text = ((int)HP).ToString() + "/" + ((int)MaxHP).ToString();
                }
            }
        }
    }

    public override void BossDestroy()
    {
        if (HP <= 0)
        {
        
            healthSlider.value = healthSlider.maxValue;

            Destroy(gameObject);
            healthMultiplier *= 1.25;
            Instantiate(nextBoss, spawn.position, spawn.rotation);
        }
    }


}


