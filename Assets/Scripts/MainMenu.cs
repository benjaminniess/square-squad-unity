using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class MainMenu : MonoBehaviour
{
    public static MainMenu instance;

    private EventSystem eventSystem;

    private int selectedButton;

    private Dictionary<int, GameObject> buttons;

    public void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }

        instance = this;
    }

    void Start()
    {
        Time.timeScale = 1;
        StartCoroutine(GameManager.instance.FadeLoadingScreen());

        GameManager.instance.StartMusic();

        GameObject eventSystemGameObject = GameObject.Find("EventSystem");
        eventSystem =
            eventSystemGameObject
                .GetComponent<UnityEngine.EventSystems.EventSystem>();

        eventSystem.SetSelectedGameObject(null);
        buttons = new Dictionary<int, GameObject>();
        GameObject[] buttonsGO = GameObject.FindGameObjectsWithTag("Button");
        Array.Sort( buttonsGO, sortByName );
        int i = 1;
        foreach (GameObject buttonGO in buttonsGO)
        {
            Button buttonItem = buttonGO.GetComponent<Button>();
            if (!buttonItem.interactable)
            {
                continue;
            }

            if (buttonGO.name == "1Multi")
            {
                selectedButton = i;
                eventSystem.SetSelectedGameObject (buttonGO);
                selectedButton = i;
            }
            buttons.Add (i, buttonGO);

            i++;
        }
    }

    public int sortByName( GameObject x, GameObject y )
    {
        return x.name.CompareTo( y.name );
    }

    public void ButtonPerformed(string button)
    {
        switch (button)
        {
            case "down":
                SelectNext();
                break;
            case "up":
                SelectPrev();
                break;
            case "east":
                Submit();
                break;
            default:
                break;
        }
    }

    void Submit()
    {
        if ( ! buttons.ContainsKey(selectedButton) ) {
            return;
        }

        buttons[selectedButton].GetComponent<Button>().onClick.Invoke();
    }

    void SelectNext()
    {
        selectedButton++;
        if (selectedButton > buttons.Count)
        {
            selectedButton = 1;
        }

        eventSystem.SetSelectedGameObject(buttons[selectedButton]);
    }

    void SelectPrev()
    {
        selectedButton--;
        if (selectedButton < 1)
        {
            selectedButton = buttons.Count;
        }

        eventSystem.SetSelectedGameObject(buttons[selectedButton]);
    }

    public void Lobby()
    {
        StartCoroutine(GameManager.instance.LoadScene("Lobby"));
    }

    public void Settings()
    {
        StartCoroutine(GameManager.instance.LoadScene("SettingsMenu"));
    }

    public void HowTo()
    {
        StartCoroutine(GameManager.instance.LoadScene("HowTo"));
    }

    public void Exit()
    {
        Application.Quit();
    }
}
