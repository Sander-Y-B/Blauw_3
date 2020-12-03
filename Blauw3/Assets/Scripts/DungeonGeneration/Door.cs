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



    public void Connect()
    {
        hallway.SetActive(true);
        wall.SetActive(false);
        connected = true;
        isThereARoomHere = true;
    }
}