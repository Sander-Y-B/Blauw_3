using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPanelCheck : MonoBehaviour
{
    public float rayRange = 5;
    public bool inRange;
    private GameObject currentHit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (inRange == true)
        //{
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, rayRange))
            {
                print(hit.transform.gameObject.name);
                if (hit.transform.gameObject.tag == "Part")
                {
                    currentHit = hit.transform.GetComponentInChildren<info>().panel;

                    if (currentHit.activeSelf == false)
                    {
                        currentHit.SetActive(true);
                    }
                }
            }
            else if (currentHit.activeSelf == true)
            {
                currentHit.SetActive(false);
            }
        //}
        //else if (currentHit != null)
        //{
        //    if (currentHit.activeSelf == true)
        //    {
        //        currentHit.SetActive(false);
        //    }
        //}
    }
}
