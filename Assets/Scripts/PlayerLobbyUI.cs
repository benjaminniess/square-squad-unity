using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLobbyUI : MonoBehaviour
{
    GameObject pressToJoin;

    GameObject ready;

    GameObject readyText;

    GameObject back;

    GameObject spawnPosition;

    // Update is called once per frame
    void Update()
    {
    }

    public void reset()
    {
        Time.timeScale = 0;
        pressToJoin = transform.Find("PressToJoin").gameObject;
        ready = transform.Find("Ready").gameObject;
        readyText = transform.Find("IsReady").gameObject;
        back = transform.Find("Back").gameObject;
        spawnPosition = transform.Find("SpawnPosition").gameObject;
        showPressToJoin(true);
        showBack(false);
        showReadyButton(false);
        showReadyText(false);
    }

    public void showPressToJoin(bool show)
    {
        pressToJoin.SetActive (show);
    }

    public void showReadyButton(bool show)
    {
        ready.SetActive (show);
    }

    public void showReadyText(bool show)
    {
        readyText.SetActive (show);
    }

    public void showBack(bool show)
    {
        back.SetActive (show);
    }

    public Vector3 getSpawnPosition()
    {
        return spawnPosition.transform.position;
    }
}
