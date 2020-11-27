using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    public bool canShoot = true;
    [SerializeField] GameObject[] gunBodies;
    [SerializeField] GameObject[] gunLoaders;
    [SerializeField] GameObject[] gunBarrels;
    public GameObject[] gunLoadout;

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

    public GameObject testPart;

    void Awake()
    {
        SpawnNewGun(gunBodies[Random.Range(0, gunBodies.Length)], gunLoaders[Random.Range(0, gunLoaders.Length)], gunBarrels[Random.Range(0, gunBarrels.Length)]);
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            StartCoroutine(UpdateGunPart(testPart));
        }

        if (Input.GetButton("Fire1"))
        {
            Shoot(currentSpread);
        }
        if (Input.GetButton("Fire2")) 
        {
            Shoot(currentScopedSpread);
        }
    }


    void SpawnNewGun(GameObject body, GameObject loader, GameObject barrel)
    {
        
        currentBody = Instantiate(body, gameObject.transform, false);
        loaderPoint = GameObject.FindGameObjectWithTag("GunLoaderPoint");

        currentLoader = Instantiate(loader, loaderPoint.transform, false);
        barrelPoint = GameObject.FindWithTag("GunBarrelPoint");

        currentBarrel = Instantiate(barrel, barrelPoint.transform, false);
        shotPoint = GameObject.FindWithTag("ShotPoint");

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

        gunLoadout[0] = gunBodies[statsBody.partIndex];
        gunLoadout[1] = gunLoaders[statsLoader.partIndex];
        gunLoadout[2] = gunBarrels[statsBarrel.partIndex];
    }

    IEnumerator UpdateGunPart(GameObject newPart)
    {
        switch (newPart.tag)
        {
            case "GunBody":
                gunLoadout[0] = newPart;
                break;
            case "GunLoader":
                gunLoadout[1] = newPart;
                break;
            case "GunBarrel":
                gunLoadout[2] = newPart;
                break;
            default:
                print("!!No tag or no object!!");
                break;
        }
        Destroy(currentBody);
        yield return new WaitForEndOfFrame();
        SpawnNewGun(gunLoadout[0], gunLoadout[1], gunLoadout[2]);
    }

    void Shoot(float spreadAmount)
    {
        if (canShoot)
        {
            newBullet = Instantiate(bullet, shotPoint.transform.position, shotPoint.transform.rotation);
            newBullet.GetComponent<BulletScript>().UpdateDamage(currentDamge);
            newBullet.GetComponent<BulletScript>().AddSpread(spreadAmount);

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
