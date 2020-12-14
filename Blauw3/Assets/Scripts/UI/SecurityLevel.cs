using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityLevel : MonoBehaviour
{
    public int securityLevel;

    //enemy buffs
    public float attackSpeed, movementSpeed;
    public float amount;
    public float health, damage;
    public float shield;

    //player nurfs
    public float healingDown, maxHealthDown;
    public float ammoRegenDown, maxAmmoDown;

    //other
    public float timer;

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
