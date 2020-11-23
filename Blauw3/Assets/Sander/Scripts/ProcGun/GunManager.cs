using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    public bool canShoot = true;
    public GameObject[] gunBodies;
    public GameObject[] gunLoaders;
    public GameObject[] gunBarrels;

    GameObject loaderPoint;
    GameObject barrelPoint;
    GameObject shotPoint;

    GameObject currentBody;
    GameObject currentLoader;
    GameObject currentBarrel;

    BasePart statsBody;
    BasePart statsLoader;
    BasePart statsBarrel;

    [HideInInspector] public float currentDamge;
    [HideInInspector] public float currentShotSpeed;
    [HideInInspector] public float currentSpread;
    [HideInInspector] public float currentScopedSpread;
    [HideInInspector] public float currentClipsize;
    [HideInInspector] public float currentReloadeSpeed;
    [HideInInspector] public float currentRecoil;

    GameObject bullet;
    GameObject newBullet;

    void Awake()
    {
        SpawnNewGun();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SpawnNewGun();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            print("spread: "+currentSpread + " firerate: "+ currentShotSpeed);

        }

        if (Input.GetButton("Fire1"))
        {
            Shoot();
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
            loaderPoint = GameObject.FindGameObjectWithTag("GunLoaderPoint");

            currentLoader = Instantiate(gunLoaders[Random.Range(0, gunLoaders.Length)], loaderPoint.transform, false);
            barrelPoint = GameObject.FindWithTag("GunBarrelPoint");

            currentBarrel = Instantiate(gunBarrels[Random.Range(0, gunBarrels.Length)], barrelPoint.transform, false);
            shotPoint = GameObject.FindWithTag("ShotPoint");
        }

        UpdateGunStats();
    }

    void UpdateGunStats()
    {
        statsBody = currentBody.GetComponent<BasePart>();
        statsLoader = currentLoader.GetComponent<BasePart>();
        statsBarrel = currentBarrel.GetComponent<BasePart>();

        bullet = statsLoader.bullet;

        currentShotSpeed = statsBody.baseShotSpeed + statsLoader.modShotSpeed + statsBarrel.modShotSpeed;
        currentSpread = statsBody.baseShotSpread + statsLoader.modShotSpread + statsBarrel.modShotSpread;
        currentScopedSpread = statsBody.baseShotSpread + statsLoader.modScopedSpread + statsBarrel.modScopedSpread - 0.5f;

        currentDamge = statsLoader.baseDamage + statsBody.modDamage + statsBarrel.modDamage;
        currentClipsize = statsLoader.baseClipsize;
        currentReloadeSpeed = statsLoader.baseReloadSpeed + statsBody.modReloadSpeed + statsBarrel.modReloadSpeed;

        currentRecoil = statsBarrel.baseRecoil + statsBody.modRecoil + statsBody.modRecoil;
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

    void Shoot()
    {
        if (canShoot)
        {
            newBullet = Instantiate(bullet, shotPoint.transform.position, shotPoint.transform.rotation);
            newBullet.GetComponent<BulletScript>().UpdateDamage(currentDamge);
            newBullet.GetComponent<BulletScript>().AddSpread(currentSpread);

            StartCoroutine(ShotDelay());

            //play shot sound fx
            
        }
 

    }

    IEnumerator ShotDelay()
    {
        canShoot = false;
        yield return new WaitForSeconds(currentShotSpeed);
        canShoot = true;
        
    }

}
