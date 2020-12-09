using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingEnemy : Enemy
{
    public override void Attack()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, attackRange);
        foreach(var hitCollider in hitColliders)
        {
            if (hitCollider.transform.gameObject.name == "PlayerBody")
            {
                hitCollider.GetComponent<Health>().DoDamage(damage);
            }
        }
        DestroyEnemy(); 
    }
}
