using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SecurityLevel : MonoBehaviour
{
    [HideInInspector] public int totalSecurityLevel; //need to check what lvl this is at to see what rewards can available

    //amount take off/added per lvl
    public float enemyAttackSpeed; //percent
    public float enemyMovementSpeed; //percent
    public float enemyHealth; //percent
    public float enemyDamage; //percent
    public int enemyAmount;
    public int enemyShield;

    public float playerHealingDown; //percent
    public float playerMaxHealthDown;
    public float playerAmmoRegenDown; //percent
    public float playerMaxAmmoDown;

    public float playerTimerLvl1; //amount of time you get when timer is lvl 1
    public float playerTimer; //amount of time taken off per lvl from lvl1


    //AS = Actual Stat 
    [HideInInspector] public float enemyAttackSpeedAS;
    [HideInInspector] public float enemyMovementSpeedAS;
    [HideInInspector] public float enemyHealthAS;
    [HideInInspector] public float enemyDamageAS;
    [HideInInspector] public int enemyAmountAS;
    [HideInInspector] public int enemyShieldAS;

    [HideInInspector] public float playerHealingDownAS;
    [HideInInspector] public float playerMaxHealthDownAS;
    [HideInInspector] public float playerAmmoRegenDownAS;
    [HideInInspector] public float playerMaxAmmoDownAS;

    [HideInInspector] public float playerTimerAS;


    //individual security levels
    [HideInInspector] public float enemyAttackSpeedSL;
    [HideInInspector] public float enemyMovementSpeedSL;
    [HideInInspector] public float enemyHealthSL;
    [HideInInspector] public float enemyDamageSL;
    [HideInInspector] public int enemyAmountSL;
    [HideInInspector] public int enemyShieldSL;

    [HideInInspector] public float playerHealingDownSL;
    [HideInInspector] public float playerMaxHealthDownSL;
    [HideInInspector] public float playerAmmoRegenDownSL;
    [HideInInspector] public float playerMaxAmmoDownSL;

    [HideInInspector] public float playerTimerSL;

    [Header("Max Level")]

    //max securitLevel
    public float enemyAttackSpeedML;
    public float enemyMovementSpeedML;
    public float enemyAmountML;
    public float enemyHealthML;
    public float enemyDamageML;
    public float enemyShieldML;

    private float playerHealingDownML;
    private float playerMaxHealthDownML;
    private float playerAmmoRegenDownML;
    private float playerMaxAmmoDownML;

    private float playerTimerML;

    [Header("Text")]

    //Security level numbers
    public Text enemyAttackSpeedText;
    public Text enemyMovementSpeedText;
    public Text enemyAmountText;
    public Text enemyHealthText;
    public Text enemyDamageText;
    public Text enemyShieldText;

    public Text playerHealingDownText;
    public Text playerMaxHealthDownText;
    public Text playerAmmoRegenDownText;
    public Text playerMaxAmmoDownText;

    public Text playerTimerText;

    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void UpdateTotalSecurityLevel(int updateSecurityLevel)
    {
        totalSecurityLevel += updateSecurityLevel;
        // .text = Mathf.RoundToInt(totalSecurityLevel).ToString();
    }

    public void EnemyAttackSpeedSecurityLevel(int enemyAttackSpeedSecurityLevel)
    {
        if(enemyAttackSpeedSL == 0 && enemyAttackSpeedSecurityLevel < 0 || enemyAttackSpeedSL == enemyAttackSpeedML && enemyAttackSpeedSecurityLevel > 0)
        {
            return;
        }
        enemyAttackSpeedSL += enemyAttackSpeedSecurityLevel;
        enemyAttackSpeedText.text = enemyAttackSpeedSL.ToString();
        UpdateTotalSecurityLevel(enemyAttackSpeedSecurityLevel);
    }

    public void EnemyMovementSpeedSecurityLevel(int enemyMovementSpeedSecurityLevel)
    {
        if (enemyMovementSpeedSL == 0 && enemyMovementSpeedSecurityLevel < 0 || enemyMovementSpeedSL == enemyMovementSpeedML && enemyMovementSpeedSecurityLevel > 0)
        {
            return;
        }
        enemyMovementSpeedSL += enemyMovementSpeedSecurityLevel;
        enemyMovementSpeedText.text = enemyMovementSpeedSL.ToString();
        UpdateTotalSecurityLevel(enemyMovementSpeedSecurityLevel);
    }

    public void EnemyAmountSecurityLevel(int enemyAmountSecurityLevel)
    {
        if (enemyAmountSL == 0 && enemyAmountSecurityLevel < 0 || enemyAmountSL == enemyAmountML && enemyAmountSecurityLevel > 0)
        {
            return;
        }
        enemyAmountSL += enemyAmountSecurityLevel;
        enemyAmountText.text = enemyAmountSL.ToString();
        UpdateTotalSecurityLevel(enemyAmountSecurityLevel);
    }

    public void EnemyHealthSecurityLevel(int enemyHealthSecurityLevel)
    {
        if (enemyHealthSL == 0 && enemyHealthSecurityLevel < 0 || enemyHealthSL == enemyHealthML && enemyHealthSecurityLevel > 0)
        {
            return;
        }
        enemyHealthSL += enemyHealthSecurityLevel;
        enemyHealthText.text = enemyHealthSL.ToString();
        UpdateTotalSecurityLevel(enemyHealthSecurityLevel);
    }

    public void EnemyDamageSecurityLevel(int enemyDamageSecurityLevel)
    {
        if (enemyDamageSL == 0 && enemyDamageSecurityLevel < 0 || enemyDamageSL == enemyDamageML && enemyDamageSecurityLevel > 0)
        {
            return;
        }
        enemyDamageSL += enemyDamageSecurityLevel;
        enemyDamageText.text = enemyDamageSL.ToString();
        UpdateTotalSecurityLevel(enemyDamageSecurityLevel);
    }

    public void EnemyShieldSecurityLevel(int enemyShieldSecurityLevel)
    {
        if (enemyShieldSL == 0 && enemyShieldSecurityLevel < 0 || enemyShieldSL == enemyShieldML && enemyShieldSecurityLevel > 0)
        {
            return;
        }
        enemyShieldSL += enemyShieldSecurityLevel;
        enemyShieldText.text = enemyShieldSL.ToString();
        UpdateTotalSecurityLevel(enemyShieldSecurityLevel);
    }

    public void PlayerHealingDownSecurityLevel(int playerHealingDownSecurityLevel)
    {
        if (playerHealingDownSL == 0 && playerHealingDownSecurityLevel < 0 || playerHealingDownSL == playerHealingDownML && playerHealingDownSecurityLevel > 0)
        {
            return;
        }
        playerHealingDownSL += playerHealingDownSecurityLevel;
        playerHealingDownText.text = playerHealingDownSL.ToString();
        UpdateTotalSecurityLevel(playerHealingDownSecurityLevel);
    }

    public void PlayerMaxHealthDownSecurityLevel(int playerMaxHealthDownSecurityLevel)
    {
        if (playerMaxHealthDownSL == 0 && playerMaxHealthDownSecurityLevel < 0 || playerMaxHealthDownSL == playerMaxHealthDownML && playerMaxHealthDownSecurityLevel > 0)
        {
            return;
        }
        playerMaxHealthDownSL += playerMaxHealthDownSecurityLevel;
        playerMaxHealthDownText.text = playerMaxHealthDownSL.ToString();
        UpdateTotalSecurityLevel(playerMaxHealthDownSecurityLevel);
    }

    public void PlayerAmmoRegenDownSecurityLevel(int playerAmmoRegenDownSecurityLevel)
    {
        if (playerAmmoRegenDownSL == 0 && playerAmmoRegenDownSecurityLevel < 0 || playerAmmoRegenDownSL == playerAmmoRegenDownML && playerAmmoRegenDownSecurityLevel > 0)
        {
            return;
        }
        playerAmmoRegenDownSL += playerAmmoRegenDownSecurityLevel;
        playerAmmoRegenDownText.text = playerAmmoRegenDownSL.ToString();
        UpdateTotalSecurityLevel(playerAmmoRegenDownSecurityLevel);
    }

    public void PlayerMaxAmmoDownSecurityLevel(int playerMaxAmmoDownSecurityLevel)
    {
        if (playerMaxAmmoDownSL == 0 && playerMaxAmmoDownSecurityLevel < 0 || playerMaxAmmoDownSL == playerMaxAmmoDownML && playerMaxAmmoDownSecurityLevel > 0)
        {
            return;
        }
        playerMaxAmmoDownSL += playerMaxAmmoDownSecurityLevel;
        playerMaxAmmoDownText.text = playerMaxAmmoDownSL.ToString();
        UpdateTotalSecurityLevel(playerMaxAmmoDownSecurityLevel);
    }

    public void PlayerTimerSecurityLevel(int playerTimerSecurityLevel)
    {
        if (playerTimerSL == 0 && playerTimerSecurityLevel < 0 || playerTimerSL == playerTimerML && playerTimerSecurityLevel > 0)
        {
            return;
        }
        playerTimerSL += playerTimerSecurityLevel;
        playerTimerText.text = playerTimerSL.ToString();
        UpdateTotalSecurityLevel(playerTimerSecurityLevel);
    }

    public void LoadLevel()
    {
        enemyAttackSpeedAS = 1;
        if(enemyAttackSpeedSL > 0)
        {
            enemyAttackSpeedAS += enemyAttackSpeed * enemyAttackSpeedSL / 100;
        }

        enemyMovementSpeedAS = 1;
        if (enemyMovementSpeedSL > 0)
        {
            enemyMovementSpeedAS += enemyMovementSpeed * enemyMovementSpeedSL / 100;
        }

        if (enemyAmountSL > 0)
        {
            enemyAmountAS = enemyAmount * enemyAmountSL;
        }


        enemyHealthAS = 1;
        if (enemyHealthSL > 0)
        {
            enemyHealthAS += enemyHealth * enemyHealthSL / 100;
        }

        enemyDamageAS = 1;
        if (enemyDamageSL > 0)
        {
            enemyDamageAS += enemyDamage * enemyDamageSL / 100;
        }

        if (enemyShieldSL > 0)
        {
            enemyShieldAS = enemyShield * enemyShieldSL;
        }

        playerHealingDownAS = 1;
        if (playerHealingDownSL > 0)
        {
            playerHealingDownAS += playerHealingDown * playerHealingDownSL / 100;
        }

        if (playerMaxHealthDownSL > 0)
        {
            playerMaxHealthDownAS = playerMaxHealthDown * playerMaxHealthDownSL;
        }

        playerAmmoRegenDownAS = 1;
        if (playerAmmoRegenDownSL > 0)
        {
            playerAmmoRegenDownAS += playerAmmoRegenDown * playerAmmoRegenDownSL / 100;
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

        SceneManager.LoadScene(1);
    }
}