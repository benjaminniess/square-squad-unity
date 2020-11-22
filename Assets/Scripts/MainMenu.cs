using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public static MainMenu instance;

    private EventSystem eventSystem;

    private int selectedButton = 1;

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
        GameObject eventSystemGameObject = GameObject.Find("EventSystem");
        eventSystem =
            eventSystemGameObject
                .GetComponent<UnityEngine.EventSystems.EventSystem>();

        buttons = new Dictionary<int, GameObject>();
        GameObject[] buttonsGO = GameObject.FindGameObjectsWithTag("Button");
        int i = 1;
        foreach (GameObject buttonGO in buttonsGO)
        {
            Button buttonItem = buttonGO.GetComponent<Button>();
            if (!buttonItem.interactable)
            {
                continue;
            }

            if (i == selectedButton)
            {
                eventSystem.SetSelectedGameObject (buttonGO);
            }
            buttons.Add (i, buttonGO);

            i++;
        }
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

    public void Exit()
    {
        Application.Quit();
    }
}
