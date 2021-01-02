using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingEnemy : Enemy
{
    public GameObject explosionFX;
    public override void Attack()
    {
        base.Attack();
        Instantiate(explosionFX, transform.position, transform.rotation);
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

    public override void DestroyEnemy()
    {
        base.DestroyEnemy();
        Instantiate(explosionFX, transform.position, transform.rotation);
    }
}
