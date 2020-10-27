using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUi;


    void Start()
    {
        HideExistingPlayers();
    }

    public void HideExistingPlayers() {
        GameObject[] PlayersObjects = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject Player in PlayersObjects)
        {
            PlayerMovements playerScript = Player.GetComponent<PlayerMovements>();
            Rigidbody2D rb = playerScript.getRigidbody();
            rb.transform.position = new Vector3(-100,-100,-100);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Paused();
            }
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
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0;
        gameIsPaused = true;
    }

    public void Play()
    {
        SceneManager.LoadScene("Arena2");
    }

    public void Menu()
    {
        Resume();
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
