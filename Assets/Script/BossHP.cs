using System.Buffers.Text;
using UnityEngine;
using UnityEngine.UI;

public class BossHP : MainSystem
{
    public double newHP = 10;
    private Slider healthSlider;

    private void Start()
    {
        GameObject healthSliderObj = GameObject.FindWithTag("HPbar");
        healthSlider = healthSliderObj.GetComponent<Slider>(); // Assign the Slider component

        HP = newHP * healthMultiplier;
        healthSlider.maxValue = (int)(newHP* healthMultiplier);
        healthSlider.value = (int)(newHP* healthMultiplier);
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

                }
            }
        }
    }

    public override void BossDestroy()
    {
        if (HP <= 0)
        {
            // Reset slider
            healthSlider.value = healthSlider.maxValue;

            Destroy(gameObject);
            healthMultiplier *= 1.25;
            Instantiate(nextBoss, spawn.position, spawn.rotation);
        }
    }


}


