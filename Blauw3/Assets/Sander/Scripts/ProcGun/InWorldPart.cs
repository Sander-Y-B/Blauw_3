using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InWorldPart : MonoBehaviour
{
    public GameObject partPrefab;

    GunManager gunManager;

    bool isPickedUp = false;

    private void Start()
    {
        gunManager = FindObjectOfType<GunManager>();
    }

    public void PickUpPart()
    {
        if (!isPickedUp)
        {
            StartCoroutine(gunManager.UpdateGunPart(partPrefab));
            isPickedUp = true;
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetButtonDown("Interact"))
        {
            PickUpPart();
        }
    }


}
