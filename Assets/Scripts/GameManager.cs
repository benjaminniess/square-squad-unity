﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float transitionsDuration;

    public static GameManager instance;

    private PlayerController controller;

    private Dictionary<int, GameObject> players;

    private Dictionary<int, Arena> arenas;

    private int currentArena = 1;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy (gameObject);
        }

        instance = this;

        DontDestroyOnLoad (gameObject);
    }

    void Start()
    {
        controller = new PlayerController();
        controller.Gameplay.SOUTH.performed += ctx => SouthAction();
        controller.Gameplay.DASH.performed += ctx => EastAction();
        controller.Gameplay.LEFT.performed += ctx => LeftAction();
        controller.Gameplay.RIGHT.performed += ctx => RightAction();
        controller.Enable();

        players = new Dictionary<int, GameObject>();
        GenerateArenasDictionnaty();
    }

    void SouthAction()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Lobby")
        {
            LobbyScript.instance.SouthAction();
        }
        else if (scene.name == "LevelSelect")
        {
            LevelSelect.instance.SouthAction();
        }
    }

    void EastAction()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Lobby")
        {
            LobbyScript.instance.EastAction();
        }
        else if (scene.name == "LevelSelect")
        {
            LevelSelect.instance.EastAction();
        }
    }

    void LeftAction()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "LevelSelect")
        {
            LevelSelect.instance.LeftAction();
        }
    }

    void RightAction()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "LevelSelect")
        {
            LevelSelect.instance.RightAction();
        }
    }

    public void GenerateArenasDictionnaty()
    {
        arenas = new Dictionary<int, Arena>();
        arenas.Add(1, new Arena("Arena1", "Arena 1 - The first One"));
        arenas.Add(2, new Arena("Arena2", "Arena 2 - The second One"));
    }

    public int GetCurrentArenaID()
    {
        return currentArena;
    }

    public void setCurrentArenaID(int ArenaID)
    {
        currentArena = ArenaID;
    }

    public Dictionary<int, Arena> GetArenas()
    {
        return arenas;
    }

    public PlayerController GetController()
    {
        return controller;
    }

    public Dictionary<int, GameObject> GetPlayers()
    {
        return players;
    }

    public void SetPlayers(Dictionary<int, GameObject> newPlayers)
    {
        players = newPlayers;
    }

    public void hidePlayers()
    {
        foreach (KeyValuePair<int, GameObject> Player in GetPlayers())
        {
            Player.Value.transform.position = new Vector3(-100, -100, -100);
        }
    }

    public IEnumerator FadeLoadingScreen()
    {
        GameObject fadeBackgroundGameObject = GameObject.Find("FadeBackground");
        SpriteRenderer fadeBackground =
            fadeBackgroundGameObject.GetComponent<SpriteRenderer>();

        float time = 0;
        Color bgColor = fadeBackground.color;

        while (time < transitionsDuration)
        {
            bgColor.a = Mathf.Lerp(1, 0, time / transitionsDuration);
            fadeBackground.color = bgColor;
            time += Time.fixedDeltaTime;
            yield return null;
        }
    }

    public IEnumerator LoadScene(string sceneName)
    {
        GameObject fadeBackgroundGameObject = GameObject.Find("FadeBackground");
        SpriteRenderer fadeBackground =
            fadeBackgroundGameObject.GetComponent<SpriteRenderer>();

        float time = 0;

        Color bgColor = fadeBackground.color;

        while (time < transitionsDuration)
        {
            bgColor.a = Mathf.Lerp(0, 1, time / transitionsDuration);
            fadeBackground.color = bgColor;
            time += Time.fixedDeltaTime;
            yield return null;
        }

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        while (!asyncLoad.isDone)
        {
            // If necessary
            // Mathf.Clamp01(asyncLoad.progress / 0.9f);
            yield return null;
        }
    }
}
