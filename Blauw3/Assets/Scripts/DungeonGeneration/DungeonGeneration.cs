using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGeneration : DungeonGeneratorMaster
{
    public GameObject[] connectionPoints;
    private int spawnRoom;

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
                spawnRoom = Random.Range(0, 2);
                if (spawnRoom == 0)
                {
                    
                }
            }
        }
    }

    public void CheckConnectors()
    {
        foreach (GameObject connectionPoint in connectionPoints)
        {
            
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