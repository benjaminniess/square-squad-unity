using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Start() {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    public void Arena1() {
        SceneManager.LoadScene("Play");
    }

    public void Arena2() {
        SceneManager.LoadScene("Play");
    }

    public void Exit() {
        Application.Quit();
    }
}
