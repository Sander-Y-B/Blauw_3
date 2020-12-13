using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : Enemy
{
    public GameObject bulletSpawn, bulletPrefab, currentBullet;
    public float bulletSpeed;
    private bool isTrueDead;
    public GameObject bottom;
    public override void Attack()
    {
        animator.SetTrigger("Shooting");
        currentBullet = Instantiate(bulletPrefab, bulletSpawn.transform.position, transform.rotation);
        currentBullet.GetComponent<Projectile>().speed = bulletSpeed;
        currentBullet.GetComponent<Projectile>().damage = damage;
    }
    public override void Walk()
    {
        animator.SetBool("Walking", true);
    }
    public override void DestroyEnemy()
    {
        animator.SetTrigger("Dead");
        healthSlider.gameObject.SetActive(false);
        prefab.GetComponentInChildren<Renderer>().material = dissolve;
        bottom.GetComponent<Renderer>().material = dissolve;
        StartCoroutine(Dissolve());
        StartCoroutine(Die());
    }

    IEnumerator Dissolve()
    {
        if (dissolve.GetFloat("Vector1_AF64FB50") < 1)
        {
            dissolve.SetFloat("Vector1_AF64FB50", dissolve.GetFloat("Vector1_AF64FB50") + 0.02f);
            yield return new WaitForSeconds(0.05f);
            StartCoroutine(Dissolve());
        }
        else if (isTrueDead == true)
        {
                base.DestroyEnemy();
                dissolve.SetFloat("Vector1_AF64FB50", 0);
                isTrueDead = false;
        }
    }
    IEnumerator Die()
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorClipInfo(0)[0].clip.length);
        isTrueDead = true;
    }
}
