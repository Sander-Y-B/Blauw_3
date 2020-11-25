using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    public static bool isPaused;
    private float newPercent;
    public GameObject player, pause, options, mainPause;
    public Slider mainSlider, musicSlider, sfxSlider, healthSlider;

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            TogglePause();
        }
    }

    public void UpdateHealthBar(float newHealth, float maxHealth)
    {
        newPercent = newHealth/ maxHealth * 100;
        healthSlider.value = newPercent;
    }
    public void TogglePause()
    {
        if (pause.activeSelf == true)
        {
            if (options.activeSelf == true)
            {
                PlayerPrefs.SetFloat("mainVol", mainSlider.value);
                PlayerPrefs.SetFloat("musicVol", musicSlider.value);
                PlayerPrefs.SetFloat("sfxVol", sfxSlider.value);
                options.SetActive(false);
                mainPause.SetActive(true);
            }
            pause.SetActive(false);
            player.GetComponent<PlayerLook>().lookAllow = true;
            isPaused = false;
        }
        else
        {
            pause.SetActive(true);
            isPaused = true;
            player.GetComponent<PlayerLook>().lookAllow = false;
            Cursor.lockState = CursorLockMode.Confined;
        }
    }
    public void OpenOptions()
    {
        mainSlider.value = PlayerPrefs.GetFloat("mainVol");
        musicSlider.value = PlayerPrefs.GetFloat("musicVol");
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVol");
        mainPause.SetActive(false);
        options.SetActive(true);
    }

    public void OpenMainPause()
    {
        PlayerPrefs.SetFloat("mainVol", mainSlider.value);
        PlayerPrefs.SetFloat("musicVol", musicSlider.value);
        PlayerPrefs.SetFloat("sfxVol", sfxSlider.value);
        options.SetActive(false);
        mainPause.SetActive(true);
    }
    public void SceneSwitch(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
