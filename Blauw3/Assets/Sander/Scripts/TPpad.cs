using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPpad : MonoBehaviour
{

    public Vector3 tpLocation;
    public GameObject minimap;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.position = tpLocation;
            minimap.SetActive(true);
        }
    }
}
