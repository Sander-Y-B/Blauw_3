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

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void UpdateSecurityLevel(int updateSecurityLevel)
    {
        securityLevel += updateSecurityLevel;
        //update text
    }

    public void EnemyAttackSpeedSecurityLevel(int enemyAttackSpeedSecurityLevel)
    {
        enemyAttackSpeedSL += enemyAttackSpeedSecurityLevel;
        UpdateSecurityLevel(enemyAttackSpeedSecurityLevel);
    }

    public void EnemyMovementSpeedSecurityLevel(int enemyMovementSpeedSecurityLevel)
    {
        enemyMovementSpeedSL += enemyMovementSpeedSecurityLevel;
        UpdateSecurityLevel(enemyMovementSpeedSecurityLevel);
    }

    public void EnemyAmountSecurityLevel(int enemyAmountSecurityLevel)
    {
        enemyAmountSL += enemyAmountSecurityLevel;
        UpdateSecurityLevel(enemyAmountSecurityLevel);
    }

    public void EnemyHealthSecurityLevel(int enemyHealthSecurityLevel)
    {
        enemyHealthSL += enemyHealthSecurityLevel;
        UpdateSecurityLevel(enemyHealthSecurityLevel);
    }

    public void EnemyDamageSecurityLevel(int enemyDamageSecurityLevel)
    {
        enemyDamageSL += enemyDamageSecurityLevel;
        UpdateSecurityLevel(enemyDamageSecurityLevel);
    }

    public void EnemyShieldSecurityLevel(int enemyShieldSecurityLevel)
    {
        enemyShieldSL += enemyShieldSecurityLevel;
        UpdateSecurityLevel(enemyShieldSecurityLevel);
    }

    public void PlayerHealingDownSecurityLevel(int playerHealingDownSecurityLevel)
    {
        playerHealingDownSL += playerHealingDownSecurityLevel;
        UpdateSecurityLevel(playerHealingDownSecurityLevel);
    }

    public void PlayerMaxHealthDownSecurityLevel(int playerMaxHealthDownSecurityLevel)
    {
        playerMaxHealthDownSL += playerMaxHealthDownSecurityLevel;
        UpdateSecurityLevel(playerMaxHealthDownSecurityLevel);
    }

    public void PlayerAmmoRegenDownSecurityLevel(int playerAmmoRegenDownSecurityLevel)
    {
        playerAmmoRegenDownSL += playerAmmoRegenDownSecurityLevel;
        UpdateSecurityLevel(playerAmmoRegenDownSecurityLevel);
    }

    public void PlayerMaxAmmoDownSecurityLevel(int playerMaxAmmoDownSecurityLevel)
    {
        playerMaxAmmoDownSL += playerMaxAmmoDownSecurityLevel;
        UpdateSecurityLevel(playerMaxAmmoDownSecurityLevel);
    }

    public void PlayerTimerSecurityLevel(int playerTimerSecurityLevel)
    {
        playerTimerSL += playerTimerSecurityLevel;
        UpdateSecurityLevel(playerTimerSecurityLevel);
    }
}
