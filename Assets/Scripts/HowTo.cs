using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class HowTo : MonoBehaviour
{
    public static HowTo instance;
    public Sprite[] images;
    public SpriteRenderer renderer;
    private int currentImage = 0;

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
            case "right":
                currentImage ++;
                if ( currentImage >= images.Length ) {
                    currentImage --;
                }

                renderer.sprite = images[currentImage];
                break;
            case "left":
                currentImage --;
                if ( currentImage <= 0 ) {
                    currentImage = 0;
                }

                renderer.sprite = images[currentImage];
                break;
            case "south":
            case "east":
                currentImage ++;
                if ( currentImage >= images.Length ) {
                    StartCoroutine(GameManager.instance.LoadScene("MainMenu"));
                }

                renderer.sprite = images[currentImage];
                
                break;
            default:
                break;
        }
    }
}
