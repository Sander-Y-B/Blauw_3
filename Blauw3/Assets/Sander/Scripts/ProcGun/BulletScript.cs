using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed;
    private float damage = 1;
    float timeUntilDespawn = 2;

    // Update is called once per frame
    void Update()
    { 
        transform.Translate(0, 0, speed * Time.deltaTime);
        timeUntilDespawn -= Time.deltaTime;
        if (timeUntilDespawn <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.transform.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject);
        }
        else if (other.gameObject.layer == 8)
        {
            Destroy(gameObject);
        }
       
    }

    public void UpdateDamage(float newDamage)
    {
        damage = newDamage;
    }

    public void AddSpread(float spreadAmount)
    {
        transform.Rotate(Random.Range(-spreadAmount, spreadAmount), Random.Range(-spreadAmount, spreadAmount), transform.rotation.z);
    }
}
