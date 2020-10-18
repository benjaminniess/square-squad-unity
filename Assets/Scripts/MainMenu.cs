using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUi;


    void Start() {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if ( gameIsPaused ) {
                Resume();
            } else {
                Paused();
            }
        }
    }

    public void Resume() {
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1;
        gameIsPaused = false;
    }

    void Paused() {
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0;
        gameIsPaused = true;
    }

    public void Menu() {
        Resume();
        SceneManager.LoadScene("MainMenu");
    }

    public void Arena1() {
        SceneManager.LoadScene("Arena1");
    }

    public void Arena2() {
        SceneManager.LoadScene("Arena2");
    }

    public void Exit() {
        Application.Quit();
    }
}
