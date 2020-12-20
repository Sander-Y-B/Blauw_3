using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    public GameObject[] shopItemSpawnPoints;
    public GameObject[] spawnableShopItemsList;

    GameObject newShopItem;
    int itemSpawnIndex;
    int shopPointIndex;
    public int[] inShopIds;

    void Start()
    {

        for (int i = 0; shopPointIndex < 3; i++)
        {
            itemSpawnIndex = Random.Range(0, spawnableShopItemsList.Length);

            if (itemSpawnIndex != inShopIds[0] && itemSpawnIndex != inShopIds[1] && itemSpawnIndex != inShopIds[2])
            {
                inShopIds[shopPointIndex] = itemSpawnIndex;

                newShopItem = Instantiate(spawnableShopItemsList[itemSpawnIndex], shopItemSpawnPoints[shopPointIndex].transform);
                newShopItem.GetComponent<InWorldPart>().myShopPoint = shopItemSpawnPoints[shopPointIndex];

                shopPointIndex++;
            }
        }
    }

    private void OnTriggerEnter(Collider player)
    {

        if (player.tag == "Player")
        {
            player.GetComponentInChildren<GunManager>().shootAllow = false;
            player.GetComponentInChildren<PlayerLook>().inShop = true;
        }
    }

    private void OnTriggerExit(Collider player)
    {
        if (player.tag == "Player")
        {
            player.GetComponentInChildren<GunManager>().shootAllow = true;
            player.GetComponentInChildren<PlayerLook>().inShop = false;
        }
    }

}
