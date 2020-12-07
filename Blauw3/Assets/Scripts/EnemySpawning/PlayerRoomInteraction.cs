using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRoomInteraction : MonoBehaviour
{
    public string roomTagName;
    public SpawnEnemies spawnEnemies;

    public void OnTriggerEnter(Collider o)
    {
        if(o.gameObject.tag == roomTagName)
        {
            spawnEnemies = o.gameObject.GetComponent<SpawnEnemies>();
            spawnEnemies.roomStarted = true;
            spawnEnemies.RoomStart();
        }
    }
}