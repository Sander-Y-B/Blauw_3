using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddDoor : MonoBehaviour
{
    public void Awake()
    {
        GetComponentInParent<SpawnEnemies>().doors.Add(gameObject);
        gameObject.SetActive(false);
    }
}
