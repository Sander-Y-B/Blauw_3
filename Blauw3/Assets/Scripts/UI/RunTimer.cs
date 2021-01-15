using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunTimer : MonoBehaviour
{
    public string SecurityLevelName;
    public string timerSecurityLevelName;
    public string playerName;
    public bool timerStarted;

    public void OnTriggerExit(Collider o)
    {
        if(o.gameObject.tag == playerName)
        {
            if(timerStarted == false)
            {
                if(GameObject.FindGameObjectWithTag(SecurityLevelName).GetComponent<SecurityLevel>().playerTimerSL > 0)
                {
                    GameObject.FindGameObjectWithTag(timerSecurityLevelName).GetComponent<TimerSecurityLevel>().StartTimer();
                    timerStarted = true;
                }
            }
        }
    }
}