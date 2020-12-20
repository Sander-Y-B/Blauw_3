using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    [HideInInspector] public bool shootAllow = true; // this is for other scripts to completely prefent the player from shooting
    bool canShoot = true; // this one is for functions here to prefent shooting
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
    [HideInInspector] public float currentMaxClipsize;
    [HideInInspector] public float currentReloadSpeed;
    [HideInInspector] public float currentRecoil;

    GameObject bullet;
    GameObject newBullet;

    public float currentAmmoAmount;

    public AudioSource shotFx;

    UIManager uIManager;
    PlayerLook playerLookScript;

    public GameObject testPart;

    void Awake()
    {
        playerLookScript = Camera.main.GetComponent<PlayerLook>();
        uIManager = FindObjectOfType<UIManager>();
        SpawnNewGun(gunBodies[Random.Range(0, gunBodies.Length)], gunLoaders[Random.Range(0, gunLoaders.Length)], gunBarrels[Random.Range(0, gunBarrels.Length)]);
    }

    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Shoot();
        }
        else if (Input.GetButtonDown("Reload"))
        {
            StartCoroutine(ReloadGun()); 
            StopCoroutine(ReloadGun()); 
        }


        if (Input.GetKeyDown(KeyCode.U))
        {
            StartCoroutine(UpdateGunPart(testPart));

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
        if (currentScopedSpread <0)
        {
            currentScopedSpread = 0;
        } 

        currentDamge = statsLoader.baseDamage + statsBody.modDamage + statsBarrel.modDamage;
        currentMaxClipsize = statsLoader.baseClipsize;
        currentAmmoAmount = currentMaxClipsize;
        currentReloadSpeed = statsLoader.baseReloadSpeed + statsBody.modReloadSpeed + statsBarrel.modReloadSpeed;

        currentRecoil = statsBarrel.baseRecoil + statsBody.modRecoil + statsLoader.modRecoil;
        if (currentRecoil <0)
        {
            currentRecoil = 0;
        }
        playerLookScript.UpdateRecoil(currentRecoil);

        if (uIManager != null)
        {
            uIManager.UpdateStats(currentDamge, currentShotSpeed, currentSpread, currentScopedSpread, currentMaxClipsize, currentReloadSpeed, currentRecoil);
        }


        gunLoadout[0] = gunBodies[statsBody.partIndex];
        gunLoadout[1] = gunLoaders[statsLoader.partIndex];
        gunLoadout[2] = gunBarrels[statsBarrel.partIndex];
    }

    public IEnumerator UpdateGunPart(GameObject newPart)
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

    void Shoot()
    {
        float spreadAmount;

        if (canShoot && shootAllow)
        {
            if (currentAmmoAmount >= 1)
            {
                if (playerLookScript.isScoped)
                {
                    spreadAmount = currentScopedSpread;
                }
                else
                {
                    spreadAmount = currentSpread;
                }

                newBullet = Instantiate(bullet, shotPoint.transform.position, shotPoint.transform.rotation);
                newBullet.GetComponent<BulletScript>().UpdateDamage(currentDamge);
                newBullet.GetComponent<BulletScript>().AddSpread(spreadAmount);
                playerLookScript.AddRecoil();

                shotFx.Play();
                currentAmmoAmount--;
                if (uIManager != null)
                {
                    uIManager.UpdateAmmoBar(currentAmmoAmount, currentMaxClipsize);
                }
                StartCoroutine(ShotDelay()); 
                StopCoroutine(ShotDelay()); 
            }
            else
            {
                StartCoroutine(ReloadGun());
                StopCoroutine(ReloadGun()); 
            }
            
          
        }
    }

    IEnumerator ShotDelay()
    {
        canShoot = false;
        yield return new WaitForSeconds(currentShotSpeed);
        canShoot = true;
    }

    IEnumerator ReloadGun()
    {
        if (canShoot)
        {
            
            canShoot = false;
            yield return new WaitForSeconds(currentReloadSpeed);
            currentAmmoAmount = currentMaxClipsize;
            if (uIManager != null)
            {
                uIManager.UpdateAmmoBar(currentAmmoAmount, currentMaxClipsize);
            }
            canShoot = true;
        }

    }
}
