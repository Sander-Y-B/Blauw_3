﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomManager : MonoBehaviour
{
    // to make sure the gen works properly you need one room in the scene that has been added into the total and current list


    //Prefabs
    public GameObject[] roomPrefabs;
    public GameObject doorBlock;
    public GameObject finalRoom;
    public GameObject bossDoor;

    //Counters
    public int maxRoomCount;
    public int currentRoomIndex;
    private int currNewRoomIndex;
    public int totalRooms;
    public int monsterCount;

    //Spawn info
    public Vector3 offset;
    public Vector3 rayDoorOffset;
    public float rayDoorLenght;
    public float rayLenght;
    private RaycastHit hit;
    private GameObject finalDoorway;

    //Ref info
    public GameObject loadingUI;
    public GameObject uiPlayer;
    private GameObject player;
    public int restartIndex;

    //Lists
    public List<GameObject> currentRooms = new List<GameObject>();
    public List<GameObject> newRooms = new List<GameObject>();
    public List<GameObject> emptyDoorWays = new List<GameObject>();
    public List<GameObject> totalRoomList = new List<GameObject>();
   
    //Bools
    private bool isGen = true;
    private bool hasFinalRoom = false;
    public bool isFinished;

    //sounds
    public AudioSource roomBlocked;
    public AudioSource roomUnblocked;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        loadingUI.SetActive(true); //dit is zodat ik de ui uit kan hebben staan terwijl ik in de scene werk zonder dat er een probleem komt als ik em niet aanzet
        StartCoroutine(InstRoom());
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerBehaviour>().moveAllow = false;
        Camera.main.GetComponent<PlayerLook>().lookAllow = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGen)
        {
            StopCoroutine(InstRoom());
            StartCoroutine(InstRoom());
            isGen = true;
        }

        if (isFinished)
        {
            loadingUI.SetActive(false);
            uiPlayer.SetActive(true);
            player.GetComponent<PlayerBehaviour>().moveAllow = true;
            Camera.main.GetComponent<PlayerLook>().lookAllow = true;
            isFinished = false;
        }

    }

    public IEnumerator InstRoom()
    {
        if (totalRooms <= maxRoomCount)
        {
            foreach (GameObject room in currentRooms)
            {
                foreach (GameObject door in room.GetComponent<Room>().doorRoomSpawners) 
                {
                    RoomSpawn(door);
                    yield return new WaitForSeconds(0.1f);
                }
            }
            ListsUpdate();
            isGen = false;
        }
        else
        {
            if (currentRoomIndex < totalRoomList.Count) //verkomt out of bound error
            {
                foreach (GameObject doorway in totalRoomList[currentRoomIndex].GetComponent<Room>().doorWays)
                {
                    if (Physics.Raycast(doorway.transform.position - rayDoorOffset, doorway.transform.forward, out hit, rayDoorLenght))
                    {
                        if(hit.transform.tag == "Door" && doorway.tag == "Door")
                        {
                            doorway.GetComponent<DoorwaySc>().isConnected = true;
                            if (!hit.transform.GetComponent<DoorwaySc>().isConnected)
                            {
                                DoorwayRemover();
                                yield return new WaitForSeconds(0.1f);
                            }
                        }
                        if (hit.transform.tag == "WallPiece" && doorway.tag == "Door")
                        {
                            doorway.GetComponent<DoorwaySc>().isConnected = true;
                            hit.transform.GetComponent<DoorwaySc>().isConnected = true;
                            DoorwayRemover();
                            yield return new WaitForSeconds(0.1f);
                        }
                    }  
                    if (!doorway.GetComponent<DoorwaySc>().isConnected &&!Physics.Raycast(doorway.transform.position - rayDoorOffset, doorway.transform.forward, rayDoorLenght)) // add layers if the final prefab blocks the ray
                    {
                        EmptyD(doorway);
                        yield return new WaitForSeconds(0.1f);
                    }
                    
                }
                currentRoomIndex++;
                isGen = false; 
            }
            else if (currentRoomIndex == totalRoomList.Count)
            {
                 FinalRoomSpawn();
            }
            
        }

    }


    void RoomSpawn(GameObject door)
    {
        if (!Physics.Raycast(door.transform.position - rayDoorOffset, door.transform.forward, rayLenght))
        {
            newRooms.Add(Instantiate(roomPrefabs[Random.Range(0, roomPrefabs.Length)], door.transform.position, door.transform.rotation, door.transform));
            newRooms[currNewRoomIndex].transform.localPosition += offset;
            currNewRoomIndex++;
            totalRooms++;
        }
    }

    void ListsUpdate()
    {
        currentRooms.Clear();
        for (int i = 0; i < newRooms.Count; i++)
        {
            GameObject room = newRooms[i];
            currentRooms.Add(room);
            totalRoomList.Add(room);
        }
        currentRoomIndex = 0;
        currNewRoomIndex = 0;
        newRooms.Clear();
    }

    void DoorwayRemover()
    {
        hit.transform.gameObject.SetActive(false);
    }
    
    void EmptyD(GameObject doorway)
    {
        emptyDoorWays.Add(doorway);
        if (doorway.tag != "WallPiece")
        {
            Instantiate(doorBlock, doorway.transform.position, doorway.transform.rotation, doorway.transform);
        }

    }

    void FinalRoomSpawn()
    {
        finalDoorway = emptyDoorWays[Random.Range(0, emptyDoorWays.Count)];
        finalRoom = gameObject.GetComponent<QuestManager>().activeQuest.finalDungeonRoom;
        if (!hasFinalRoom)
        {
            hasFinalRoom = true;
            totalRoomList.Add(Instantiate(finalRoom, finalDoorway.transform.position, finalDoorway.transform.rotation, finalDoorway.transform));
            totalRooms++;
            totalRoomList[totalRooms].transform.localPosition += offset;

            foreach (GameObject door in totalRoomList[totalRooms].GetComponent<Room>().doorWays)
            {
                if (Physics.Raycast(door.transform.position - rayDoorOffset, door.transform.forward, out hit, 5))
                {
                    totalRoomList[totalRooms].transform.SetParent(totalRoomList[0].transform, true);
                    DoorwayRemover();
                    Instantiate(bossDoor, door.transform.position, door.transform.rotation, totalRoomList[totalRooms].transform);
                    Destroy(door);
                }
            }
            isFinished = true;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(restartIndex);
    }

}
