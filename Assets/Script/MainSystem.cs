using UnityEngine;
using UnityEngine.UI;

public class MainSystem : MonoBehaviour
{
    //Damage System//
    protected double HP;
    public double damagePerClick = 1;

    //Spawn System//
    public GameObject nextBoss;
    public Transform spawn;

    //MultipleHP//
    public static double healthMultiplier = 1.75;



    void Update()
    {
        AttackBoss();
        BossDestroy();
    }

    public virtual void AttackBoss()
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

    public virtual void BossDestroy()
    {
        if (HP <= 0)
        {
            Destroy(gameObject);
            healthMultiplier *= 1.25;
            Instantiate(nextBoss, spawn.position, spawn.rotation);
        }
    }
}
