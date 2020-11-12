using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    public static LevelSelect instance;

    private PlayerController controller;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy (gameObject);
            }
        }

        controller = GameManager.instance.GetController();
        controller.Gameplay.SOUTH.performed += ctx => BackAction();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GameManager.instance.FadeLoadingScreen());

        Debug.Log(GameManager.instance.GetArenas());
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnEnable()
    {
        controller.Enable();
    }

    void BackAction()
    {
        StartCoroutine(GameManager.instance.LoadScene("Lobby"));
    }

    void PlayAction()
    {
        controller.Disable();
        Time.timeScale = 1;
        StartCoroutine(GameManager.instance.LoadScene("Arena1"));
    }
}
