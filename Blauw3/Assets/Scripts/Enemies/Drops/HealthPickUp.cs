using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    public string playerTag;

    public float healValue;

    public void OnTriggerEnter(Collider o)
    {
        if(o.gameObject.tag == playerTag)
        {
            o.gameObject.GetComponent<Health>().DoHeal(healValue);
            Destroy(gameObject);
        }
    }
}
