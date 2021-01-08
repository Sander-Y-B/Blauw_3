using System.Collections;
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
                textTimerMinutes.text = "0" + Mathf.RoundToInt(timerMinutes).ToString();
            }
            else
            {
                textTimerMinutes.text = Mathf.RoundToInt(timerMinutes).ToString();
            }

            if (timerSeconds < 10)
            {
                textTimerSeconds.text = "0" + Mathf.RoundToInt(timerSeconds).ToString();
            }
            else
            {
                textTimerSeconds.text = Mathf.RoundToInt(timerSeconds).ToString();
            }
        }
    }

    public void StartTimer()
    {
        runTimer = true;
    }

    public void PauseTimer()
    {
        runTimer = false;
    }
}