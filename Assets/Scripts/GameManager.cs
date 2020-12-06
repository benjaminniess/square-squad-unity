using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float transitionsDuration;

    public static GameManager instance;

    private PlayerController controller;

    private Dictionary<int, GameObject> players;

    private Dictionary<int, Arena> arenas;

    private bool downFlag = false;

    private bool upFlag = false;

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
        controller.Gameplay.SOUTH.performed += ctx => ButtonPerformed("south");
        controller.Gameplay.DASH.performed += ctx => ButtonPerformed("east");
        controller.Gameplay.UP.performed += ctx => ButtonPerformed("up");
        controller.Gameplay.UP.canceled += ctx => upFlag = false;
        controller.Gameplay.DOWN.performed += ctx => ButtonPerformed("down");
        controller.Gameplay.DOWN.canceled += ctx => downFlag = false;
        controller.Gameplay.LEFT.performed += ctx => ButtonPerformed("left");
        controller.Gameplay.RIGHT.performed += ctx => ButtonPerformed("right");
        controller.Gameplay.START.performed += ctx => ButtonPerformed("start");

        // controller.Gameplay.CLICK.performed += ctx => ButtonPerformed("click");
        controller.Enable();

        players = new Dictionary<int, GameObject>();
        GenerateArenasDictionnaty();
    }

    void ButtonPerformed(string button)
    {
        // Fix analog stick behaviour
        if (button == "down")
        {
            if (downFlag == true)
            {
                return;
            }
            downFlag = true;
        }

        if (button == "up")
        {
            if (upFlag == true)
            {
                return;
            }
            upFlag = true;
        }

        Scene scene = SceneManager.GetActiveScene();
        switch (scene.name)
        {
            case "Lobby":
                LobbyScript.instance.ButtonPerformed (button);
                break;
            case "LevelSelect":
                LevelSelect.instance.ButtonPerformed (button);
                break;
            case "MainMenu":
                MainMenu.instance.ButtonPerformed (button);
                break;
            case "HowTo":
                HowTo.instance.ButtonPerformed (button);
                break;
            case "Preload":
                break;
            default:
                Main.instance.ButtonPerformed (button);
                break;
        }
    }

    public void GenerateArenasDictionnaty()
    {
        arenas = new Dictionary<int, Arena>();
        arenas.Add(1, new Arena("Arena1", "Welcome arena"));
        arenas.Add(2, new Arena("Arena2", "Dust"));
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
