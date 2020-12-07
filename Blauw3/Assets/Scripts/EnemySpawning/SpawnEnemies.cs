using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public int totalEnemies;
    private int currentEnemies;
    public int maxEnemiesAllowed;
    public float minTimeBetweenSpawns;
    public int[] spawnChanceEnemy;
    private int enemiesSpawnIndicator;
    public GameObject[] spawnPoints;
    public GameObject[] enemiesToSpawn;
    [HideInInspector] public List<GameObject> enemiesAlive;
    private GameObject justSpawnedEnemy;
    private float timeSinceLastSpawn;
    private bool timerBool;
    private bool roomCleared;
    [HideInInspector] public bool roomStarted;

    void Start()
    {
        //RoomStart(); //for testing purposes only
    }

    void Update()
    {
        if(roomStarted == true)
        {
            if (roomCleared == false)
            {
                if(timeSinceLastSpawn >= minTimeBetweenSpawns && currentEnemies < totalEnemies && enemiesAlive.Count < maxEnemiesAllowed)//spawns more enemies, but not over a certain amount and there is a minimum wait time
                {
                    indicateSpawnEnemy();
                    justSpawnedEnemy = Instantiate(enemiesToSpawn[enemiesSpawnIndicator], spawnPoints[Random.Range(0 ,spawnPoints.Length)].transform.position, Quaternion.identity);
                    enemiesAlive.Add(justSpawnedEnemy);
                    currentEnemies++;
                    timeSinceLastSpawn = 0;
                }

                if(timerBool == true)
                {
                    timeSinceLastSpawn += Time.deltaTime;
                }

                if(totalEnemies == currentEnemies && enemiesAlive.Count == 0)
                {
                    RoomCleared();
                }
            }
        }
    }

    public void RoomStart() //called when player enters the room for the first time (though an on trigger on the player)
    {
        if(roomCleared == false)
        {
            //close doors
            foreach(GameObject spawnPoint in spawnPoints)
            {
                indicateSpawnEnemy();
                justSpawnedEnemy = Instantiate(enemiesToSpawn[enemiesSpawnIndicator], spawnPoint.transform.position, Quaternion.identity);
                enemiesAlive.Add(justSpawnedEnemy);
            }
            timerBool = true;
        }
    }

    public void RoomCleared()
    {
        //open doors
        roomCleared = true;
    }

    public void indicateSpawnEnemy() //always call this before spawning an enemy
    {
        enemiesSpawnIndicator = Random.Range(1, spawnChanceEnemy[0] + spawnChanceEnemy[1] + spawnChanceEnemy[2]);
        if(enemiesSpawnIndicator <= spawnChanceEnemy[0])
        {
            enemiesSpawnIndicator = 0;
        }
        else if(enemiesSpawnIndicator <= spawnChanceEnemy[0] + spawnChanceEnemy[1])
        {
            enemiesSpawnIndicator = 1;
        }
        else if(enemiesSpawnIndicator <= spawnChanceEnemy[0] + spawnChanceEnemy[1] + spawnChanceEnemy[2])
        {
            enemiesSpawnIndicator = 2;
        }
    }
}