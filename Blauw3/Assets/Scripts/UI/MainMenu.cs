using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject main, options;
    public void OpenOptions()
    {
        main.SetActive(false);
        options.SetActive(true);
    }

    public void OpenMain()
    {
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
