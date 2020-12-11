using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : Enemy
{
    public override void Attack()
    {
        animator.SetBool("Walking", false);
        player.GetComponent<Health>().DoDamage(damage);
    }

    public override void Walk()
    {
        animator.SetBool("Walking", true);
    }

    public override void DestroyEnemy()
    {
        animator.SetTrigger("Dead");
        StartCoroutine(Die());
    }
    IEnumerator Die()
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorClipInfo(0)[0].clip.length);
        base.DestroyEnemy();
    }
}
