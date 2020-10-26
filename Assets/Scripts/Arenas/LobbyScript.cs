using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyScript : MonoBehaviour
{
    public static LobbyScript instance;

    public GameObject Player;

    private int PlayerCount = 0;

    private GameObject[] PlayersObjects;
    private GameObject[] playersScores;

    private void Awake()
    {
        // if the singleton hasn't been initialized yet
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }

        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        GeneratePlayers();
    }

    public void initPlayer(PlayerMovements playerScript)
    {
        PlayerCount++;

        GameObject spawnPosition = GameObject.Find("SpawnPositionForPlayer" + PlayerCount);
        Rigidbody2D rb = playerScript.getRigidbody();
        rb.transform.position = spawnPosition.transform.position;
        playerScript.name = "player_" + PlayerCount;
        playersScores[PlayerCount - 1].SetActive(true);

        PlayersObjects = GameObject.FindGameObjectsWithTag("Player");
    }

    public void GeneratePlayers()
    {
        PlayersObjects = new GameObject[4];
        playersScores = new GameObject[4];
        for (int i = 0; i < 4; i++)
        {
            playersScores[i] = GameObject.Find("ScorePlayer" + (i + 1));
            playersScores[i].SetActive(false);
        }
    }

    public void Play() {
        Debug.Log("Play");
    }
}
