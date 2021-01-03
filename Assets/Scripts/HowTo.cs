using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class HowTo : MonoBehaviour
{
    public static HowTo instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy (gameObject);
        }

        instance = this;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GameManager.instance.FadeLoadingScreen());   
    }

      public void ButtonPerformed(string button)
    {
        switch (button)
        {
            case "south":
            case "east":
                StartCoroutine(GameManager.instance.LoadScene("MainMenu"));
                break;
            default:
                break;
        }
    }
}
