﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public UIManager uiManager;
    public float maxHealth = 10;
    public float currentHealth = 10;

    [HideInInspector] public SecurityLevel securityLevel;
    [Header("Security Level")]
    public string securityLevelTag;

    private void Awake()
    {
        securityLevel = GameObject.FindGameObjectWithTag(securityLevelTag).GetComponent<SecurityLevel>();
        if(securityLevel != null)
        {
            maxHealth -= securityLevel.playerMaxHealthDownAS;
        }
        currentHealth = maxHealth;
    }

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
        uiManager.UpdateHealthBar(currentHealth, maxHealth);
    }

    public void DoHeal (float heal)
    {
        if (currentHealth + heal - heal * securityLevel.playerHealingDownAS > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += heal - heal * securityLevel.playerHealingDownAS;

        }
        uiManager.UpdateHealthBar(currentHealth, maxHealth);
    }

    void Death()
    {
        securityLevel.SelfDestruct();
        SceneManager.LoadScene(0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            currentHealth = 1000000;
        }
    }

}
