using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGeneration : MonoBehaviour
{
    public List<GameObject> Rooms;
    public GameObject RoomPrefab;
    private GameObject justSpawnedRoom;
    private int doorNumber;
    private int doorNumber2;

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void InstanciateRooms()
    {
        foreach (GameObject Room in Rooms)
        {
            foreach (GameObject Door in Room.GetComponent<Room>().Doors)
            {
                if(Door.GetComponent<Door>().connected == false && Random.Range(0,3) == 0)
                {
                    if(Door.GetComponent<Door>().isThereARoomHere == false)
                    {
                        justSpawnedRoom = Instantiate(RoomPrefab, Door.GetComponent<Door>().spawnRoomLocation.transform.position, Quaternion.identity);
                        Rooms.Add(justSpawnedRoom);
                        DecideDoor(justSpawnedRoom, doorNumber);
                        Door.GetComponent<Door>().Connect();
                        foreach(GameObject justSpawnedDoor in justSpawnedRoom.GetComponent<Room>().Doors)
                        {
                            if (justSpawnedDoor.GetComponent<Door>().connected == false && justSpawnedDoor.GetComponent<Door>().isThereARoomHere == true)
                            {
                                if(Random.Range(0,2) == 0)
                                {

                                }
                            }
                            doorNumber2++;
                        }
                        doorNumber2 = 0;
                            // check if door can connect
                            // rooms spanwed ++
                            // current rooms ++
                    }
                }
                doorNumber++;
            }
            doorNumber = 0;
        }
    }

    private void DecideDoor(GameObject spawned, int door)
    {
        if(door < 3)
        {
            door += 2;
        }
        else
        {
            door -= 2;
        }

        spawned.GetComponent<Room>().Doors[door].GetComponent<Door>().Connect();
    }
}
/* for each room for each door
 * if door not connected
 * check if room for room
 * if so random spawn room
 * add instantiated room to room list
 * check if doors can connect, if so random connect
 * if no new rooms spawned and min rooms has not been hit, run again
 * else stop
 * 
 * 
 * make some limitations to room spawns
 */