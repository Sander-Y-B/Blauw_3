using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRoomInteraction : MonoBehaviour
{
    public string roomTagName;
    private SpawnEnemies spawnEnemies;

    private void Start()
    {
        
    }

    public void OnTriggerEnter(Collider o)
    {
        if(o.gameObject.tag == roomTagName)
        {
            if(o.gameObject.GetComponent<Room>().winRoom == false)
            {
                if (o.gameObject.GetComponent<SpawnEnemies>() != null)
                {
                    spawnEnemies = o.gameObject.GetComponent<SpawnEnemies>();
                    spawnEnemies.RoomStart();
                }
            }
        }
    }
}