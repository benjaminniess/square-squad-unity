using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Start() {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    public void PlayGame() {
        SceneManager.LoadScene("Play");
    }
}
