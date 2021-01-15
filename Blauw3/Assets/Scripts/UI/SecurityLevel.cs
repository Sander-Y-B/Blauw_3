using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

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

    [Header("Actual stats")]

    //AS = Actual Stat 
    public float enemyAttackSpeedAS;
    public float enemyMovementSpeedAS;
    public float enemyHealthAS;
    public float enemyDamageAS;
    public int enemyAmountAS;
    public int enemyShieldAS;

    public float playerHealingDownAS;
    public float playerMaxHealthDownAS;
    public float playerAmmoRegenDownAS;
    public float playerMaxAmmoDownAS;

    public float playerTimerAS;


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

    public float playerHealingDownML;
    public float playerMaxHealthDownML;
    public float playerAmmoRegenDownML;
    public float playerMaxAmmoDownML;

    public float playerTimerML;

    [Header("Text")]

    //Security level numbers
    public TextMeshProUGUI enemyAmountText;
    public TextMeshProUGUI enemyAttackSpeedText;
    public TextMeshProUGUI enemyDamageText;
    public TextMeshProUGUI enemyHealthText;
    public TextMeshProUGUI enemyMovementSpeedText;
    public TextMeshProUGUI enemyShieldText;

    public TextMeshProUGUI playerAmmoRegenDownText;
    public TextMeshProUGUI playerHealingDownText;
    public TextMeshProUGUI playerMaxAmmoDownText;
    public TextMeshProUGUI playerMaxHealthDownText;

    public TextMeshProUGUI playerTimerText;

    public TextMeshProUGUI TotalSecurityLevelText;

    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void UpdateTotalSecurityLevel(int updateSecurityLevel)
    {
        totalSecurityLevel += updateSecurityLevel;
        TotalSecurityLevelText.text = Mathf.RoundToInt(totalSecurityLevel).ToString();
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

    public void ResetValues()
    {
        enemyAttackSpeedSL = 0;
        enemyMovementSpeedSL = 0;
        enemyHealthSL = 0;
        enemyDamageSL = 0;
        enemyAmountSL = 0;
        enemyShieldSL = 0;

        playerHealingDownSL = 0;
        playerMaxHealthDownSL = 0;
        playerAmmoRegenDownSL = 0;
        playerMaxAmmoDownSL = 0;

        playerTimerSL = 0;

        enemyAttackSpeedAS = 0;
        enemyMovementSpeedAS = 0;
        enemyHealthAS = 0;
        enemyDamageAS = 0;
        enemyAmountAS = 0;
        enemyShieldAS = 0;

        playerHealingDownAS = 0;
        playerMaxHealthDownAS = 0;
        playerAmmoRegenDownAS = 0;
        playerMaxAmmoDownAS = 0;

        playerTimerAS = 0;
    }

    public void LoadLevel()
    {
        if(enemyAttackSpeedSL > 0)
        {
            enemyAttackSpeedAS += enemyAttackSpeed * enemyAttackSpeedSL / 100;
        }

        if (enemyMovementSpeedSL > 0)
        {
            enemyMovementSpeedAS += enemyMovementSpeed * enemyMovementSpeedSL / 100;
        }

        if (enemyAmountSL > 0)
        {
            enemyAmountAS = enemyAmount * enemyAmountSL;
        }

        if (enemyHealthSL > 0)
        {
            enemyHealthAS += enemyHealth * enemyHealthSL / 100;
        }

        if (enemyDamageSL > 0)
        {
            enemyDamageAS += enemyDamage * enemyDamageSL / 100;
        }

        if (enemyShieldSL > 0)
        {
            enemyShieldAS = enemyShield * enemyShieldSL;
        }

        if (playerHealingDownSL > 0)
        {
            playerHealingDownAS += playerHealingDown * playerHealingDownSL / 100;
        }

        if (playerMaxHealthDownSL > 0)
        {
            playerMaxHealthDownAS = playerMaxHealthDown * playerMaxHealthDownSL;
        }

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