using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    public GameObject main, options;
    public Slider mainSlider, musicSlider, sfxSlider;
    public void OpenOptions()
    {
        mainSlider.value = PlayerPrefs.GetFloat("mainVol");
        musicSlider.value = PlayerPrefs.GetFloat("musicVol");
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVol");
        main.SetActive(false);
        options.SetActive(true);
    }

    public void OpenMain()
    {
        PlayerPrefs.SetFloat("mainVol", mainSlider.value);
        PlayerPrefs.SetFloat("musicVol", musicSlider.value);
        PlayerPrefs.SetFloat("sfxVol", sfxSlider.value);
        options.SetActive(false);
        main.SetActive(true);
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
