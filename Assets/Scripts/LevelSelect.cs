using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public static LevelSelect instance;

    public GameObject LevelUIHolder;

    private int currentLevel = 1;

    private GameObject levelsUIContainer;

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

        levelsUIContainer = GameObject.Find("LevelsUIContainer");

        int spawnX = 0;
        int spawnY = 0;
        foreach (KeyValuePair<int, Arena>
            ArenaObject
            in
            GameManager.instance.GetArenas()
        )
        {
            GameObject LevelUIObjeect =
                Instantiate(LevelUIHolder,
                new Vector3(spawnX, spawnY, 0),
                Quaternion.identity,
                levelsUIContainer.transform);
            LevelUIScript LevelUIScript =
                LevelUIObjeect.GetComponent<LevelUIScript>();
            LevelUIScript.SetImage(ArenaObject.Value.GetPreviewImage());
            LevelUIScript.SetTitle(ArenaObject.Value.GetName());
            spawnX += Screen.width;
        }
    }

    public void LeftAction()
    {
        if (currentLevel <= 1)
        {
            return;
        }
        levelsUIContainer.transform.position =
            new Vector3(levelsUIContainer.transform.position.x + Screen.width,
                levelsUIContainer.transform.position.y,
                levelsUIContainer.transform.position.z);
        currentLevel -= 1;
    }

    public void RightAction()
    {
        if (currentLevel >= GameManager.instance.GetArenas().Count)
        {
            return;
        }
        levelsUIContainer.transform.position =
            new Vector3(levelsUIContainer.transform.position.x - Screen.width,
                levelsUIContainer.transform.position.y,
                levelsUIContainer.transform.position.z);
        currentLevel += 1;
    }

    public void SouthAction()
    {
        StartCoroutine(GameManager.instance.LoadScene("Lobby"));
    }

    public void EastAction()
    {
        foreach (KeyValuePair<int, Arena>
            ArenaObject
            in
            GameManager.instance.GetArenas()
        )
        {
            if (ArenaObject.Key == currentLevel)
            {
                StartCoroutine(GameManager
                    .instance
                    .LoadScene(ArenaObject.Value.GetSceneName()));
                return;
            }
        }
    }
}
