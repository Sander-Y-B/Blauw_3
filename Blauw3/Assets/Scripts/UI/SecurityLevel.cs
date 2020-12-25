using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityLevel : MonoBehaviour
{
    static int securityLevel;

    //enemy buffs
    static float attackSpeed;
    static float movementSpeed;
    static float enemyAmount;
    static float enemyHealth;
    static float enemyDamage;
    static float enemyShield;

    //player nurfs
    static float healingDown;
    static float maxHealthDown;
    static float ammoRegenDown;
    static float maxAmmoDown;

    //other
    static float timer;

    //individual security levels
    static float attackSpeedSL;
    static float movementSpeedSL;
    static float enemyAmountSL;
    static float enemyHealthSL;
    static float enemyDamageSL;
    static float enemyShieldSL;

    static float healingDownSL;
    static float maxHealthDownSL;
    static float ammoRegenDownSL;
    static float maxAmmoDownSL;

    static float timerSL;

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void UpdateSecurityLevel()
    {

    }

    public void AttackSpeedSecurityLevel(int attackSpeedSecurityLevel)
    {
        attackSpeedSL += attackSpeedSecurityLevel;
    }

    public void MovementSpeedSecurityLevel(int movementSpeedSecurityLevel)
    {
        movementSpeedSL += movementSpeedSecurityLevel;
    }

    public void EnemyAmountSecurityLevel(int enemyAmountSecurityLevel)
    {
        enemyAmountSL += enemyAmountSecurityLevel;
    }

    public void EnemyHealthSecurityLevel(int enemyHealthSecurityLevel)
    {
        enemyHealthSL += enemyHealthSecurityLevel;
    }

    public void EnemyDamageSecurityLevel(int enemyDamageSecurityLevel)
    {
        enemyDamageSL += enemyDamageSecurityLevel;
    }
}
