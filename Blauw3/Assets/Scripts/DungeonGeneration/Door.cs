using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool connected;
    public bool isThereARoomHere;
    public GameObject roomAtSpawnLocation;
    public GameObject spawnRoomLocation;
    public GameObject wall;
    public GameObject hallway;
    public GameObject door;



    public void Connect()
    {
        hallway.SetActive(true);
        wall.SetActive(false);
        connected = true;
        isThereARoomHere = true;
    }

    public void CloseDoors()
    {
        door.SetActive(true);
    }
    public void OpenDoors()
    {
        door.SetActive(false);
    }
}