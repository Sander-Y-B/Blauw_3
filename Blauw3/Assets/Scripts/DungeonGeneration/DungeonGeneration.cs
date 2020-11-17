using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGeneration : MonoBehaviour
{
    public GameObject[] Rooms;
    public GameObject RoomPrefab;

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
                    RaycastHit hit;
                    if(Physics.Raycast(Door.transform.position, Door.transform.TransformDirection(Vector3.forward), out hit, 5))
                    {
                        if(hit.collider == null)
                        {
                            // instantiate room
                            // add to room list
                            // check if door can connect
                            // rooms spanwed ++
                            // current rooms ++
                        }
                    }
                }
            }
        }
    }

    private void DecideLocation()
    {

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