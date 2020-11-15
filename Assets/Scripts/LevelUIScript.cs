using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUIScript : MonoBehaviour
{
    private RawImage image;

    private TextMeshProUGUI text;

    void Start()
    {
    }

    void Update()
    {
    }

    public void SetImage(string imageName)
    {
        image =
            gameObject.transform.Find("LevelImage").GetComponent<RawImage>();
        Texture2D ImageTexture =
            Resources.Load("LevelsScreenshots/" + imageName) as Texture2D;
        image.texture = ImageTexture;
    }

    public void SetTitle(string title)
    {
        text =
            gameObject
                .transform
                .Find("LevelTitle")
                .GetComponent<TMPro.TextMeshProUGUI>();
        text.SetText (title);
    }
}
