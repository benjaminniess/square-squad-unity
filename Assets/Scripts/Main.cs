using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public GameObject Coin;
    public GameObject[] PlayersObjects;

    // Start is called before the first frame update
    void Start()
    {
        GenerateCoin();
        PlayersObjects = GameObject.FindGameObjectsWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if ( GameObject.FindGameObjectsWithTag("Coin").Length < 1 ) {
            GenerateCoin();
            UpdateScores();
        }
    }


    public void GenerateCoin() {
        float spawnY = Random.Range(-20,20);
        float spawnX = Random.Range(-32, 32);
        
        Instantiate(Coin, new Vector3(spawnX, spawnY, 0), Quaternion.identity);
    }

    public void UpdateScores() {
        int i = 1;
        foreach ( GameObject Player in PlayersObjects ) {
            PlayerMovements playerScript = Player.GetComponent<PlayerMovements>();
            Debug.Log(playerScript.getScore());
            GameObject.Find("ScorePlayer" + i).GetComponent<TMPro.TextMeshProUGUI>().SetText(playerScript.getScore().ToString());
            i++;
        }
        
    }
}
