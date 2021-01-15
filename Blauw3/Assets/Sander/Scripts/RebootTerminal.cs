using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RebootTerminal : MonoBehaviour
{
    RaycastHit hit;
    public int rayRange = 5;

    Camera player;
    GunManager gunManager;
    public SecurityLevel securityLevel;

    private void Start()
    {
        player = Camera.main;
        gunManager = FindObjectOfType<GunManager>();
        securityLevel = GameObject.FindGameObjectWithTag("SecurityLevel").GetComponent<SecurityLevel>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {

            if (Input.GetButtonDown("Interact") && Physics.Raycast(transform.position, transform.forward, out hit, rayRange))
            {
                if (hit.transform.tag == "RebootTerminal")
                {
                    WinGame();

                }
            }
        }
       
    }

    void WinGame()
    {
        gunManager.SaveGunparts();
        securityLevel.SelfDestruct();
        //Cursor.lockState = CursorLockMode.Confined;
        //show win menu?
        SceneManager.LoadScene(0);
    }

   
}
