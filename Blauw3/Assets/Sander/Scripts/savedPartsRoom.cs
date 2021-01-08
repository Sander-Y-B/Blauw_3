using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class savedPartsRoom : MonoBehaviour
{
    GunManager gunManager;

    public GameObject[] savedBodiesPrefabs;
    public GameObject[] savedLoadersPrefabs;
    public GameObject[] savedBarrelsPrefabs;

    void Start()
    {
        gunManager = FindObjectOfType<GunManager>();
        gunManager.LoadGunparts();
        SpawnSavedParts();
    }



    void SpawnSavedParts()
    {
        for (int i = 0; i < gunManager.savedGunBodies.Count; i++)
        {
            int spawnIndex = gunManager.savedGunBodies[i];
            savedBodiesPrefabs[spawnIndex].SetActive(true);
        }
        for (int i = 0; i < gunManager.savedGunLoaders.Count; i++)
        {
            int spawnIndex = gunManager.savedGunLoaders[i];
            savedLoadersPrefabs[spawnIndex].SetActive(true);
        }
        for (int i = 0; i < gunManager.savedGunBarrels.Count; i++)
        {
            int spawnIndex = gunManager.savedGunBarrels[i];
            savedBarrelsPrefabs[spawnIndex].SetActive(true);
        }
    }
}
