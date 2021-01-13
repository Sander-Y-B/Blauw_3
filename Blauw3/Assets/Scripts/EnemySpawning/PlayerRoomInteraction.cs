using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRoomInteraction : MonoBehaviour
{
    public string roomTagName;
    private SpawnEnemies spawnEnemies;
    GunManager gunManager;

    private void Start()
    {
        gunManager = FindObjectOfType<GunManager>();
    }

    public void OnTriggerEnter(Collider o)
    {
        if(o.gameObject.tag == roomTagName)
        {
            if(o.gameObject.GetComponent<Room>().winRoom == false)
            {
                spawnEnemies = o.gameObject.GetComponent<SpawnEnemies>();
                spawnEnemies.RoomStart();
            }
            else
            {
                gunManager.SaveGunparts();
                SceneManager.LoadScene(0);
            }
        }
    }
}