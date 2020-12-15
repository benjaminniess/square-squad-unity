using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public static SettingsMenu instance;

    public Slider musicSlider;

    public Slider fxSlider;

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

        SaveData gameData = GameManager.instance.GetGameData();
        Debug.Log(gameData.GetMusicVolume());
        musicSlider.value = gameData.GetMusicVolume();
        fxSlider.value = gameData.GetFXVolume();
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
        GameManager.instance.SetMusicVolume((int) value);
    }

    public void HandleFXChange(float value)
    {
        GameManager.instance.SetFXVolume((int) value);
    }
}
