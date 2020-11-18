using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePart : MonoBehaviour
{
    //Base vars doen niks als ze een waarde kruigen buiten hun categorie.
    //Mod vars kunnen op alle categorien gebruikt worden. (0 = geen mod)


    [Header("---Categorie: Body---")]
    public float baseShotSpeed;
    public float baseShotSpread;
    public float modDamage;
    public float modRecoil;

    [Header("---Categorie: Loader---")]
    public GameObject bullet;     //Alleen bij loader (dit is practisch een base var)
    public int baseClipsize;
    public float baseReloadSpeed;
    public float baseDamage;

    [Header("---Categorie: Barrel---")]
    public float baseRecoil;
    public float modShotSpread;
    public float modReloadSpeed;
    public float modScopedSpread; // AimedSpread heeft een base die word aangemaakt in runtime die hetzelfde is als de baseShotSpread.
    
}
