using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed, damage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "PlayerBody")
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
