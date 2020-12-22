using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InWorldPart : MonoBehaviour
{
    public GameObject partPrefab;

    GunManager gunManager;
    ShopScript shop;
    public GameObject myShopPoint;

    GameObject lastGunPart;
    GameObject newShopItem;

    private void Start()
    {
        shop = FindObjectOfType<ShopScript>();
        gunManager = FindObjectOfType<GunManager>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetButtonDown("Interact"))
        {
            StartCoroutine(PickUpPart());
        }
    }

    IEnumerator PickUpPart()
    {
        ReplaceShopItem();
        StartCoroutine(gunManager.UpdateGunPart(partPrefab));
        yield return new WaitForEndOfFrame();
        Destroy(gameObject);
    }

    void ReplaceShopItem()
    {
        switch (partPrefab.tag)
        {
            case "GunBody":
                lastGunPart = gunManager.gunLoadout[0].GetComponent<BasePart>().inWorldPrefab;
                break;
            case "GunLoader":
                lastGunPart = gunManager.gunLoadout[1].GetComponent<BasePart>().inWorldPrefab;
                break;
            case "GunBarrel":
                lastGunPart = gunManager.gunLoadout[2].GetComponent<BasePart>().inWorldPrefab;
                break;
            default:
                print("!!No tag or no object!! for pickup and replace");
                break;
        }
        newShopItem = Instantiate(lastGunPart, myShopPoint.transform);
        newShopItem.GetComponent<InWorldPart>().myShopPoint = myShopPoint;

        shop.ClearShop(myShopPoint);
    }

}
