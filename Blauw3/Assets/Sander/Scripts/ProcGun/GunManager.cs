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

    GameObject currentBody;
    GameObject currentLoader;
    GameObject currentBarrel;

    BasePart bodyStats;
    BasePart loaderStats;
    BasePart barrelStats;

    
    [HideInInspector] public float currentDamge;
    [HideInInspector] public float currentShotSpeed;
    [HideInInspector] public float currentSpread;
    [HideInInspector] public float currentScopedSpread;
    [HideInInspector] public float currentClipsize;
    [HideInInspector] public float currentReloadeSpeed;
    [HideInInspector] public float currentRecoil;
    GameObject bullet;

    void Awake()
    {
        SpawnNewGun();
    }

    void Start()
    {

    }

    void Update()
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
        if (currentBody != null)
        {
            Destroy(currentBody);
        }
        else
        {
            currentBody = Instantiate(gunBodies[Random.Range(0, gunBodies.Length)], gameObject.transform, false);
            currentLoader = Instantiate(gunLoaders[Random.Range(0, gunLoaders.Length)], loaderPoint.transform, false);
            currentBarrel = Instantiate(gunBarrels[Random.Range(0, gunBarrels.Length)], barrelPoint.transform, false);

            loaderPoint = GameObject.FindGameObjectWithTag("GunLoaderPoint");
            barrelPoint = GameObject.FindWithTag("GunBarrelPoint");
            shotPoint = GameObject.FindWithTag("ShotPoint");
        }

        UpdateGunStats();
    }

    void UpdateGunStats()
    {
        bodyStats = currentBody.GetComponent<BasePart>();
        loaderStats = currentLoader.GetComponent<BasePart>();
        barrelStats = currentBarrel.GetComponent<BasePart>();


        currentShotSpeed = bodyStats.baseShotSpeed;//+ or * mod
        currentSpread = bodyStats.baseShotSpread;
        currentScopedSpread = bodyStats.baseShotSpread - 0.5f;

        currentDamge = loaderStats.baseDamage; 
        currentClipsize = loaderStats.baseClipsize;
        currentReloadeSpeed = loaderStats.baseReloadSpeed;

        currentRecoil = barrelStats.baseRecoil;
        //call naar de UI waar de stats op de UI worden geupdate
    }

    void UpdateGunPart(GameObject newPart)
    {
        //select the part/category that needs to be replaced
        //save the childeren of the TBR part (To Be Replaced)
        //remove TBR part and instan the newPart
        //place the saved childeren as child of the newPart 
        //update the stat screen/Ui
    }


}
