using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : Enemy
{
    public GameObject bulletSpawn, bulletPrefab, currentBullet;
    public float bulletSpeed;
    public override void Attack()
    {
        animator.SetTrigger("Shooting");
        currentBullet = Instantiate(bulletPrefab, bulletSpawn.transform.position, transform.rotation);
        currentBullet.GetComponent<Projectile>().speed = bulletSpeed;
        currentBullet.GetComponent<Projectile>().damage = damage;
    }
}
