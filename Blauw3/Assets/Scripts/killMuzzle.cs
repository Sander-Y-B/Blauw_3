using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killMuzzle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Pog());   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Pog()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
