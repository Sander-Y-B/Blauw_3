using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : Enemy
{
    public override void Attack()
    {
        player.GetComponent<Health>().DoDamage(damage);
    }
}
