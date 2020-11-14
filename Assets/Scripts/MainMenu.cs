using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static MainMenu instance;

    public void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }

        instance = this;

        StartCoroutine(GameManager.instance.FadeLoadingScreen());
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
