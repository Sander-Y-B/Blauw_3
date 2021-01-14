using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TimerSecurityLevel : MonoBehaviour
{
    public float timerMinutes;
    public float timerSeconds;
    public TextMeshProUGUI textTimerMinutes;
    public TextMeshProUGUI textTimerSeconds;
    public bool runTimer;

    [HideInInspector] public SecurityLevel securityLevel;
    [Header("Security Level")]
    public string securityLevelTag;

    void Start()
    {
        securityLevel = GameObject.FindGameObjectWithTag(securityLevelTag).GetComponent<SecurityLevel>();
        if (securityLevel != null)
        {
            if (securityLevel.playerTimerSL > 0)
            {
                timerMinutes = securityLevel.playerTimerAS;
                UpdateTimer();
                return;
            }
        }
        gameObject.SetActive(false);
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
                    SceneManager.LoadScene(0);
                }
                timerMinutes--;
                timerSeconds = 59;
            }

            UpdateTimer();
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

    public void UpdateTimer()
    {
        if (timerMinutes < 10)
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