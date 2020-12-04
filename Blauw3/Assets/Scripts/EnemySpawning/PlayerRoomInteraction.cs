using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRoomInteraction : MonoBehaviour
{
    public string roomTagName;

    public void OnTriggerEnter(Collider o)
    {
        if(o.gameObject.tag == roomTagName)
        {
            o.gameObject.GetComponent<SpawnEnemies>().RoomStart();
        }
    }
}