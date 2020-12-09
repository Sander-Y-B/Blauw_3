using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : MonoBehaviour
{
    public SpawnEnemies spawnEnemies;

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            spawnEnemies.enemiesAlive.Remove(gameObject);
            Destroy(gameObject);
        }
    }
}
