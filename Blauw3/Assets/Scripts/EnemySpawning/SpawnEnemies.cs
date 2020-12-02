using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public int maxEnemiesAllowed;
    public float minTimeBetweenSpawns;
    public GameObject[] spawnPoints;
    public List<GameObject> enemiesToSpawn;
    public List<GameObject> enemiesAlive;
    private GameObject justSpawnedEnemy;
    private int enemiesToSpawnIndicator;
    private float timeSinceLastSpawn;
    private bool timerBool;
    private bool roomCleared;

    void Start()
    {
        RoomStart();
    }

    void Update()
    {
        if(timeSinceLastSpawn >= minTimeBetweenSpawns && enemiesToSpawn.Count > 0 && enemiesAlive.Count < maxEnemiesAllowed)
        {
            enemiesToSpawnIndicator = Random.Range(0, enemiesToSpawn.Count);
            justSpawnedEnemy = Instantiate(enemiesToSpawn[enemiesToSpawnIndicator], spawnPoints[Random.Range(0 ,spawnPoints.Length)].transform.position, Quaternion.identity);
            enemiesAlive.Add(justSpawnedEnemy);
            enemiesToSpawn.Remove(justSpawnedEnemy);
            timeSinceLastSpawn = 0;
        }

        if(timerBool == true)
        {
            timeSinceLastSpawn += Time.deltaTime;
        }

        if(enemiesToSpawn.Count == 0 && enemiesAlive.Count == 0)
        {
            RoomCleared();
        }
    }

    public void RoomStart()
    {
        foreach(GameObject spawnPoint in spawnPoints)
        {
            enemiesToSpawnIndicator = Random.Range(0, enemiesToSpawn.Count);
            justSpawnedEnemy = Instantiate(enemiesToSpawn[enemiesToSpawnIndicator], spawnPoint.transform.position, Quaternion.identity);
            enemiesAlive.Add(justSpawnedEnemy);
            enemiesToSpawn.Remove(justSpawnedEnemy);
        }
        timerBool = true;
    }

    public void RoomCleared()
    {
        print("Cleared!");
        timerBool = false;
    }
}
/*
 */