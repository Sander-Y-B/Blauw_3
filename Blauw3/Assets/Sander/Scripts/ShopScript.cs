using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour
{

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
