using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityLevel : MonoBehaviour
{
    static int securityLevel;

    //enemy buffs
    static float enemyAttackSpeed;
    static float enemyMovementSpeed;
    static float enemyAmount;
    static float enemyHealth;
    static float enemyDamage;
    static float enemyShield;

    //player nurfs
    static float playerHealingDown;
    static float playerMaxHealthDown;
    static float playerAmmoRegenDown;
    static float playerMaxAmmoDown;

    //other
    static float playerTimer;

    //individual security levels
    static float enemyAttackSpeedSL;
    static float enemyMovementSpeedSL;
    static float enemyAmountSL;
    static float enemyHealthSL;
    static float enemyDamageSL;
    static float enemyShieldSL;

    static float playerHealingDownSL;
    static float playerMaxHealthDownSL;
    static float playerAmmoRegenDownSL;
    static float playerMaxAmmoDownSL;

    static float playerTimerSL;

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
}
