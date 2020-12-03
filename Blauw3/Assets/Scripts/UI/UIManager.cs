using System.Collections;
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
    private float newPercent;
    public TextMeshProUGUI damageText, shotSpeedText, spreadText, scopeSpreadText, clipSizeText, reloadSpeedText, recoilText;
    public GameObject player, pause, options, mainPause;
    public Slider mainSlider, musicSlider, sfxSlider, healthSlider, sensSlider;

    private void Start()
    {
        player.GetComponentInChildren<PlayerLook>().mouseSense = PlayerPrefs.GetFloat("mouseSens");
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
        newPercent = newHealth/ maxHealth * 100;
        healthSlider.value = newPercent;
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
        sensSlider.value = PlayerPrefs.GetFloat("mouseSens");
        mainPause.SetActive(false);
        options.SetActive(true);
    }

    public void OpenMainPause()
    {
        PlayerPrefs.SetFloat("mainVol", mainSlider.value);
        PlayerPrefs.SetFloat("musicVol", musicSlider.value);
        PlayerPrefs.SetFloat("sfxVol", sfxSlider.value);
        PlayerPrefs.SetFloat("mouseSens", sensSlider.value);
        player.GetComponentInChildren<PlayerLook>().mouseSense = sensSlider.value;
        options.SetActive(false);
        mainPause.SetActive(true);
    }
    public void SceneSwitch(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
    public void buttonPress()
    {
        buttonSound.Play();
    }

}
