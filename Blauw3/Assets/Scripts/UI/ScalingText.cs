using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScalingText : MonoBehaviour
{
    private Vector3 baseScale;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseHover()
    {
        baseScale = transform.localScale;
        transform.localScale = transform.localScale + new Vector3(0.1f, 0.1f, 0);
    }

    public void OnButtonPress()
    {
        if (transform.localScale != baseScale)
        {
            transform.localScale = baseScale;
        }
    }
    public void OnMouseHoverStop()
    {
        transform.localScale = baseScale;
    }
}
