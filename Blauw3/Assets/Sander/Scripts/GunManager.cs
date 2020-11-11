using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    public GameObject[] gunBodies;
    public GameObject[] gunLoaders;
    public GameObject[] gunBarrels;

    GameObject loaderPoint;
    GameObject barrelPoint;
    GameObject shotPoint;
    GameObject currentGunBody;

    public GameObject bullet;


    private void Start()
    {
        SpawnNewGun();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SpawnNewGun();
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Instantiate(bullet, shotPoint.transform.position, shotPoint.transform.rotation);
        }
    }

    void SpawnNewGun()
    {
        if (currentGunBody != null)
        {
            Destroy(currentGunBody);
        }
        else
        {
            InstBody();
            InstLoader();
            InstBarrel();
        }

    }

    void InstBody()
    {
        currentGunBody = Instantiate(gunBodies[Random.Range(0, gunBodies.Length)], gameObject.transform, false);
        loaderPoint = GameObject.FindGameObjectWithTag("GunLoaderPoint");
    }

    void InstLoader()
    {
        Instantiate(gunLoaders[Random.Range(0, gunLoaders.Length)], loaderPoint.transform, false);
        barrelPoint = GameObject.FindWithTag("GunBarrelPoint");
    }

    void InstBarrel()
    {
        Instantiate(gunBarrels[Random.Range(0, gunBarrels.Length)], barrelPoint.transform, false);
        shotPoint = GameObject.FindWithTag("ShotPoint");
    }

}
