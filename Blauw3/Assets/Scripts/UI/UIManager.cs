﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class UIManager : MonoBehaviour
{
    public AudioSource buttonSound;
    public Animator gunStatAnim;
    public static bool isPaused;
    private float newHealthPercent, newAmmoPercent;
    public TextMeshProUGUI damageText, shotSpeedText, spreadText, scopeSpreadText, clipSizeText, reloadSpeedText, recoilText;
    public GameObject player, pause, options, mainPause, hud;
    public Slider mainSlider, musicSlider, sfxSlider, healthSlider, ammoSlider, sensSlider;

    public SecurityLevel securityLevel;


    private void Start()
    {
        Cursor.visible = false;
        securityLevel = GameObject.FindGameObjectWithTag("SecurityLevel").GetComponent<SecurityLevel>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("GunStat"))
        {
            gunStatAnim.SetBool("GunStat",!gunStatAnim.GetBool("GunStat"));
        }
        if (Input.GetButtonDown("Cancel"))
        {
            TogglePause();
        }
    }

    public void UpdateStats(float damage, float shotSpeed, float spread, float scopeSpread, float clipSize, float reloadSpeed, float recoil)
    {
        damageText.text = damage.ToString();
        shotSpeedText.text = shotSpeed.ToString();
        spreadText.text = spread.ToString();
        scopeSpreadText.text = scopeSpread.ToString();
        clipSizeText.text = clipSize.ToString();
        reloadSpeedText.text = reloadSpeed.ToString();
        recoilText.text = recoil.ToString();
    }

    public void UpdateHealthBar(float newHealth, float maxHealth)
    {
        newHealthPercent = newHealth/ maxHealth * 100;
        healthSlider.value = newHealthPercent;
    }

    public void UpdateAmmoBar(float newAmmo, float maxAmmo)
    {
        newAmmoPercent = newAmmo / maxAmmo * 100;
        ammoSlider.value = newAmmoPercent;
    }
    public void TogglePause()
    {
        if (pause.activeSelf == true)
        {
            if (options.activeSelf == true)
            {
                OpenMainPause();
            }
            pause.SetActive(false);
            hud.SetActive(true);
            player.GetComponentInChildren<PlayerLook>().lookAllow = true;
            player.GetComponentInChildren<GunManager>().shootAllow = true;
            player.GetComponent<PlayerMove>().moveAllow = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            isPaused = false;
        }
        else
        {
            pause.SetActive(true);
            hud.SetActive(false);
            player.GetComponentInChildren<PlayerLook>().lookAllow = false;
            player.GetComponentInChildren<GunManager>().shootAllow = false;
            player.GetComponent<PlayerMove>().moveAllow = false;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            isPaused = true;
        }
    }
    public void OpenOptions()
    {
        mainSlider.value = PlayerPrefs.GetFloat("mainVol");
        musicSlider.value = PlayerPrefs.GetFloat("musicVol");
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVol");
        sensSlider.value = PlayerPrefs.GetFloat("mouseSens");
        mainPause.SetActive(false);
        options.SetActive(true);
    }

    public void OpenMainPause()
    {
        PlayerPrefs.SetFloat("mainVol", mainSlider.value);
        PlayerPrefs.SetFloat("musicVol", musicSlider.value);
        PlayerPrefs.SetFloat("sfxVol", sfxSlider.value);
        player.GetComponentInChildren<PlayerLook>().mouseSense = PlayerPrefs.GetFloat("mouseSens");
        options.SetActive(false);
        mainPause.SetActive(true);
    }
    public void SceneSwitch(int sceneIndex)
    {
        securityLevel.SelfDestruct();
        SceneManager.LoadScene(sceneIndex);
    }
    public void buttonPress()
    {
        buttonSound.Play();
    }

}
