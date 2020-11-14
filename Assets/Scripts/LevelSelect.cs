using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public static LevelSelect instance;
    public GameObject LevelUIHolder;
    
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

        int imageWidth = Screen.width;
        int spawnX = 0;
        int spawnY = 0;
        foreach (KeyValuePair<string, Arena>
            ArenaObject
            in
            GameManager.instance.GetArenas()
        )
        {
            
            GameObject LevelUIObjeect = Instantiate(LevelUIHolder, new Vector3(spawnX, spawnY, 0), Quaternion.identity, gameObject.transform);
            LevelUIScript LevelUIScript = LevelUIObjeect.GetComponent<LevelUIScript>();
        }
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
