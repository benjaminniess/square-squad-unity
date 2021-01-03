using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public static LevelSelect instance;

    public GameObject LevelUIHolder;

    public GameObject ArrowPrev;

    public GameObject ArrowNext;

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

        ArrowPrev.SetActive(false);
        ArrowNext.SetActive(true);
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

        // Set the slider to the latest savec level
        currentLevel = GameManager.instance.GetCurrentArenaID();
        if (currentLevel > 1)
        {
            levelsUIContainer.transform.position =
                new Vector3(levelsUIContainer.transform.position.x -
                    ((currentLevel - 1) * Screen.width),
                    levelsUIContainer.transform.position.y,
                    levelsUIContainer.transform.position.z);
            ArrowPrev.SetActive(currentLevel != 1);
            ArrowNext
                .SetActive(currentLevel !=
                GameManager.instance.GetArenas().Count);
        }
    }

    public void ButtonPerformed(string button)
    {
        switch (button)
        {
            case "left":
                if (currentLevel <= 1)
                {
                    return;
                }
                levelsUIContainer.transform.position =
                    new Vector3(levelsUIContainer.transform.position.x +
                        Screen.width,
                        levelsUIContainer.transform.position.y,
                        levelsUIContainer.transform.position.z);
                currentLevel -= 1;

                ArrowPrev.SetActive(currentLevel != 1);
                ArrowNext.SetActive(true);
                GameManager.instance.setCurrentArenaID (currentLevel);
                break;
            case "right":
                if (currentLevel >= GameManager.instance.GetArenas().Count)
                {
                    return;
                }
                levelsUIContainer.transform.position =
                    new Vector3(levelsUIContainer.transform.position.x -
                        Screen.width,
                        levelsUIContainer.transform.position.y,
                        levelsUIContainer.transform.position.z);
                currentLevel += 1;

                ArrowNext
                    .SetActive(currentLevel !=
                    GameManager.instance.GetArenas().Count);
                ArrowPrev.SetActive(true);
                GameManager.instance.setCurrentArenaID (currentLevel);
                break;
            case "south":
                StartCoroutine(GameManager.instance.LoadScene("Lobby"));
                break;
            case "east":
                foreach (KeyValuePair<int, Arena>
                    ArenaObject
                    in
                    GameManager.instance.GetArenas()
                )
                {
                    if (ArenaObject.Key == GameManager.instance.GetCurrentArenaID())
                    {
                        StartCoroutine(GameManager
                            .instance
                            .LoadScene(ArenaObject.Value.GetSceneName()));
                        return;
                    }
                }
                /*
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
                */
                break;
            default:
                break;
        }
    }
}
