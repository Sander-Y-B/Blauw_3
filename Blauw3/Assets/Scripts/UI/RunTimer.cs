using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunTimer : MonoBehaviour
{
    public string timerSecurityLevelName;
    public bool timerStarted;

    public void OnTriggerExit(Collider o)
    {
        if(timerStarted == false)
        {
            GameObject.FindGameObjectWithTag(timerSecurityLevelName).GetComponent<TimerSecurityLevel>().StartTimer();
            timerStarted = true;
        }
    }
}
