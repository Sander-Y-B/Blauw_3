using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public float maxHealth = 10;
    public float currentHealth = 10;



    public void DoDamage(float dmg)
    {
        if (currentHealth - dmg < 0)
        {
            Death();
        }
        else
        {
            currentHealth = currentHealth - dmg;
        }
        
    }

    public void DoHeal (float heal)
    {
        if (currentHealth + heal > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth = currentHealth + heal;

        }
    }

    void Death()
    {
        print(gameObject + " died");
    }



}
