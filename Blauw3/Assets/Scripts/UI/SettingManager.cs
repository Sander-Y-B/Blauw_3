using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingManager : MonoBehaviour
{
    public AudioMixer mixer;

    private void Start()
    {
        mixer.SetFloat("MasterVol", Mathf.Log10(PlayerPrefs.GetFloat("mainVol")) * 20);
        mixer.SetFloat("MusicVol", Mathf.Log10(PlayerPrefs.GetFloat("musicVol")) * 20);
        mixer.SetFloat("SfxVol", Mathf.Log10(PlayerPrefs.GetFloat("sfxVol")) * 20);
    }
    public void SetMainVolume(float sliderValue)
    {
        mixer.SetFloat("MasterVol", Mathf.Log10(sliderValue) * 20);
    }
    public void SetMusicVolume(float sliderValue)
    {
        mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
    }
    public void SetSfxVolume(float sliderValue)
    {
        mixer.SetFloat("SfxVol", Mathf.Log10(sliderValue) * 20);
    }
}
