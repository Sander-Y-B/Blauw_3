using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dummy : MonoBehaviour
{
    public GameObject prefab;
    public float health, dissolveTime;
    private float maxHealth, healthPercent;
    public Slider healthSlider;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0) { DestroyEnemy(); }
        healthPercent = health / maxHealth * 100;
        healthSlider.value = healthPercent;
    }

    public virtual void DestroyEnemy()
    {
        health = maxHealth;
    }

}
