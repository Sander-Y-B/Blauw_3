using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class info : MonoBehaviour
{
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

    GunManager gunManager;
    public GameObject player, panel;
    public InWorldPart inWorldPart;
    public BasePart basePart;
    public TextMeshProUGUI damage, attackSpeed, spread, scopeSpread, clipSize, reloadSpeed, recoil;
    // Start is called before the first frame update
    void Start()
    {
        inWorldPart = GetComponentInParent<InWorldPart>();
        player = Camera.main.gameObject;
        basePart = inWorldPart.partPrefab.GetComponent<BasePart>();
        gunManager = FindObjectOfType<GunManager>();
        UpdateGunStats();
    }

    private void Update()
    {
        LookAtPlayer();
    }
    void UpdateGunStats()
    {
        if (basePart.gameObject.tag == "GunBody")
        {
            statsBody = basePart;
            statsLoader = gunManager.currentLoader.GetComponent<BasePart>();
            statsBarrel = gunManager.currentBarrel.GetComponent<BasePart>();
        }
        else if(basePart.gameObject.tag == "GunLoader")
        {
            statsBody = gunManager.currentBody.GetComponent<BasePart>();
            statsLoader = basePart;
            statsBarrel = gunManager.currentBarrel.GetComponent<BasePart>();
        }
        else
        {
            statsBody = gunManager.currentBody.GetComponent<BasePart>();
            statsLoader = gunManager.currentLoader.GetComponent<BasePart>();
            statsBarrel = basePart;
        }

        currentShotSpeed = statsBody.baseShotSpeed + statsLoader.modShotSpeed + statsBarrel.modShotSpeed;
        currentSpread = statsBody.baseShotSpread + statsLoader.modShotSpread + statsBarrel.modShotSpread;
        currentScopedSpread = statsBody.baseShotSpread + statsLoader.modScopedSpread + statsBarrel.modScopedSpread - 0.5f;
        if (currentScopedSpread < 0)
        {
            currentScopedSpread = 0;
        }

        currentDamge = statsLoader.baseDamage + statsBody.modDamage + statsBarrel.modDamage;
        currentMaxClipsize = statsLoader.baseClipsize;
        currentReloadSpeed = statsLoader.baseReloadSpeed + statsBody.modReloadSpeed + statsBarrel.modReloadSpeed;

        currentRecoil = statsBarrel.baseRecoil + statsBody.modRecoil + statsLoader.modRecoil;
        if (currentRecoil < 0)
        {
            currentRecoil = 0;
        }
        UpdateText();
    }

    public void UpdateText()
    {
        damage.text = currentDamge.ToString("f1");
        attackSpeed.text = currentShotSpeed.ToString("f1");
        spread.text = currentSpread.ToString("f1");
        scopeSpread.text = currentScopedSpread.ToString("f1");
        clipSize.text = currentMaxClipsize.ToString("f1");
        reloadSpeed.text = currentReloadSpeed.ToString("f1");
        recoil.text = currentRecoil.ToString("f1");
    }

    public void LookAtPlayer()
    {
        transform.LookAt(player.transform.position);
    }
}
