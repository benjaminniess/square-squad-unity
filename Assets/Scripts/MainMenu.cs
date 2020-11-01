using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public static MainMenu instance;
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUi;

    private void Awake()
    {
        // if the singleton hasn't been initialized yet
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }

        instance = this;
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            togglePause();
        }
    }

    public void togglePause() {
        if (gameIsPaused) 
        {
            Resume();
        }
        else
        {
            Paused();
        }
    }

    public void Resume()
    {
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1;
        gameIsPaused = false;
    }

    void Paused()
    {
        //LobbyScript.instance.hidePlayers();
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0;
        gameIsPaused = true;
    }

    public void Play()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Arena2");
        
    }

    public void Menu()
    {
        Resume();
        LobbyScript.instance.hidePlayers();
        SceneManager.LoadScene("MainMenu");
    }

    public void Lobby()
    {
        SceneManager.LoadScene("Lobby");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
