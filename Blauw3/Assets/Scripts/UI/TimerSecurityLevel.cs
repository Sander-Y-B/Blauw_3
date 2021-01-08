﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerSecurityLevel : MonoBehaviour
{
    public float timerMinutes;
    public float timerSeconds;
    public Text textTimerMinutes;
    public Text textTimerSeconds;
    public bool runTimer;

    void Start()
    {
        
    }

    void Update()
    {
        if (runTimer == true)
        {
            timerSeconds -= Time.deltaTime;
            if(timerSeconds <= 0)
            {
                if(timerMinutes <= 0)
                {
                    //death
                }
                timerMinutes--;
                timerSeconds = 59;
            }

            if(timerMinutes < 10)
            {
                textTimerMinutes.text = "0" + timerMinutes.ToString();
            }
            else
            {
                textTimerMinutes.text = timerMinutes.ToString();
            }

            if (timerSeconds < 10)
            {
                textTimerSeconds.text = "0" + timerSeconds.ToString();
            }
            else
            {
                textTimerSeconds.text = timerSeconds.ToString();
            }

        }
    }

    public void PauseTimer()
    {
        runTimer = false;
    }

    public void StartTimer()
    {
        runTimer = true;
    }
}