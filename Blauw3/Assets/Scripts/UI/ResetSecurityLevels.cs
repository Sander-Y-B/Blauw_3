using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetSecurityLevels : MonoBehaviour
{
    public string securityLevelName;

    public void Start()
    {
        GameObject.FindGameObjectWithTag(securityLevelName).GetComponent<SecurityLevel>().ResetValues();
    }
}
