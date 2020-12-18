using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : Enemy
{
    public GameObject bulletSpawn, bulletPrefab, currentBullet;
    public float bulletSpeed;
    private bool startedDeath, isTrueDead;
    public GameObject bottom;
    private Renderer prefRenderer, botRenderer;
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
        if (startedDeath == false)
        {
        animator.SetTrigger("Dead");
        healthSlider.gameObject.SetActive(false);
        prefRenderer = prefab.GetComponentInChildren<Renderer>();
        botRenderer = bottom.GetComponent<Renderer>();
        prefRenderer.material = new Material(dissolve);
        botRenderer.material = new Material(dissolve);
        StartCoroutine(Dissolve());
        StartCoroutine(Die());
        startedDeath = true;
        }
    }

    IEnumerator Dissolve()
    {
        if (botRenderer.material.GetFloat("Vector1_AF64FB50") < 1)
        {
            prefRenderer.material.SetFloat("Vector1_AF64FB50", prefRenderer.material.GetFloat("Vector1_AF64FB50") + 0.02f);
            botRenderer.material.SetFloat("Vector1_AF64FB50", botRenderer.material.GetFloat("Vector1_AF64FB50") + 0.02f);
            yield return new WaitForSeconds(0.05f);
            StartCoroutine(Dissolve());
        }
        else
        {
                base.DestroyEnemy();
        }
    }
    IEnumerator Die()
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorClipInfo(0)[0].clip.length);
        isTrueDead = true;
    }
}
