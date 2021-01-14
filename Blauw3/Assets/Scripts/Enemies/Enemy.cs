using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent;
    public Animator animator;
    public Transform player;
    public GameObject prefab, dropPoint, infoBox, healPickup;
    public LayerMask whatIsGround, whatIsPlayer;
    public float health, dissolveTime;
    private float maxHealth, healthPercent;
    public Slider healthSlider;
    public SpawnEnemies spawnEnemies;
    public Material dissolve;
    public AudioSource attackSound, deathSound;
    private int randomNum;
    public GameObject[] Drops;
    private GameObject currentDrop, currentDropPoint, currentInfoBox;
    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks, damage;
    bool alreadyAttacked;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    [HideInInspector] public SecurityLevel securityLevel;
    public string securityLevelTag;
    private int shield;

    private void Awake()
    {
        securityLevel = GameObject.FindGameObjectWithTag(securityLevelTag).GetComponent<SecurityLevel>();
        if (securityLevel != null)
        {
            timeBetweenAttacks -= timeBetweenAttacks * securityLevel.enemyAttackSpeedAS;
            damage += damage * securityLevel.enemyDamageAS;
            agent.speed += agent.speed * securityLevel.enemyMovementSpeedAS;
            health += health * securityLevel.enemyHealthAS;
            shield = securityLevel.enemyShieldAS;
        }
        maxHealth = health;
        player = GameObject.Find("PlayerBody").transform;
        agent = GetComponent<NavMeshAgent>();

    }

    private void Update()
    {
        if (health > 0)
        {
            //Check for sight and attack range
            playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
            if (!playerInAttackRange) ChasePlayer();
            if (playerInAttackRange ) AttackPlayer();
        }
    }
    private void SearchWalkPoint()
    {
        Walk();
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        Walk();
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            ///Attack here
            Attack();
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void TakeDamage(float damage)
    {
        if(shield > 0)
        {
            shield--;
            //update shield UI
            return;
        }
        health -= damage;

        if (health <= 0) { DestroyEnemy();}
        healthPercent = health / maxHealth * 100;
        healthSlider.value = healthPercent;
    }
    public virtual void DestroyEnemy()
    {
        RandomDrop();
        spawnEnemies.enemiesAlive.Remove(gameObject);
        Destroy(gameObject);
    }

    public virtual void Attack()
    {
        attackSound.Play();
    }

    public virtual void Walk()
    {
        //walk animation override
    }

    public void RandomDrop()
    {
        randomNum = Random.Range(0,3);

        if (randomNum == 1)
        {
            currentDropPoint = Instantiate(dropPoint, transform.position, transform.rotation);
            currentDrop = Instantiate(Drops[Random.Range(0, Drops.Length)], currentDropPoint.transform.position, currentDropPoint.transform.rotation);
            currentDrop.GetComponent<InWorldPart>().myShopPoint = currentDropPoint;
            currentInfoBox = Instantiate(infoBox, currentDropPoint.transform.position, currentDropPoint.transform.rotation);
            currentInfoBox.transform.SetParent(currentDrop.transform);
            currentInfoBox.GetComponent<info>().inWorldPart = currentDrop.GetComponent<InWorldPart>();
        }
        else if(randomNum == 2)
        {
            Instantiate(healPickup, transform.position, transform.rotation);
        }
    }
}
