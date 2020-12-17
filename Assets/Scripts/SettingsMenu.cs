using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public static SettingsMenu instance;

    public Slider musicSlider;

    public Slider fxSlider;

    public Slider ennemiesCountSlider;

    public Slider ennemiesSpeedSlider;

    public Slider bonusCountSlider;

    public Slider coinsCountSlider;

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

        musicSlider.value = gameData.GetMusicVolume();
        fxSlider.value = gameData.GetFXVolume();
        ennemiesCountSlider.value = gameData.GetEnnemmiesCount();
        ennemiesSpeedSlider.value = gameData.GetEnnemiesSpeed();
        bonusCountSlider.value = gameData.GetBonusCount();
        coinsCountSlider.value = gameData.GetCoinsCount();
    }

    void Update()
    {
    }

    public void ButtonPerformed(string button)
    {
        switch (button)
        {
            case "left":
                FindObjectOfType<AudioManager>().Play("Fire");
                break;
            case "right":
                FindObjectOfType<AudioManager>().Play("Fire");
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

    public void HandleEnnemiesSpeedChange(float value)
    {
        SaveData gameData = GameManager.instance.GetGameData();

        gameData.SetEnnemiesSpeed((int) value);
        GameManager.instance.SaveGameData (gameData);
    }

    public void HandleEnnemiesNumberChange(float value)
    {
        SaveData gameData = GameManager.instance.GetGameData();

        gameData.SetEnnemiesCount((int) value);
        GameManager.instance.SaveGameData (gameData);
    }

    public void HandlBonusNumberChange(float value)
    {
        SaveData gameData = GameManager.instance.GetGameData();

        gameData.SetBonusCount((int) value);
        GameManager.instance.SaveGameData (gameData);
    }

    public void HandleSquaresNumberChange(float value)
    {
        SaveData gameData = GameManager.instance.GetGameData();

        gameData.SetCoinsCount((int) value);
        GameManager.instance.SaveGameData (gameData);
    }
}
