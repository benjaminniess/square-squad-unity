using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public static LevelSelect instance;

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

    public void SouthAction()
    {
        StartCoroutine(GameManager.instance.LoadScene("Lobby"));
    }

    public void EastAction()
    {
        StartCoroutine(GameManager.instance.LoadScene("Arena1"));
    }
}
