using System.Buffers.Text;
using UnityEngine;
using UnityEngine.UI;

public class BossHP1 : MainSystem
{
    private double newHP = 10;

    private void Start()
    {
        HP = newHP * healthMultiplier;
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

                    Debug.Log("HP = " + (int)HP);
                   

                }
            }
        }
    }

    public override void BossDestroy()
    {
        if (HP <= 0)
        {
            Destroy(gameObject);
            healthMultiplier *= 1.25;
           
            Instantiate(nextBoss, spawn.position, spawn.rotation);

        }
    }


}


