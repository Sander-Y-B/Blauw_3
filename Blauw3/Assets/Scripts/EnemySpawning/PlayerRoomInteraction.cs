using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRoomInteraction : MonoBehaviour
{
    public string roomTagName;
    private SpawnEnemies spawnEnemies;

    public void OnTriggerEnter(Collider o)
    {
        if(o.gameObject.tag == roomTagName)
        {
            if(o.gameObject.GetComponent<Room>().winRoom == false)
            {
                spawnEnemies = o.gameObject.GetComponent<SpawnEnemies>();
                spawnEnemies.RoomStart();
            }
            else
            {
                //win
            }
        }
    }
}