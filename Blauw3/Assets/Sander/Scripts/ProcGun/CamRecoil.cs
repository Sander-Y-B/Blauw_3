using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRecoil : MonoBehaviour
{
    public float rotationSpeed = 6;
    public float returnSpeed = 25;

    public Vector3 recoilRotation = new Vector3(2f, 2f, 2f);

    public Vector3 recoilRotationScoped = new Vector3(0.5f, 0.5f, 1.5f);

    public bool isScoped;

    Vector3 currentRotation;
    Vector3 rot;

    void FixedUpdate()
    {
        currentRotation = Vector3.Lerp(currentRotation, Vector3.zero, returnSpeed * Time.deltaTime);
        rot = Vector3.Slerp(rot, currentRotation, rotationSpeed * Time.deltaTime);
        transform.localRotation = Quaternion.Euler(rot);
    }

    void Fire()
    {
        if (isScoped)
        {
            currentRotation += new Vector3(-recoilRotationScoped.x, Random.Range(-recoilRotationScoped.y, recoilRotationScoped.y), Random.Range(-recoilRotationScoped.z, recoilRotationScoped.z));
        }
        else
        {
            currentRotation += new Vector3(-recoilRotation.x, Random.Range(-recoilRotation.y, recoilRotation.y), Random.Range(-recoilRotation.z, recoilRotation.z));
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
        if (Input.GetButton("Fire2"))
        {
            isScoped = true;
        }
        else
        {
            isScoped = false;
        }
    }

}
