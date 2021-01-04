using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityLevel : MonoBehaviour
{
    static int securityLevel; //need to check what lvl this is at to see what rewards can available

    //amount take off/added per lvl
    public float enemyAttackSpeed; //percent
    public float enemyMovementSpeed; //percent
    public float enemyAmount;
    public float enemyHealth; //percent
    public float enemyDamage; //percent
    public float enemyShield;

    public float playerHealingDown; //percent
    public float playerMaxHealthDown;
    public float playerAmmoRegenDown;
    public float playerMaxAmmoDown;

    public float playerTimerLvl1; //amount of time you get when timer is lvl 1
    public float playerTimer; //amount of time taken of per lvl from lvl1


    //AS = Actual Stat 
    static float enemyAttackSpeedAS;
    static float enemyMovementSpeedAS;
    static float enemyAmountAS;
    static float enemyHealthAS;
    static float enemyDamageAS;
    static float enemyShieldAS;

    static float playerHealingDownAS;
    static float playerMaxHealthDownAS;
    static float playerAmmoRegenDownAS;
    static float playerMaxAmmoDownAS;

    static float playerTimerAS;


    //individual security levels
    private float enemyAttackSpeedSL;
    private float enemyMovementSpeedSL;
    private float enemyAmountSL;
    private float enemyHealthSL;
    private float enemyDamageSL;
    private float enemyShieldSL;

    private float playerHealingDownSL;
    private float playerMaxHealthDownSL;
    private float playerAmmoRegenDownSL;
    private float playerMaxAmmoDownSL;

    private float playerTimerSL;


    //max securitLevel
    private float enemyAttackSpeedML;
    private float enemyMovementSpeedML;
    private float enemyAmountML;
    private float enemyHealthML;
    private float enemyDamageML;
    private float enemyShieldML;

    private float playerHealingDownML;
    private float playerMaxHealthDownML;
    private float playerAmmoRegenDownML;
    private float playerMaxAmmoDownML;

    private float playerTimerML;


    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void UpdateSecurityLevel(int updateSecurityLevel)
    {
        securityLevel += updateSecurityLevel;
        //update text.text
    }

    public void EnemyAttackSpeedSecurityLevel(int enemyAttackSpeedSecurityLevel)
    {
        if(enemyAttackSpeedSL == 0 && enemyAttackSpeedSecurityLevel < 0 || enemyAttackSpeedSL == enemyAttackSpeedML && enemyAttackSpeedSecurityLevel > 0)
        {
            return;
        }
        enemyAttackSpeedSL += enemyAttackSpeedSecurityLevel;
        UpdateSecurityLevel(enemyAttackSpeedSecurityLevel);
    }

    public void EnemyMovementSpeedSecurityLevel(int enemyMovementSpeedSecurityLevel)
    {
        if (enemyMovementSpeedSL == 0 && enemyMovementSpeedSecurityLevel < 0 || enemyMovementSpeedSL == enemyMovementSpeedML && enemyMovementSpeedSecurityLevel > 0)
        {
            return;
        }
        enemyMovementSpeedSL += enemyMovementSpeedSecurityLevel;
        UpdateSecurityLevel(enemyMovementSpeedSecurityLevel);
    }

    public void EnemyAmountSecurityLevel(int enemyAmountSecurityLevel)
    {
        if (enemyAmountSL == 0 && enemyAmountSecurityLevel < 0 || enemyAmountSL == enemyAmountML && enemyAmountSecurityLevel > 0)
        {
            return;
        }
        enemyAmountSL += enemyAmountSecurityLevel;
        UpdateSecurityLevel(enemyAmountSecurityLevel);
    }

    public void EnemyHealthSecurityLevel(int enemyHealthSecurityLevel)
    {
        if (enemyHealthSL == 0 && enemyHealthSecurityLevel < 0 || enemyHealthSL == enemyHealthML && enemyHealthSecurityLevel > 0)
        {
            return;
        }
        enemyHealthSL += enemyHealthSecurityLevel;
        UpdateSecurityLevel(enemyHealthSecurityLevel);
    }

    public void EnemyDamageSecurityLevel(int enemyDamageSecurityLevel)
    {
        if (enemyDamageSL == 0 && enemyDamageSecurityLevel < 0 || enemyDamageSL == enemyDamageML && enemyDamageSecurityLevel > 0)
        {
            return;
        }
        enemyDamageSL += enemyDamageSecurityLevel;
        UpdateSecurityLevel(enemyDamageSecurityLevel);
    }

    public void EnemyShieldSecurityLevel(int enemyShieldSecurityLevel)
    {
        if (enemyShieldSL == 0 && enemyShieldSecurityLevel < 0 || enemyShieldSL == enemyShieldML && enemyShieldSecurityLevel > 0)
        {
            return;
        }
        enemyShieldSL += enemyShieldSecurityLevel;
        UpdateSecurityLevel(enemyShieldSecurityLevel);
    }

    public void PlayerHealingDownSecurityLevel(int playerHealingDownSecurityLevel)
    {
        if (playerHealingDownSL == 0 && playerHealingDownSecurityLevel < 0 || playerHealingDownSL == playerHealingDownML && playerHealingDownSecurityLevel > 0)
        {
            return;
        }
        playerHealingDownSL += playerHealingDownSecurityLevel;
        UpdateSecurityLevel(playerHealingDownSecurityLevel);
    }

    public void PlayerMaxHealthDownSecurityLevel(int playerMaxHealthDownSecurityLevel)
    {
        if (playerMaxHealthDownSL == 0 && playerMaxHealthDownSecurityLevel < 0 || playerMaxHealthDownSL == playerMaxHealthDownML && playerMaxHealthDownSecurityLevel > 0)
        {
            return;
        }
        playerMaxHealthDownSL += playerMaxHealthDownSecurityLevel;
        UpdateSecurityLevel(playerMaxHealthDownSecurityLevel);
    }

    public void PlayerAmmoRegenDownSecurityLevel(int playerAmmoRegenDownSecurityLevel)
    {
        if (playerAmmoRegenDownSL == 0 && playerAmmoRegenDownSecurityLevel < 0 || playerAmmoRegenDownSL == playerAmmoRegenDownML && playerAmmoRegenDownSecurityLevel > 0)
        {
            return;
        }
        playerAmmoRegenDownSL += playerAmmoRegenDownSecurityLevel;
        UpdateSecurityLevel(playerAmmoRegenDownSecurityLevel);
    }

    public void PlayerMaxAmmoDownSecurityLevel(int playerMaxAmmoDownSecurityLevel)
    {
        if (playerMaxAmmoDownSL == 0 && playerMaxAmmoDownSecurityLevel < 0 || playerMaxAmmoDownSL == playerMaxAmmoDownML && playerMaxAmmoDownSecurityLevel > 0)
        {
            return;
        }
        playerMaxAmmoDownSL += playerMaxAmmoDownSecurityLevel;
        UpdateSecurityLevel(playerMaxAmmoDownSecurityLevel);
    }

    public void PlayerTimerSecurityLevel(int playerTimerSecurityLevel)
    {
        if (playerTimerSL == 0 && playerTimerSecurityLevel < 0 || playerTimerSL == playerTimerML && playerTimerSecurityLevel > 0)
        {
            return;
        }
        playerTimerSL += playerTimerSecurityLevel;
        UpdateSecurityLevel(playerTimerSecurityLevel);
    }

    public void LoadLevel()
    {
        if(enemyAttackSpeedSL > 0)
        {
            enemyAttackSpeedAS = enemyAttackSpeed * enemyAttackSpeedSL;
        }

        if (enemyMovementSpeedSL > 0)
        {
            enemyMovementSpeedAS = enemyMovementSpeed * enemyMovementSpeedSL;
        }

        if (enemyAmountSL > 0)
        {
            enemyAmountAS = enemyAmount * enemyAmountSL;
        }


        if (enemyHealthSL > 0)
        {
            enemyHealthAS = enemyHealth * enemyHealthSL;
        }

        if (enemyDamageSL > 0)
        {
            enemyDamageAS = enemyDamage * enemyDamageSL;
        }

        if (enemyShieldSL > 0)
        {
            enemyShieldAS = enemyShield * enemyShieldSL;
        }

        if (playerHealingDownSL > 0)
        {
            playerHealingDownAS = playerHealingDown * playerHealingDownSL;
        }

        if (playerMaxHealthDownSL > 0)
        {
            playerMaxHealthDownAS = playerMaxHealthDown * playerMaxHealthDownSL;
        }

        if (playerAmmoRegenDownSL > 0)
        {
            playerAmmoRegenDownAS = playerAmmoRegenDown * playerAmmoRegenDownSL;
        }

        if (playerMaxAmmoDownSL > 0)
        {
            playerMaxAmmoDownAS = playerMaxAmmoDown * playerMaxAmmoDownSL;
        }

        if (playerTimerSL > 0)
        {
            if(playerTimerSL == 1)
            {
                playerTimerAS = playerTimerLvl1;
            }
            else
            {
                playerTimerAS = playerTimerLvl1 - (playerTimer * playerTimerSL);
            }

        }

        //load next scene
    }
}
