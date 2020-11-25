using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public string roomCheckerTagName;
    public GameObject[] Doors;
    private Door door;

    void Start()
    {
        
    }

    void OnTriggerEnter(Collider o)
    {
        if(o.gameObject.tag == roomCheckerTagName)
        {
            door = o.gameObject.GetComponentInParent<Door>();
            door.RoomAtSpawnLocation = gameObject;
            door.isThereARoomHere = true;
        }
    }
}
