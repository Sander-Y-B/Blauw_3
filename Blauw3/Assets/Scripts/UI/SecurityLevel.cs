using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityLevel : MonoBehaviour
{
    static int securityLevel;

    //enemy buffs
    static float attackSpeed;
    static float movementSpeed;
    static float amount;
    static float health;
    static float damage;
    static float shield;

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
    static float amountSL;
    static float healthSL;
    static float damageSL;
    static float shieldSL;

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

    public void AddOrSubtractSecurityLevel(int addOrSubtractSecurityLevel)
    {
        securityLevel += addOrSubtractSecurityLevel;
    }
}
