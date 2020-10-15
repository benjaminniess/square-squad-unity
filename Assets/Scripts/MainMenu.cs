using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Start() {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    public void Menu() {
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
