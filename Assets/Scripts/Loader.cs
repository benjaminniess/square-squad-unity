using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loader : MonoBehaviour
{
    public Slider slider;

    void Start()
    {
        StartCoroutine(StartLoading());
    }

    IEnumerator StartLoading()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("MainMenu");

        while (!asyncLoad.isDone)
        {
            slider.value = Mathf.Clamp01(asyncLoad.progress / 0.9f);
            yield return null;
        }
    }
}
