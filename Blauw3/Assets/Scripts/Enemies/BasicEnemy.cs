using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : Enemy
{
    private bool startedDeath, isTrueDead;
    private Renderer prefRenderer;
    public override void Attack()
    {
        base.Attack();
        animator.SetBool("Walking", false);
        animator.SetTrigger("Attack");
        int randomAttack = Random.Range(1, 3);
        animator.SetInteger("Attack Number",randomAttack);
        player.GetComponent<Health>().DoDamage(damage);
    }

    public override void Walk()
    {
        animator.SetBool("Walking", true);
    }

    public override void DestroyEnemy()
    {
        if (startedDeath == false)
        {
            deathSound.Play();
            animator.SetTrigger("Dead");
            healthSlider.gameObject.SetActive(false);
            prefRenderer = prefab.GetComponentInChildren<Renderer>();
            prefRenderer.material = new Material(dissolve);
            StartCoroutine(Dissolve());
            StartCoroutine(Die());
            startedDeath = true;
        }
    }

    IEnumerator Dissolve()
    {
        if (prefRenderer.material.GetFloat("Vector1_AF64FB50") < 1)
        {
            prefRenderer.material.SetFloat("Vector1_AF64FB50", prefRenderer.material.GetFloat("Vector1_AF64FB50") + 0.02f);
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
