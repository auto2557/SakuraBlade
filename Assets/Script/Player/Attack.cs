using UnityEngine;
using System.Collections;

public class Attack : Movement
{
    public float dmg = 10f;
    protected float cooldownHit = 2f;
    private bool isAttacking = false;

    IEnumerator AttackCoroutine()
    {
        while (isAttacking)
        {
            attackAni(true);
            yield return new WaitForSeconds(0.5f);
            attackAni(false);
            yield return new WaitForSeconds(cooldownHit);
        }
    }

    public void attackAni(bool isAttacking)
    {
        animator.SetBool("Attacking", isAttacking);
    }

    public void autoAttack()
    {
        if (!isAttacking)
        {
            isAttacking = true;
            StartCoroutine(AttackCoroutine());
        }
        else
        {
            isAttacking = false;
            StopCoroutine(AttackCoroutine());
            attackAni(false);
        }
    }
}
