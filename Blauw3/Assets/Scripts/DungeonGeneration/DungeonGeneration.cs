using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGeneration : DungeonGeneratorMaster
{
    public GameObject[] connectionPoints;

    void Start()
    {

    }

    void Update()
    {
        
    }

    public void Room()
    {
        if(roomsBuilt < maxRooms)
        {
            foreach (GameObject connectionPoint in connectionPoints)
            {
                if (Random.Range(0, 3) == 0)
                {

                    roomsBuilt++;
                }
            }
        }
    }

    public void CheckConnectors()
    {
        foreach (GameObject connectionPoint in connectionPoints)
        {
            RaycastHit hit;
            if(Physics.Raycast(connectionPoint.transform.position, connectionPoint.transform.TransformDirection(Vector3.forward), out hit, 5))
            {
                connectionPoint.SetActive(true);
            }
        }
    }
}

/*
 * check if "doors" already have rooms
 * if so, connect
 * randomly spawn room at "door" for every room
 * if room spawned connect
 * repeat process for spawned room
 */