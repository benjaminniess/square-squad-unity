using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    public static SettingsMenu instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy (gameObject);
        }

        instance = this;
    }

    void Start()
    {
        StartCoroutine(GameManager.instance.FadeLoadingScreen());
    }

    void Update()
    {
    }

    public void ButtonPerformed(string button)
    {
        switch (button)
        {
            case "left":
                break;
            case "right":
                break;
            case "south":
                StartCoroutine(GameManager.instance.LoadScene("MainMenu"));
                break;
            case "east":
                StartCoroutine(GameManager.instance.LoadScene("MainMenu"));
                break;
            default:
                break;
        }
    }

    public void HandleMusicChange(float value)
    {
        int volumeLevel = (int)(value * 100);
        GameManager.instance.SetMusicVolume (volumeLevel);
    }

    public void HandleFXChange(float value)
    {
        int volumeLevel = (int)(value * 100);
        GameManager.instance.SetFXVolume (volumeLevel);
    }
}
