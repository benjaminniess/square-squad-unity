using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLobbyUI : MonoBehaviour
{

    GameObject pressToJoin;
    GameObject ready;
    GameObject back;
    GameObject spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        pressToJoin = transform.Find("PressToJoin").gameObject;
        ready = transform.Find("Ready").gameObject;
        back = transform.Find("Back").gameObject;
        spawnPosition = transform.Find("SpawnPosition").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showPressToJoin(bool show) {
        pressToJoin.SetActive(show);
    }

    public void showReady(bool show) {
        ready.SetActive(show);
    }

    public void showBack(bool show) {
        back.SetActive(show);
    }

    public Vector3 getSpawnPosition() {
        return spawnPosition.transform.position;
    }


}
