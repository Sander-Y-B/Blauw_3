using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public float speed, damage;


    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name != "Enemy")
        {
            other.transform.GetComponent<Health>().DoDamage(damage);
            Destroy(gameObject);
        }
        else if(other.gameObject.tag == "Prop" || other.gameObject.layer == 8)
        {
            Destroy(gameObject);
        }
    }
}
