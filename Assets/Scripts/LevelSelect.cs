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
        foreach (KeyValuePair<string, Arena>
            ArenaObject
            in
            GameManager.instance.GetArenas()
        )
        {
            StartCoroutine(GameManager
                .instance
                .LoadScene(ArenaObject.Value.GetSceneName()));
            return;
        }
    }
}
