using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGeneration : MonoBehaviour
{
    public int maxRoomAmount;
    private int currentRoomAmount;
    public int spawnRoomChance;
    public int connectDoorChance;
    public GameObject[] roomPrefabs;
    public List<GameObject> Rooms;
    [HideInInspector] public List<GameObject> occupiedCoordinates;
    [HideInInspector] public List<GameObject> Rooms2;
    private GameObject justSpawnedRoom;
    private Room roomScript;
    private Door doorScript;
    private int doorNumber;
    private int doorNumber2;
    private int coordinatesChecker;

    void Start()
    {
        occupiedCoordinates.Add(Rooms[0]);
        InstanciateRooms();
    }
    public void InstanciateRooms()
    {
        foreach (GameObject Room in Rooms)
        {
            roomScript = Room.GetComponent<Room>();
            foreach (GameObject door in roomScript.Doors)
            {
                doorScript = door.GetComponent<Door>();
                if(currentRoomAmount < maxRoomAmount)
                {
                    if(doorScript.connected == false && Random.Range(0,spawnRoomChance) == 0)
                    {
                        if(doorScript.isThereARoomHere == false)
                        {
                            foreach(GameObject coordinates in occupiedCoordinates)
                            {
                                if(doorScript.spawnRoomLocation.transform.position == coordinates.transform.position)
                                {
                                    coordinatesChecker++;
                                }
                            }
                            if(coordinatesChecker < 1)
                            {
                                justSpawnedRoom = Instantiate(roomPrefabs[Random.Range(0,roomPrefabs.Length)], doorScript.spawnRoomLocation.transform.position, Quaternion.identity);
                                occupiedCoordinates.Add(justSpawnedRoom);
                                Rooms2.Add(justSpawnedRoom);
                                currentRoomAmount++;
                                DecideDoor(justSpawnedRoom, door, doorNumber);
                                foreach(GameObject justSpawnedDoor in justSpawnedRoom.GetComponent<Room>().Doors)
                                {
                                    doorScript = justSpawnedDoor.GetComponent<Door>();
                                    foreach (GameObject coordinates in occupiedCoordinates)
                                    {
                                        if (doorScript.spawnRoomLocation.transform.position == coordinates.transform.position)
                                        {
                                            doorScript.RoomAtSpawnLocation = coordinates;
                                        }
                                    }
                                    if(doorScript.RoomAtSpawnLocation != null)
                                    {
                                        if (doorScript.connected == false)
                                        {
                                            if(Random.Range(0,connectDoorChance) == 0)
                                            {
                                                DecideDoor(doorScript.RoomAtSpawnLocation, justSpawnedDoor, doorNumber2);
                                            }
                                        }
                                    }
                                    doorNumber2++;
                                }
                                doorNumber2 = 0;
                            }
                            else
                            {
                                coordinatesChecker = 0;
                            }
                        }
                    }
                    doorNumber++;
                }
            }
            doorNumber = 0;
        }
        if(Rooms2.Count > 0)
        {
            foreach(GameObject room in Rooms2)
            {
                Rooms.Add(room);
            }
            Rooms2.Clear();
        }
        if(currentRoomAmount < maxRoomAmount)
        {
            InstanciateRooms();
        }
    }

    private void DecideDoor(GameObject spawned, GameObject otherDoor, int door)
    {
        if(door < 2)
        {
            door += 2;
        }
        else
        {
            door -= 2;
        }

        spawned.GetComponent<Room>().Doors[door].GetComponent<Door>().Connect();
        otherDoor.GetComponent<Door>().Connect();
    }
}
/* voor instanciate room check of coordinaten niet in array staan
 * coordinate van gespawnde room toevoegen aan array
 */