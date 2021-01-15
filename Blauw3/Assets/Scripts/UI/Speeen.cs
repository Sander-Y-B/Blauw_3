using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speeen : MonoBehaviour
{
    public float speedHor, speedVer, speedDepth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(speedVer, speedHor, speedDepth);
    }
}
