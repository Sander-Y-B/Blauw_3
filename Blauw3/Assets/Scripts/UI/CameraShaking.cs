using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaking : MonoBehaviour
{

    private float shakeCurrentTime = 0f;
    private Vector3 initialPosition;
    private bool isScreenShaking = false;
    public float shakeAmount = 10f, shakeTime = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shakeCurrentTime > 0 && isScreenShaking == true)
        {
            this.transform.position = Random.insideUnitSphere * shakeAmount + initialPosition;
            shakeCurrentTime -= Time.deltaTime;
        }
        else if (isScreenShaking == true)
        {
            this.transform.position = initialPosition;
            isScreenShaking = false;
        }
    }
    public void Shake()
    {
        shakeCurrentTime = shakeTime;
        initialPosition = this.transform.position;
        isScreenShaking = true;
    }
}
