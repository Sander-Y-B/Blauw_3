using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using EZCameraShake;

public class MainMenu : MonoBehaviour
{
    public AudioSource buttonSound;
    public GameObject main, options, security, corners;
    public Slider mainSlider, musicSlider, sfxSlider, sensSlider;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;   
    }
    public void buttonPress()
    {
        buttonSound.Play();
    }
    public void OpenOptions()
    {
        CameraShaker.Instance.ShakeOnce(4f, 1f, .1f, .1f);
        mainSlider.value = PlayerPrefs.GetFloat("mainVol");
        musicSlider.value = PlayerPrefs.GetFloat("musicVol");
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVol");
        sensSlider.value = PlayerPrefs.GetFloat("mouseSens");
        main.SetActive(false);
        options.SetActive(true);
    }

    public void OpenMain()
    {
        CameraShaker.Instance.ShakeOnce(4f, 1f, .1f, .1f);
        PlayerPrefs.SetFloat("mainVol", mainSlider.value);
        PlayerPrefs.SetFloat("musicVol", musicSlider.value);
        PlayerPrefs.SetFloat("sfxVol", sfxSlider.value);
        PlayerPrefs.SetFloat("mouseSens", sensSlider.value);
        if (corners.activeSelf == false)
        {
            corners.SetActive(true);
        }
        options.SetActive(false);
        main.SetActive(true);
    }

    public void OpenSecurity()
    {
        CameraShaker.Instance.ShakeOnce(4f, 1f, .1f, .1f);
        main.SetActive(false);
        security.SetActive(true);
        corners.SetActive(false);
    }
    public void LoadGame(int scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void QuitGame()
    {
        print("Quit");
        Application.Quit();
    }
}
