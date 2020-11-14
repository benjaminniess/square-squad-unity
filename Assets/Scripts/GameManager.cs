using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float transitionsDuration;

    public static GameManager instance;

    private PlayerController controller;

    private Dictionary<int, GameObject> players;

    private Dictionary<string, Arena> arenas;

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

    public void GenerateArenasDictionnaty()
    {
        arenas = new Dictionary<string, Arena>();
        arenas.Add("Arena1", new Arena("Arena1", "Arena 1 - The first One"));
        arenas.Add("Arena2", new Arena("Arena2", "Arena 2 - The second One"));
    }

    public Dictionary<string, Arena> GetArenas()
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
