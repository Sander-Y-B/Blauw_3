using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InWorldPart : MonoBehaviour
{
    public GameObject partPrefab;

    GunManager gunManager;

    private void Start()
    {
        gunManager = FindObjectOfType<GunManager>();
    }

    public void PickUpPart()
    {
        StartCoroutine(gunManager.UpdateGunPart(partPrefab));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PickUpPart();
        }
    }

}
