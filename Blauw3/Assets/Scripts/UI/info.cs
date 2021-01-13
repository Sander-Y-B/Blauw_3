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
    public InWorldPart inWorldPart;
    public BasePart basePart;
    public TextMeshProUGUI damage, attackSpeed, spread, scopeSpread, clipSize, reloadSpeed, recoil;
    // Start is called before the first frame update
    void Start()
    {
        basePart = inWorldPart.partPrefab.GetComponent<BasePart>();
        gunManager = FindObjectOfType<GunManager>();
        UpdateGunStats();
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
        damage.text = currentDamge.ToString();
        attackSpeed.text = currentShotSpeed.ToString();
        spread.text = currentSpread.ToString();
        scopeSpread.text = currentScopedSpread.ToString();
        clipSize.text = currentMaxClipsize.ToString();
        reloadSpeed.text = currentReloadSpeed.ToString();
        recoil.text = currentRecoil.ToString();
    }
}
