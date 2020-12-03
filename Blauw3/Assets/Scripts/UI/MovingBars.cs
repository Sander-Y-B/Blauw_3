using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBars : MonoBehaviour
{
    public float speed;
    public Vector3 minScale, maxScale;
    private Vector3 currentScale;
    // Start is called before the first frame update
    void Start()
    {
        currentScale = maxScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale != currentScale)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, currentScale, speed);
        }
        else
        {
            currentScale.y = Random.Range(minScale.y, maxScale.y);
        }
    }
}
