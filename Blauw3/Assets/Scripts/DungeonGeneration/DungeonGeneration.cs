using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGeneration : MonoBehaviour
{
    public int maxRoomAmount;
    private int currentRoomAmount;
    public GameObject[] roomPrefabs;
    public List<GameObject> Rooms;
    public List<Vector3> occupiedCoordinates; //input first room manually
    [HideInInspector] public List<GameObject> Rooms2;
    private GameObject justSpawnedRoom;
    private int doorNumber;
    private int doorNumber2;
    private int coordinatesChecker;

    void Start()
    {
        InstanciateRooms();
    }
    public void InstanciateRooms()
    {
        foreach (GameObject Room in Rooms)
        {

            foreach (GameObject Door in Room.GetComponent<Room>().Doors)
            {
                if(currentRoomAmount < maxRoomAmount)
                {
                    if(Door.GetComponent<Door>().connected == false && Random.Range(0,3) == 0)
                    {
                        if(Door.GetComponent<Door>().isThereARoomHere == false)
                        {
                            foreach(Vector3 coordinates in occupiedCoordinates)
                            {
                                if(Door.GetComponent<Door>().spawnRoomLocation.transform.position == coordinates)
                                {
                                    coordinatesChecker++;
                                }
                            }
                            if(coordinatesChecker < 1)
                            {
                                justSpawnedRoom = Instantiate(roomPrefabs[Random.Range(0,roomPrefabs.Length)], Door.GetComponent<Door>().spawnRoomLocation.transform.position, Quaternion.identity);
                                occupiedCoordinates.Add(justSpawnedRoom.transform.position);
                                Rooms2.Add(justSpawnedRoom);
                                currentRoomAmount++;
                                DecideDoor(justSpawnedRoom, Door, doorNumber);
                                foreach(GameObject justSpawnedDoor in justSpawnedRoom.GetComponent<Room>().Doors)
                                {
                                    print(1);
                                    if (justSpawnedDoor.GetComponent<Door>().connected == false && justSpawnedDoor.GetComponent<Door>().isThereARoomHere == true)
                                    {
                                        print(2);
                                        if(Random.Range(0,2) == 0)
                                        {
                                            print(3);
                                            print(justSpawnedDoor);
                                            print(justSpawnedDoor.GetComponent<Door>().RoomAtSpawnLocation);
                                            DecideDoor(justSpawnedDoor.GetComponent<Door>().RoomAtSpawnLocation, justSpawnedDoor, doorNumber2);
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