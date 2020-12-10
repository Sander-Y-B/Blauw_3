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
}
