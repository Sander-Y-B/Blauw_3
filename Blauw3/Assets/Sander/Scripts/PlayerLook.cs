using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public bool lookAllow = true;

    public float mouseSense = 100;
    public Transform playerBody;
    private float xRotation = 0f;

    public float recoilRotationSpeed = 6;
    public float recoilReturnSpeed = 25;

    public float recoilRotation;
    public float recoilRotationScoped;

    public bool isScoped;

    Vector3 currentRotation;
    Vector3 rot;
    float newXRot;

    void Awake()
    {
        mouseSense = mouseSense * 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (lookAllow)
        {
            Cursor.lockState = CursorLockMode.Locked;

            float mouseX = Input.GetAxis("Mouse X") * mouseSense * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSense * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            playerBody.Rotate(Vector3.up * mouseX);
            currentRotation = Vector3.Lerp(currentRotation, Vector3.zero, recoilReturnSpeed * Time.deltaTime);
            rot = Vector3.Slerp(rot, currentRotation, recoilRotationSpeed * Time.deltaTime);
            newXRot = rot.x + xRotation;
            transform.localRotation = Quaternion.Euler(newXRot, rot.y, rot.z);
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

    public void UpdateRecoil(float recoil)
    {
        float scopedRecoil = recoil - 1f;
        if (scopedRecoil < 0 )
        {
            scopedRecoil = 0;
        }

        recoilRotation = recoil;
        recoilRotationScoped = scopedRecoil;
    }

    public void AddRecoil()
    {
        
        if (isScoped)
        {
            currentRotation += new Vector3(-recoilRotationScoped, 0f, Random.Range(-recoilRotationScoped, recoilRotationScoped));
        }
        else
        {
            currentRotation += new Vector3(-recoilRotation, 0f, Random.Range(-recoilRotation, recoilRotation));
        }
        
    }
}