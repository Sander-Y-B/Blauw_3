using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public bool moveAllow = true;

    float currentSpeed;
    [SerializeField] float baseSpeed = 10;
    [SerializeField] float sprintSpeed = 15;
    private Vector3 move;

    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = baseSpeed;
    }

    void FixedUpdate()
    {
        if (moveAllow)
        {
            move.x = Input.GetAxis("Horizontal");
            move.z = Input.GetAxis("Vertical");
            transform.Translate(move * Time.deltaTime * currentSpeed);

            if (Input.GetButton("Sprint"))
            {
                currentSpeed = sprintSpeed;

            }
            else
            {
                currentSpeed = baseSpeed;
            }
        }
    }
}
